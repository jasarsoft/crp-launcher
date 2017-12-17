using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Threading;

namespace Jasarsoft.Columbia.Update
{
    static internal class MainClass
    {
        private static string installMode = String.Empty;

        private static string ipAddress = String.Empty;
        //files field
        private static long sizeFiles = 0;
        private static int numberFiles = 0;
        //launcher filed
        private static int launcherNumber;
        private static int launcherUpdate;
        private static string launcherVersion;
        //columbia file list
        private static List<ColumbiaFile> dataFileList = new List<ColumbiaFile>();
        private static List<ColumbiaFile> errorFileList = new List<ColumbiaFile>();
        private static List<ColumbiaFile> updateFileList = new List<ColumbiaFile>();
        //directory filed
        private static string tempDirectory = String.Format("{0}\\Columbia State", Path.GetTempPath());

        static int Main(string[] args)
        {
            //pogretanje procesa da dobijanje ip adrese
            //Thread t = new Thread(new ThreadStart(IpAddress));
            //t.Priority = ThreadPriority.Lowest;
            //t.IsBackground = true;
            //t.Start();
            //installMode = args[0];

            Console.Title = "Columbia State Laucnher - Update Service";
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("SAMP Columbia State RolePlay Launcher - Update Service");
            Console.WriteLine("Copyright(c) 2017 Columbia State Team, Version 1.0.0.0");
            Console.WriteLine("Informacije i obavjestenja: https://columbia-state.com");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("NAPOMENA: Azuriranje launchera automatski zapocinje...\n");
            //Console.WriteLine("INFO: Molimo vas sacekajte dok se launcher nadogradi...\n");


            MessageInfo("Spajanje na servis za preuzimanje meta podataka...");
            if (!ReadBase()) return 1;

            //provjera za dostupnost servisa
            if (launcherNumber == 0)
            {
                MessageWarning();
                return 2;
            }

            MessageInfo("Provjera vasi datoteka sa posljednjim verzijama...");
            ReadFiles();

            if (numberFiles == 0)
            {
                Console.WriteLine("\n- Vase datoteke su vec azurirane na zadnje verzije.");
                Console.ReadKey();
                return 3;
            }
            else
            {
                MessageInfo(String.Format("Ukupno za ažurirati ima {0} datoteka veličine {1:0.00} MB...", numberFiles, sizeFiles / 1048576.0));
                Write("OK");
            }

            MessageInfo("Priprema temp direktorija za aktivnosti...");
            if (!PathPrepare()) return 4;

            MessageInfo("Skidanje zadnjih verzija datoteka...");
            if (!DownloadFiles()) return 5;

            MessageInfo("Raspakivanje skinutih datoteka iz temp direktorija...");
            if (!ExtractFiles()) return 6;

            MessageInfo("Brisanje nepotrebnih datoteka iz temp direktorija...");
            if (!DeleteFiles()) return 7;

            MessageInfo("Validacija novih preuzeti datoteka...");
            if (!CheckFiles()) return 8;

            if (args.Length == 0) MessageSuccess();

            return 0;
        }

        static void MessageSuccess()
        {
            Console.Write("\nAzuriranje je uspjesno izvedeno sada mozete pokrenuti launcher.");
            Console.ReadKey();
        }

        static void MessageInfo(string message, bool writeline = false)
        {
            if (writeline)
                Console.WriteLine(String.Format("INFO: {0}", message));
            else
                Console.Write(String.Format("INFO: {0}", message));
        }

        static void MessageError()
        {
            Write("ERROR");
            Console.Write("\nGreska, azuriranje nije uspjesno izvrseno prijavite na forum.");
            Console.ReadKey();
        }

        static void MessageWarning()
        {
            Console.Write("\nUpozorenje, servis trenutno nije dostupan molimo vas pokusajte kasnije.");
            Console.ReadKey();
        }

        static bool PathPrepare()
        {
            try
            {
                if (Directory.Exists(tempDirectory)) Directory.Delete(tempDirectory, true);
                Directory.CreateDirectory(tempDirectory);
                Write("OK");
                return true;
            }
            catch (Exception)
            {
                MessageError();
                return false;
            }
        }

        static bool PathDelete()
        {
            try
            {
                if (Directory.Exists(tempDirectory)) Directory.Delete(tempDirectory, true);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        static bool PathCreate()
        {
            try
            {
                Directory.CreateDirectory(tempDirectory);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        static bool ReadBase()
        {            
            try
            {
                using (XmlReader xmlReader = XmlReader.Create("https://columbia-state.com/launcher-files.xml"))
                {
                    while (xmlReader.Read())
                    {
                        switch(xmlReader.NodeType)
                        {
                            case XmlNodeType.Element:
                                {
                                    if(xmlReader.Name == "File" && xmlReader.HasAttributes)
                                    {
                                        dataFileList.Add(new ColumbiaFile(xmlReader.GetAttribute("name"), xmlReader.GetAttribute("hash"), Int64.Parse(xmlReader.GetAttribute("size"))));
#if DEBUG
                                        Console.WriteLine(xmlReader.GetAttribute("name") + " " + xmlReader.GetAttribute("hash") + " " + xmlReader.GetAttribute("size"));
#endif
                                        }
                                    if(xmlReader.Name == "Launcher" && xmlReader.HasAttributes)
                                    {
                                        launcherVersion = xmlReader.GetAttribute("version");
                                        launcherUpdate = Int32.Parse(xmlReader.GetAttribute("update"));
                                        launcherNumber = Int32.Parse(xmlReader.GetAttribute("number"));
#if DEBUG
                                        Console.WriteLine(String.Format("Launcher - version: {0}; update: {1}; number: {2}", launcherVersion, launcherUpdate, launcherNumber));
#endif
                                    }
                                        
                                    break;
                                }
                        }
                    }
#if DEBUG
                    System.Threading.Thread.Sleep(1000);
#endif
                }

                Write("OK");
                return true;
            }
            catch (Exception)
            {
                MessageError();
                return false;
            }  
        }

        static bool CheckFiles()
        {
            numberFiles = 0;
            errorFileList = new List<ColumbiaFile>();
            
            foreach (ColumbiaFile file in dataFileList)
            {
                if (HashFile.GetMD5(file.Name) != file.Hash)
                {
                    numberFiles++;
                    errorFileList.Add(new ColumbiaFile(file.Name, file.Hash, file.Size));
                }     
            }

            if(numberFiles == 0)
            {
                Write("OK");
                return true;
            }

            MessageError();
            return false;
        }

        static void ReadFiles()
        {
            sizeFiles = 0;
            numberFiles = 0;
            
            foreach(ColumbiaFile file in dataFileList)
            {
                if (HashFile.GetMD5(file.Name) != file.Hash)
                {
                    numberFiles++;
                    sizeFiles += file.Size;
                    updateFileList.Add(new ColumbiaFile(file.Name, file.Hash, file.Size));
                }
            }
            //poruka nakon zavrsene provjere
            Write("OK");
        }

        static bool DownloadFiles()
        {
            try
            {
                foreach (ColumbiaFile file in updateFileList) DownloadFile(file);
                Write("OK");
                return true;
            }
            catch (Exception)
            {
                MessageError();
                return false;
            }
        }

        static bool ExtractFiles()
        {
            try
            {
                foreach (ColumbiaFile file in updateFileList) ExtractFile(file);
                Write("OK");
                return true;
            }
            catch (Exception)
            {
                MessageError();
                return false;
            }
        }

        static bool DeleteFiles()
        {
            try
            {
                foreach (ColumbiaFile file in updateFileList) DeleteFile(file);
                Write("OK");
                return true;
            }
            catch (Exception)
            {
                MessageError();
                return false;
            }
        }


        static void DownloadFile(ColumbiaFile file)
        {
            using (WebClient client = new WebClient())
            {
                var url = new Uri("https://columbia-state.com/launcher/files/" + file.Name + ".zip");
                client.DownloadFile(url, tempDirectory + "\\" + file.Name + ".zip");

                //client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
                //client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted);

                //client.DownloadFileAsync(url, path + "\\" + lib.Name(i).Substring(2) + ".gz");
                //client.DownloadFile(url, path + "\\" + lib.Name(i).Substring(2) + ".gz");
                //while (client.IsBusy) Thread.Sleep(100);
            }
        }

        static bool ExtractFile(ColumbiaFile file)
        {
            string name = String.Format("{0}\\{1}.zip", tempDirectory, file.Name);
            if (!File.Exists(name)) return false;
            if (File.Exists(file.Name)) File.Delete(file.Name);
            ZipFile.ExtractToDirectory(name, ".\\");
            return (HashFile.GetMD5(file.Name) == file.Hash);
        }

        static void DeleteFile(ColumbiaFile file)
        {
            string name = String.Format("{0}\\{1}.zip", tempDirectory, file.Name);
            if (File.Exists(name)) File.Delete(name);
        }

        private static void Write(string message)
        {
            try
            {
                Console.SetCursorPosition(70, Console.CursorTop);
                Console.WriteLine(message);
            }
            catch (Exception)
            {
                Console.WriteLine("null");
            }
        }

        private static void IpAddress()
        {
            string uri = "http://checkip.dyndns.org/";

            try
            {
                using (var client = new HttpClient())
                {
                    var result = client.GetAsync(uri).Result.Content.ReadAsStringAsync().Result;

                    ipAddress = result.Split(':')[1].Split('<')[0];
                }
            }
            catch (Exception)
            {
                ipAddress = null;
            }
        }
    }
}

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
using System.Diagnostics;
using Microsoft.Win32;

namespace Jasarsoft.Columbia.Update
{
    static internal class MainClass
    {
        private static string ipAddress = String.Empty;
        //files field
        private static long sizeFiles = 0;
        private static int numberFiles = 0;
        //launcher filed
        private static int launcherNumber;
        private static int launcherUpdate;
        private static string launcherVersion;

        private static StringCipher cipher = new StringCipher();
        //columbia file list
        private static List<ColumbiaFile> dataFileList = new List<ColumbiaFile>();
        private static List<ColumbiaFile> errorFileList = new List<ColumbiaFile>();
        private static List<ColumbiaFile> updateFileList = new List<ColumbiaFile>();
        //directory filed
        private static string tempDirectory = String.Format("{0}\\Columbia State", Path.GetTempPath());

        private static bool messageShow = false;
        private const string modeShow = "qMnecXIek9uvqT1kkRrdImyhVkKLKynehXdLAT/ea2s5wubQlFmAWqexMXJvooyqA5+9qjpzFYk8N/mUpMB4rIRdOqGh2fj7uwvYL4q/A4fQ/B8RrxisGrrIDz5CNWXF"; //cs_show
        private const string modeSilent = "OE605a2s7zg7O9YeMiHqplyB7K3ToWRMCu79Xno4P88FOsSXrWJhDsXUk0C6/MFB5MwJHbrfSBNmWkBryQAt1rU2jNs7hZW48K2hnsU4AdWTaE3vXVOF7fMHh+WVAUSI"; //cs_silent 

        private const string archiveExtension = "KNlp73VxSNGk0e8TWqdopHozwPhdgMd63f3pKVTikkNJRNN7xnGQ1q8BDC8Of+IKWUd3UoUhS6D4pmNwixK0ML8xq5TQ6s5vCAQNolQJIi1z4GoXlTLfOG/h7Irp3p2O"; //.zip

        static int Main(string[] args)
        {
            
            //pogretanje procesa da dobijanje ip adrese
            //Thread t = new Thread(new ThreadStart(IpAddress));
            //t.Priority = ThreadPriority.Lowest;
            //t.IsBackground = true;
            //t.Start();

            if (args.Length == 0)
                return 1;
            else if (args[0] == cipher.Decrypt(modeShow))
                messageShow = true;
            else if (args[0] == cipher.Decrypt(modeSilent))
                messageShow = false;
            else
                return ColumbiaRun("1");

            MessageHeader();
            MessageInfo("Spajanje na servis za preuzimanje meta podataka...");
            if (!ReadBase()) return ColumbiaRun("2");

            //provjera za dostupnost servisa
            if (launcherNumber == 0)
            {
                MessageWarning();
                return ColumbiaRun("3");
            }

            MessageInfo("Provjera vasi datoteka sa posljednjim verzijama...");
            ReadFiles();

            if (numberFiles == 0)
            {
                if (messageShow)
                {
                    Console.Write("\n- Vase datoteke su vec azurirane na zadnje verzije.");
                    Console.ReadKey();
                }

                return ColumbiaRun("0");
            }
            else
            {
                MessageInfo(String.Format("Ukupno za ažurirati ima {0} datoteka veličine {1:0.00} MB...", numberFiles, sizeFiles / 1048576.0));
                Write("OK");
            }

            MessageInfo("Priprema temp direktorija za aktivnosti...");
            if (!PathPrepare()) return ColumbiaRun("4");

            MessageInfo("Skidanje zadnjih verzija datoteka...");
            if (!DownloadFiles()) return ColumbiaRun("5");

            MessageInfo("Raspakivanje skinutih datoteka iz temp direktorija...");
            if (!ExtractFiles()) return ColumbiaRun("6");

            MessageInfo("Brisanje nepotrebnih datoteka iz temp direktorija...");
            if (!DeleteFiles()) return ColumbiaRun("7");

            MessageInfo("Validacija novih preuzeti datoteka...");
            if (!CheckFiles()) return ColumbiaRun("8");
                

            MessageSuccess();
            UpdateRegistry reg = new UpdateRegistry();
            reg.UpdateValue = launcherUpdate.ToString();
            reg.VersionValue = launcherVersion.ToString();
            return ColumbiaRun("0");
        }

        static int ColumbiaRun(string arg)
        {
            if(File.Exists("columbia.exe"))
            {
                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = "columbia.exe";
                info.WorkingDirectory = ".\\";
                info.Arguments = arg;
                Process.Start(info);
            }

            return 0;
        }

        static void MessageHeader()
        {
            if(messageShow)
            {
                Console.Title = "Columbia State Laucnher - Update Service";
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("SAMP Columbia State RolePlay Launcher - Update Service");
                Console.WriteLine("Copyright(c) 2017 Columbia State Team, Version 1.0.0.2");
                Console.WriteLine("Informacije i obavjestenja: https://columbia-state.com");
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("NAPOMENA: Azuriranje launchera automatski zapocinje...\n");
            }
        }

        static void MessageUpdate()
        {
            if (messageShow)
            {
                Console.WriteLine("\n- Vase datoteke su vec azurirane na zadnje verzije.");
                Console.ReadKey();
            }
        }

        static void MessageSuccess()
        {
            if(messageShow)
            {
                Console.Write("\nAzuriranje je uspjesno izvedeno sada mozete pokrenuti launcher.");
                Console.ReadKey();
            }
        }

        static void MessageInfo(string message, bool writeline = false)
        {
            if (messageShow)
            {
                if (writeline)
                    Console.WriteLine(String.Format("INFO: {0}", message));
                else
                    Console.Write(String.Format("INFO: {0}", message));
            }
        }

        static void MessageError()
        {
            if(messageShow)
            {
                Write("ERROR");
                Console.Write("\nGreska, azuriranje nije uspjesno izvrseno prijavite na forum.");
                Console.ReadKey();
            }
        }

        static void MessageWarning()
        {
            if(messageShow)
            {
                Console.Write("\nUpozorenje, servis trenutno nije dostupan molimo vas pokusajte kasnije.");
                Console.ReadKey();
            }
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
            StringCipher cipher = new StringCipher();
            string link = "nbZmYr7jvT5PizpmGzI2HNN08YmDWP7DTjtTqSKh9y1lYwVPF3AS7wGdamKwjp5OePV7j+3AY0pMbUUE22hhUj3P155zB1++wip2K0GJO5ra+S1TbT+vaUZVgcmHrZbC6Ozfi07fQ6PY6nn6hQaaJyi9J3AaprEbOncdCy9YPc0="; //https://columbia-state.com/launcher-files.xml

            try
            {

                using (XmlReader xmlReader = XmlReader.Create(cipher.Decrypt(link)))
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
            string link = "NnLZSIYBSB42EgVIX2MXed30BXSSquhuO1OBzLEDIiErmKfp/dbfdoEmKtvOUpujK4NQg+47/SpeLX+cg8Ac9UppPrA9GBMr8z4tZwRJ6seivmnq+GaYlwkJw7d7JlSkjKqkbjGrzEpQ6X96u+FtiQIdFwFrwfHRT7+jqU//9Mw="; //https://columbia-state.com/launcher/files/
            using (WebClient client = new WebClient())
            {
                var url = new Uri(cipher.Decrypt(link) + file.Name + cipher.Decrypt(archiveExtension));
                client.DownloadFile(url, tempDirectory + "\\" + file.Name + cipher.Decrypt(archiveExtension));

                //client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
                //client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted);

                //client.DownloadFileAsync(url, path + "\\" + lib.Name(i).Substring(2) + ".gz");
                //client.DownloadFile(url, path + "\\" + lib.Name(i).Substring(2) + ".gz");
                //while (client.IsBusy) Thread.Sleep(100);
            }
        }

        static bool ExtractFile(ColumbiaFile file)
        {
            string name = String.Format("{0}\\{1}{2}", tempDirectory, file.Name, cipher.Decrypt(archiveExtension));
            if (!File.Exists(name)) return false;
            if (File.Exists(file.Name)) File.Delete(file.Name);
            ZipFile.ExtractToDirectory(name, ".\\");
            return (HashFile.GetMD5(file.Name) == file.Hash);
        }

        static void DeleteFile(ColumbiaFile file)
        {
            string name = String.Format("{0}\\{1}{2}", tempDirectory, file.Name, cipher.Decrypt(archiveExtension));
            if (File.Exists(name)) File.Delete(name);
        }

        private static void Write(string message)
        {
            try
            {
                if (!messageShow) return;
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
            StringCipher cipher = new StringCipher();
            string uri = "E8rWoSFcl8CMQmn8zuaPB8eS844i41V/gbj3+YUpk+/MGgXLa5/LV8C8MYAJGIollXBe1pBe40jiPyidrUNilaztNHTEnR6ece5ul6Suz5ivHHkj2JU1wiGRbqe7Cz4W"; //http://checkip.dyndns.org/

            try
            {
                using (var client = new HttpClient())
                {
                    var result = client.GetAsync(cipher.Decrypt(uri)).Result.Content.ReadAsStringAsync().Result;

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

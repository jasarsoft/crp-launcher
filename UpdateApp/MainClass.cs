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
        private const string modeSilent = "6+37Xpr7Ij/N7wPYg3U2M9rFrwNPm86YGI0EGiCwl6Hgx0en6lxQfTuxK416epvmZMxBthTT1dTNcuiEDge2Tt1PKSjNVCfYq5RORDWWzHhndpn8xuVVDaxKSDhrEPgW"; //cs_silent14 

        private const string archiveExtension = "KNlp73VxSNGk0e8TWqdopHozwPhdgMd63f3pKVTikkNJRNN7xnGQ1q8BDC8Of+IKWUd3UoUhS6D4pmNwixK0ML8xq5TQ6s5vCAQNolQJIi1z4GoXlTLfOG/h7Irp3p2O"; //.zip

        static int Main(string[] args)
        {
            //pogretanje procesa da dobijanje ip adrese
            Trace.TraceInformation("Pokretanje pozadinskog procesa za dobijanje javne ip adrese");
            Thread t = new Thread(new ThreadStart(IpAddress));
            t.Priority = ThreadPriority.Lowest;
            t.IsBackground = true;
            t.Start();
            Trace.TraceInformation("Proces je startovan.");
            
            if (args.Length == 0)
            {
                Trace.TraceInformation("Aplikacija je pokrenuta bez argumenta.");
                return 1;
            }
            else if (args[0] == cipher.Decrypt(modeShow))
            {
                Trace.TraceInformation("Aplikacija je pokrenuta sa argumentom prikaza.");
                messageShow = true;
            }
            else if (args[0] == cipher.Decrypt(modeSilent))
            {
                Trace.TraceInformation("Aplikacija je pokrenuta sa argumentom ne prikaza.");
                messageShow = false;
            }
            else
            {
                Trace.TraceInformation("Aplikacija je pokrenuta sa trecim argumentom");
                return ColumbiaRun("1");
            }

            Trace.TraceInformation("Poziv metode za ispis poruke Header.");
            MessageHeader();

            Trace.TraceInformation("Poziv metode za ispis poruke o preuzimanju meta podataka.");
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

            MessageInfo("Zapis u registar vrijednosti ažuriranja...");
            if (!RegistryWrite()) return ColumbiaRun("9");

            MessageSuccess();
            ColumbiaRun("0", ipAddress);
            return 0;
        }

        static int ColumbiaRun(string value, string address = "0")
        {
            if (messageShow) return 0;

            if(File.Exists("columbia.exe"))
            {
                Process process = new Process();
                process.StartInfo.FileName = "columbia.exe";
                process.StartInfo.WorkingDirectory = ".\\";
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.Arguments = value + " " + address;
                process.Start();
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

        static bool RegistryWrite()
        {
            UpdateRegistry reg = new UpdateRegistry();
            reg.UpdateValue = launcherUpdate.ToString();
            reg.VersionValue = launcherVersion.ToString();
            if (!reg.Check()) reg.Create();
            if (reg.Write())
            {
                Write("OK");
                return true;
            }
            MessageError();
            return false;
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
                                        string name = xmlReader.GetAttribute("name");
                                        string hash = xmlReader.GetAttribute("hash");
                                        long size = Int64.Parse(xmlReader.GetAttribute("size"));

                                        Trace.TraceInformation("ReadBase(); Xml File: name={0}; hash={1}; size:{2}", name, hash, size.ToString());
                                        dataFileList.Add(new ColumbiaFile(name, hash, size));
                                    }
                                    if(xmlReader.Name == "Launcher" && xmlReader.HasAttributes)
                                    {
                                        launcherVersion = xmlReader.GetAttribute("version");
                                        launcherUpdate = Int32.Parse(xmlReader.GetAttribute("update"));
                                        launcherNumber = Int32.Parse(xmlReader.GetAttribute("number"));
                                        Trace.TraceInformation("ReadBase(); Xml Launcher: version={0}; update={1}; number={2}", launcherVersion, launcherUpdate, launcherNumber);
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
                Trace.TraceInformation("ReadBase(); return true;");
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
            Trace.WriteLine("Ulaz u metodu ReadFiles");
            sizeFiles = 0;
            numberFiles = 0;

            Trace.TraceInformation("ReadFiles(); Ukupno datoteka za procitat {0}", dataFileList.Count);
            foreach(ColumbiaFile file in dataFileList)
            {
                Trace.TraceInformation("Provjera hash vrijednosti za fajl: {0}", file.Name);
                if (HashFile.GetMD5(file.Name) != file.Hash)
                {
                    numberFiles++;
                    sizeFiles += file.Size;
                    updateFileList.Add(new ColumbiaFile(file.Name, file.Hash, file.Size));
                    Trace.TraceInformation("Hash vrijednost za datotku {0} nije ispravna.", file.Name);
                    Trace.TraceInformation("Hash datoteke: {0}; Hash baze: {1}", file.Hash, HashFile.GetMD5(file.Name));
                }
            }
            //poruka nakon zavrsene provjere
            Write("OK");
        }

        static bool DownloadFiles()
        {
            try
            {
                foreach (ColumbiaFile file in updateFileList)
                {
                    DownloadFile(file);
                    Trace.TraceInformation(String.Format("Skidanje datoteke: {0}", file.Name));
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

        static bool ExtractFiles()
        {
            try
            {
                foreach (ColumbiaFile file in updateFileList)
                {
                    ExtractFile(file);
                    Trace.TraceInformation(String.Format("Raspakivanje datoteke: {0}", file.Name));
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
            Trace.TraceInformation("Ulaz u metodu IpAddress");
            StringCipher cipher = new StringCipher();
            string uri = "E8rWoSFcl8CMQmn8zuaPB8eS844i41V/gbj3+YUpk+/MGgXLa5/LV8C8MYAJGIollXBe1pBe40jiPyidrUNilaztNHTEnR6ece5ul6Suz5ivHHkj2JU1wiGRbqe7Cz4W"; //http://checkip.dyndns.org/

            try
            {
                Trace.TraceInformation("Zahtjev za dobijanje ip addrese.");
                using (var client = new HttpClient())
                {
                    var result = client.GetAsync(cipher.Decrypt(uri)).Result.Content.ReadAsStringAsync().Result;
                    Trace.TraceInformation("Vrijednost: {0}", result);
                    ipAddress = result.Split(':')[1].Split('<')[0];
                    Trace.TraceInformation("IP Adresa: {0}", ipAddress);
                }
            }
            catch (Exception)
            {
                Trace.TraceError("Greška u zahtjevu dobijanja ip adrese.");
                ipAddress = null;
            }
        }
    }
}

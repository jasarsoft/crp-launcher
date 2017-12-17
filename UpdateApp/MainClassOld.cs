using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.ComponentModel;
using System.Threading;

namespace Jasarsoft.Columbia.Update1
{
    class MainClassOld
    {
        static int index = 0;
        static string path = Path.GetTempPath();
        private static int pozX;
        private static int pozY;
        private static bool error = false;

        static void Main2()
        {
            Console.WriteLine("Columbia State Launcher - Update Service");
            Console.WriteLine("Version 1.0.0.0, (c) Columbia State Team");
            Console.WriteLine("Error report: https://columbia-state.com");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Azuriranja launcher-a automatski pocinje\n");

            FilesLibrary lib = new FilesLibrary();

            for (int i = 0; i < lib.Lenght; i++)
            {
                
                index = i;
                Console.Write(lib.Name(i).Substring(2));
                //for(int j = 0; j < (50 - lib.Name(i).Substring(2).Length); j++)
                //{
                //    Console.Write(" ");
                //}   
                pozX = Console.CursorLeft + (50 - lib.Name(i).Substring(2).Length);
                pozY = Console.CursorTop;
                Write("provjera  ");
                if (File.Exists(lib.Name(i)))
                {
                    Write("valdacija ");
                    if (HashFile.GetMD5(lib.Name(i)) == lib.Hash(i))
                    {
                        Write("uredu     \n");
                        continue;
                    }
                    else
                    {
                        Write("brisanje  ");
                        File.Delete(lib.Name(i));

                        Write("skidanje ");

                        using (WebClient client = new WebClient())
                        {
                            var url = new Uri("https://columbia-state.com/launcher/" + lib.Name(i).Substring(2) + ".gz");
                            //client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
                            //client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted);

                            //client.DownloadFileAsync(url, path + "\\" + lib.Name(i).Substring(2) + ".gz");
                            client.DownloadFile(url, path + "\\" + lib.Name(i).Substring(2) + ".gz");
                            //while (client.IsBusy) Thread.Sleep(100);
                        }

                        Write("dekompresija        ");
                        if (File.Exists(path + "\\" + lib.Name(i).Substring(2) + ".gz"))
                        {
                            FileInfo fi = new FileInfo(path + "\\" + lib.Name(i).Substring(2) + ".gz");
                            Decompress(fi);
                        }
                        else
                        {
                            error = true;
                            Write("greska u skidanju fajla");
                            break;
                        }
                        File.Delete(path + "\\" + lib.Name(i).Substring(2) + ".gz");

                        Write("provjera            ");
                        if(File.Exists(lib.Name(i)))
                        {
                            Write("valdacija           ");
                            if (HashFile.GetMD5(lib.Name(i)) == lib.Hash(i))
                            {
                                Write("uredu     \n");
                                continue;
                            }
                            else
                            {
                                error = true;
                                Write("greska u valdaciji skinutog fajla");
                                break;
                            }
                        }
                        else
                        {
                            error = true;
                            Write("greska u provjeri skinutog fajla");
                            break;
                        }
                    }
                }
                else
                {
                    Write("skidanje ");
                    using (WebClient client = new WebClient())
                    {
                        var url = new Uri("https://columbia-state.com/launcher/" + lib.Name(i).Substring(2) + ".gz");
                        //client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
                        //client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted);

                        //client.DownloadFileAsync(url, path + "\\" + lib.Name(i).Substring(2) + ".gz");
                        client.DownloadFile(url, path + "\\" + lib.Name(i).Substring(2) + ".gz");
                        //while (client.IsBusy) Thread.Sleep(100);
                    }

                    Write("dekompresija");
                    if (File.Exists(path + "\\" + lib.Name(i).Substring(2) + ".gz"))
                    {
                        FileInfo fi = new FileInfo(path + "\\" + lib.Name(i).Substring(2) + ".gz");
                        Decompress(fi);
                    }
                    else
                    {
                        error = true;
                        Write("greska u skidanju fajla");
                        break;
                    }
                    File.Delete(path + "\\" + lib.Name(i).Substring(2) + ".gz");
                    Write("provjera    ");
                    if (File.Exists(lib.Name(i)))
                    {
                        Write("valdacija   ");
                        if (HashFile.GetMD5(lib.Name(i)) == lib.Hash(i))
                        {
                            Write("uredu     \n");
                            continue;
                        }
                        else
                        {
                            error = true;
                            Write("greska u valdaciji skinutog fajla");
                            break;
                        }
                    }
                    else
                    {
                        error = true;
                        Write("greska u provjeri skinutog fajla");
                        break;
                    }
                }
            }

            if(error)
            {
                Console.WriteLine("\nGreska tokom azuriranja, prijavite na https://columbia-state.com");
            }
            else
            {
                Console.WriteLine("\nUspjesno azuriranje, pokrenite aplikaciju");
            }

            Console.ReadKey();
            
        }

        private static void Write(string s, int x = 0, int y = 0)
        {
            try
            {
                Console.SetCursorPosition(pozX + x, pozY + y);
                Console.Write(s);
            }
            catch (Exception e)
            {
                //Console.Clear();
                Console.WriteLine("\nGreska u pisanju na konzoli.");
            }
        }

        static bool DownloadFile(string name)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    var url = new Uri("https://columbia-state.com/launcher/" + name + ".gz");
                    //client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
                    //client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted);

                    //client.DownloadFileAsync(url, path + "\\" + lib.Name(i).Substring(2) + ".gz");
                    client.DownloadFile(url, path + "\\" + name + ".gz");
                    //while (client.IsBusy) Thread.Sleep(100);
                }

                if (File.Exists(path + "\\" + name + ".gz"))
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }  
        }

        static void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //Console.Write("\r{0} {1}", e.ProgressPercentage, e.BytesReceived);
            Write(e.ProgressPercentage.ToString());
        }

        static void DownloadFileCompleted(object sender, AsyncCompletedEventArgs args)
        {
            //Console.WriteLine(" ... zavrseno");
            Write("zavrseno      ");
        }

        public static void Decompress(FileInfo fi)
        {
            // Get the stream of the source file.
            using (FileStream inFile = fi.OpenRead())
            {
                // Get original file extension, for example "doc" from report.doc.gz.
                string curFile = fi.FullName;
                string origName = fi.Name.Remove(fi.Name.Length - fi.Extension.Length);

                //Create the decompressed file.
                using (FileStream outFile = File.Create(origName))
                {
                    using (GZipStream Decompress = new GZipStream(inFile, CompressionMode.Decompress))
                    {
                        // Copy the decompression stream into the output file.
                        Decompress.CopyTo(outFile);
                        //Console.WriteLine("Decompressed: {0}", fi.Name);

                    }
                }
            }
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;

namespace Jasarsoft.MySQLInserter
{
    class Program
    {
        static MySqlCommand command;
        static MySqlConnection mysql;
        static DriveService service;

        static int numberTable = 0;
        static string dirPath = ".\\";

        static void DriveDirectory(DriveService service, string folderId, string path)
        {
            ChildrenResource.ListRequest request = service.Children.List(folderId);
            request.MaxResults = 1000;

            File file = null;
            do
            {
                try
                {
                    ChildList children = request.Execute();

                    foreach (ChildReference child in children.Items)
                    {
                        file = service.Files.Get(child.Id).Execute();

                        if (file.MimeType == "application/vnd.google-apps.folder")
                        {
                            dirPath += file.Title + @"\";
                            DriveDirectory(service, file.Id, dirPath);
                            dirPath = dirPath.Substring(0, dirPath.Length - (file.Title.Length + 1));
                        }
                        else
                        {
                            //Console.WriteLine(file.Title);
                            Console.WriteLine(@"{0}{1}", path, file.Title);


                            mysql.Open();
                            command = mysql.CreateCommand();
                            if (numberTable == 1)
                                command.CommandText = "INSERT INTO games_edit(name, size, hash, fileid, url) VALUES(@name, @size, @hash, @fileid, @url)";
                            else
                                command.CommandText = "INSERT INTO mods_edit(name, size, hash, fileid, url) VALUES(@name, @size, @hash, @fileid, @url)";
                            command.Parameters.AddWithValue("@name", path + file.Title);
                            command.Parameters.AddWithValue("@size", file.FileSize);
                            command.Parameters.AddWithValue("@hash", file.Md5Checksum);
                            command.Parameters.AddWithValue("@fileid", file.Id);
                            command.Parameters.AddWithValue("@url", file.DownloadUrl);
                            command.ExecuteNonQuery();
                            mysql.Close();
                        }


                    }
                    request.PageToken = children.NextPageToken;
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERROR: Doslo je do greske sljedece oznake,\n" + e.Message);
                    request.PageToken = null;
                    Console.ReadKey();
                }
            } while (!String.IsNullOrEmpty(request.PageToken));
        }



        static void Main(string[] args)
        {
            
            SqlConstant cb = new SqlConstant();
            PrivateData pd = new PrivateData();

            string query = String.Format("{0}={1};{2}={3};{4}={5};{6}={7};",
                                        cb.Server, pd.Server,
                                        cb.Username, pd.Username,
                                        cb.Password, pd.Password,
                                        cb.Database, pd.Database);

            
            Console.WriteLine("1. Games table (sadrzi fajlove originalne osnovne igre)");
            Console.WriteLine("2. Mods table (sadrzi modifikovane i nove fajlove igre)");
            Console.WriteLine("3. Zatvorite aplikaciju");
            Console.Write("Odaberite broj ispred tabele koju mijenjate: ");
            try
            {
                numberTable = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("\nERROR: Pogrijesili ste, aplikacija se zatvara.");
                Console.ReadKey();
                return;
            }

            if (numberTable == 3) return;
            if(numberTable < 1 || numberTable > 3)
            {
                Console.WriteLine("\nERROR: Pogrijesili ste broj ispred tabele, aplikacija se zatvara.");
                Console.ReadKey();
                return;
            }

            mysql = new MySqlConnection(query);
            if(mysql == null)
            {
                Console.WriteLine("ERROR: Konekcija na bazu podatak nije uspjesna!");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("INFO: Spajanje na bazu podataka je uspjesno.");
            //MySqlTable sqlTable = new MySqlTable(mysql);

           
            try
            {
                
               mysql.Open();
               command = mysql.CreateCommand();
               if(numberTable == 1)
               {
                   command.CommandText = @"DROP TABLE IF EXISTS columbia.games_edit";
                   command.ExecuteNonQuery();
                   Console.WriteLine("INFO: Tabela 'games_edit' je obrisana.");
                   command = mysql.CreateCommand();
                   command.CommandText = @"CREATE TABLE columbia.games_edit(id INT(9) NOT NULL AUTO_INCREMENT,
                                       valid SMALLINT(1) DEFAULT 1,
                                       name VARCHAR(64) DEFAULT 'filename.ext',
                                       size INT(15) DEFAULT 0,
                                       hash VARCHAR(64) DEFAULT 'MD5',
                                       fileid VARCHAR(64) DEFAULT 'file id',
                                       url VARCHAR(256) DEFAULT 'https://...',                                        
                                       PRIMARY KEY (id))";
                   command.ExecuteNonQuery();
                   Console.WriteLine("INFO: Tabela 'games_edit' je napravljena.");

               }
               else
               {
                   command.CommandText = @"DROP TABLE IF EXISTS columbia.mods_edit";
                   command.ExecuteNonQuery();
                   command = mysql.CreateCommand();
                   Console.WriteLine("INFO: Tabela 'mods_edit' je obrisana.");
                   command.CommandText = @"CREATE TABLE columbia.mods_edit(id INT(9) NOT NULL AUTO_INCREMENT,
                                       valid SMALLINT(1) DEFAULT 1,
                                       name VARCHAR(64) DEFAULT 'filename.ext',
                                       size INT(15) DEFAULT 0,
                                       hash VARCHAR(64) DEFAULT 'MD5',
                                       fileid VARCHAR(64) DEFAULT 'file id',
                                       url VARCHAR(256) DEFAULT 'https://...',                                       
                                       PRIMARY KEY (id))";
                   command.ExecuteNonQuery();
                   Console.WriteLine("INFO: Tabela 'mods_edit' je napravljena.");
               }
               mysql.Close();
              
                Console.WriteLine("INFO: Spajanje na google drive servis...");
                service = GoogleDrive.AuthenticateService();

                if (service == null)
                {
                    Console.WriteLine("ERROR: Neuspjesno spajanje na google drive servis.");
                    Console.ReadLine();
                    return;
                }
                else
                {
                    Console.WriteLine("INFO: Uspjesno spajanje na google drive servis.");
                }

                
                //DriveDir(service, "0Byi5ne7d961QVS1XOGlPaTRKc28", dirPath); //Files folder
                if (numberTable == 1)
                    DriveDirectory(service, "13Lx2mlGr7fqwO7kZuyU7uWOWtqU4d5zs", dirPath); //Games folder
                else
                    DriveDirectory(service, "117hfV8FLaffZMceXqxTRRZAKorQKb0nA", dirPath); //Mods folder
                
                /*
                command.CommandText = @"CREATE TABLE columbia.mods_edit(id INT(9) NOT NULL AUTO_INCREMENT,
                                        valid SMALLINT(1) DEFAULT 1,
                                        name VARCHAR(64) DEFAULT 'filename.ext',
                                        size INT(15) DEFAULT 0,
                                        hash VARCHAR(64) DEFAULT 'MD5',
                                        fileid VARCHAR(64) DEFAULT 'file id',
                                        url VARCHAR(256) DEFAULT 'https://...',                                        
                                        PRIMARY KEY (id))";
                command.ExecuteNonQuery();
                Console.WriteLine("INFO: Tabela je uspjesno napravljena!");
                mysql.Close();

                

                service = GoogleDrive.AuthenticateService();

                if (service == null)
                {
                    Console.WriteLine("Authentication error");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("INFO: Google Drive authentifikacija je uspjesna.");
                }

                
                //DriveDir(service, "13Lx2mlGr7fqwO7kZuyU7uWOWtqU4d5zs", dirPath); //Games folder
                DriveDir(service, "117hfV8FLaffZMceXqxTRRZAKorQKb0nA", dirPath); //Mods folder
                */

                Console.WriteLine("\nINFO: Tabela je uspjesno pounjena vrijednostima.");
                Console.Write("Pritisnite enter i prebacite tabelu u radnu...");
                Console.ReadKey();

                mysql.Open();
                
                if (numberTable == 1)
                {
                    command = mysql.CreateCommand();
                    command.CommandText = @"DROP TABLE IF EXISTS columbia.games_old";
                    command.ExecuteNonQuery();
                    Console.WriteLine("INFO: Tabela 'games_old' je obrisana.");

                    command = mysql.CreateCommand();
                    command.CommandText = @"RENAME TABLE columbia.games TO columbia.games_old";
                    command.ExecuteNonQuery();
                    Console.WriteLine("INFO: Tabela 'games' je preimenovana u 'games_old'");

                    command = mysql.CreateCommand();
                    command.CommandText = @"RENAME TABLE columbia.games_edit TO columbia.games";
                    command.ExecuteNonQuery();
                    Console.WriteLine("INFO: Tabela 'games_edit' je preimenovana u 'games'");
                }
                else
                {
                    command = mysql.CreateCommand();
                    command.CommandText = @"DROP TABLE IF EXISTS columbia.mods_old";
                    command.ExecuteNonQuery();
                    Console.WriteLine("INFO: Tabela 'mods_old' je obrisana.");

                    command = mysql.CreateCommand();
                    command.CommandText = @"RENAME TABLE columbia.mods TO columbia.mods_old";
                    command.ExecuteNonQuery();
                    Console.WriteLine("INFO: Tabela 'mods' je preimenovana u 'mods_old'");

                    command = mysql.CreateCommand();
                    command.CommandText = @"RENAME TABLE columbia.mods_edit TO columbia.mods";
                    command.ExecuteNonQuery();
                    Console.WriteLine("INFO: Tabela 'mods_edit' je preimenovana u 'mods'");
                }

                mysql.Close();

                Console.WriteLine("\nINFO: Tabela je uspjesno postavljena.");
                Console.ReadKey();
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR: Desila se nepoznata greska u upitu.");
                Console.ReadKey();
            }
            
        }
    }
}

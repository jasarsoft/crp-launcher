using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Jasarsoft.Columbia.Library;
using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;

namespace Jasarsoft.MySQLInserter
{
    class Program
    {
        static MySqlCommand command;
        static MySqlConnection mysql;
        static DriveService service;

        static int dirDepth = 0;
        static string dirPath = ".\\";

        static void DriveDir(DriveService service, string folderId, string path)
        {
            try
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
                                Console.WriteLine("- DIR:\t{0}\\{1}", path, file.Title);
                                dirPath += file.Title + "\\";
                                DriveDir(service, file.Id, dirPath);
                                dirPath = dirPath.Substring(0, dirPath.Length - (file.Title.Length + 1));
                            }
                            else
                            {
                                Console.WriteLine(file.Title);
                                command = mysql.CreateCommand();
                                mysql.Open();
                                command.CommandText = "INSERT INTO test3(name, size, hash, fileid, url) VALUES(@name, @size, @hash, @fileid, @url)";
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
                        Console.WriteLine("An error occurred: " + e.Message);
                        request.PageToken = null;
                    }
                } while (!String.IsNullOrEmpty(request.PageToken));

                //dirDepth--;
                
            }
            catch (Exception ex)
            {
            }
        }

        static void Main(string[] args)
        {
            BaseConst cb = new BaseConst();
            PrivateData pd = new PrivateData();

            //Google Drive scopes Documentation:   https://developers.google.com/drive/web/scopes
            string[] scopes = new string[] { DriveService.Scope.Drive,  // view and manage your files and documents
                                             DriveService.Scope.DriveAppdata,  // view and manage its own configuration data
                                             DriveService.Scope.DriveAppsReadonly,   // view your drive apps
                                             DriveService.Scope.DriveFile,   // view and manage files created by this app
                                             DriveService.Scope.DriveMetadataReadonly,   // view metadata for files
                                             DriveService.Scope.DriveReadonly,   // view files and documents on your drive
                                             DriveService.Scope.DriveScripts };  // modify your app scripts

            string query = String.Format("{0}={1};{2}={3};{4}={5};{6}={7};",
                                        cb.Server, pd.Server,
                                        cb.Username, pd.Username,
                                        cb.Password, pd.Password,
                                        cb.Database, pd.Database);


            mysql = new MySqlConnection(query);
            if(mysql == null)
            {
                Console.WriteLine("Konekcija na bazu podatak nije uspjesna!");
                return;
            }

            try
            {
                command = mysql.CreateCommand();
                mysql.Open();
                command.CommandText = @"CREATE TABLE columbia.test3(id INT(9) NOT NULL AUTO_INCREMENT,
                                        valid SMALLINT(1) DEFAULT 1,
                                        name VARCHAR(64) DEFAULT 'filename.ext',
                                        size INT(15) DEFAULT 0,
                                        hash VARCHAR(64) DEFAULT 'MD5',
                                        fileid VARCHAR(64) DEFAULT 'file id',
                                        url VARCHAR(256) DEFAULT 'https://...',                                        
                                        PRIMARY KEY (id))";
                command.ExecuteNonQuery();
                Console.WriteLine("Tabela napraavljena");
                mysql.Close();

                

                service = GDriveAccount.Authenticate("columbia-state@columbia-state.iam.gserviceaccount.com", "Columbia State-99db1bd2a00e.json", scopes);

                if (service == null)
                {
                    Console.WriteLine("Authentication error");
                    Console.ReadLine();
                }

                DriveDir(service, "0Byi5ne7d961QVS1XOGlPaTRKc28", dirPath);
            }
            catch (Exception)
            {
                Console.WriteLine("Greska u upitu!");
            }
            
        }
    }
}

using Google.Apis.Drive.v2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Apis.Drive.v2.Data;

namespace Test_Console
{
    class Program
    {

        public static void PrintParents(DriveService service, String fileId)
        {
            ParentsResource.ListRequest request = service.Parents.List(fileId);

            try
            {
                ParentList parents = request.Execute();

                foreach (ParentReference parent in parents.Items)
                {
                    Console.WriteLine("File Id: " + parent.Id);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }

        static void DriveDir(DriveService service, string folderId)
        {
            if (service == null)
            {
                Console.WriteLine("Authentication error");
                Console.ReadLine();
            }

            try
            {
                ChildrenResource.ListRequest request1 = service.Children.List(folderId);
                request1.MaxResults = 1000;
                List<File> files = new List<File>();

                do
                {
                    try
                    {
                        ChildList children = request1.Execute();

                        foreach (ChildReference child in children.Items)
                        {                         
                            File file = service.Files.Get(child.Id).Execute();
                            
                            if (file.MimeType == "application/vnd.google-apps.folder")
                            {
                                Console.WriteLine("DIR:\t{0}", file.Title);
                                DriveDir(service, file.Id); 
                            }
                            else
                            {
                                //files.Add(file);
                                Console.WriteLine("FILE:\t{0}", file.Title);
                            }
                                

                        }
                        request1.PageToken = children.NextPageToken;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("An error occurred: " + e.Message);
                        request1.PageToken = null;
                    }
                } while (!String.IsNullOrEmpty(request1.PageToken));
            }
            catch (Exception ex)
            {
            }
        }

        static void Main(string[] args)
        {
            //Google Drive scopes Documentation:   https://developers.google.com/drive/web/scopes
            string[] scopes = new string[] { DriveService.Scope.Drive,  // view and manage your files and documents
                                             DriveService.Scope.DriveAppdata,  // view and manage its own configuration data
                                             DriveService.Scope.DriveAppsReadonly,   // view your drive apps
                                             DriveService.Scope.DriveFile,   // view and manage files created by this app
                                             DriveService.Scope.DriveMetadataReadonly,   // view metadata for files
                                             DriveService.Scope.DriveReadonly,   // view files and documents on your drive
                                             DriveService.Scope.DriveScripts };  // modify your app scripts

            DriveService service = GDriveAccount.Authenticate("columbia-state@columbia-state.iam.gserviceaccount.com", "Columbia State-99db1bd2a00e.json", scopes);

            if (service == null)
            {
                Console.WriteLine("Authentication error");
                Console.ReadLine();
            }

            DriveDir(service, "0Byi5ne7d961QVS1XOGlPaTRKc28");

            try
            {
                ChildrenResource.ListRequest request1 = service.Children.List("0Byi5ne7d961QVS1XOGlPaTRKc28");
                int j = 1;
                request1.MaxResults = 1000;
                List<string> folders = new List<string>();
                List<string> files = new List<string>();
                do
                {
                    try
                    {
                        ChildList children = request1.Execute();
                        
                        foreach (ChildReference child in children.Items)
                        {
                            //Console.WriteLine("{0} File Id: {1}", j, child.Id);
                            File file = service.Files.Get(child.Id).Execute();
                            if (file.MimeType == "application/vnd.google-apps.folder")
                                folders.Add(file.Title);
                            else
                                files.Add(file.Title);

                            //Console.WriteLine("Title: {0} - MIME type: {1}", file.Title, file.MimeType);
                            //Console.WriteLine();
                            //j++;
                            
                        }
                        request1.PageToken = children.NextPageToken;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("An error occurred: " + e.Message);
                        request1.PageToken = null;
                    }
                } while (!String.IsNullOrEmpty(request1.PageToken));

                foreach (string dir in  folders)
                {
                    Console.WriteLine(dir);
                }

                // Listing files with search.  
                // This searches for a directory with the name DiamtoSample
                string Q = "title = 'Files' and mimeType = 'application/vnd.google-apps.folder'";
                //string Q = "mimeType = 'application/vnd.google-apps.folder'";
                IList<File> _Files = GoogleDrive.GetFiles(service, null);
                
                foreach (File item in _Files)
                {
                    Console.WriteLine(item.Title + " " + item.MimeType);
                }

                // If there isn't a directory with this name lets create one.
                if (_Files.Count == 0)
                {
                    _Files.Add(GoogleDrive.createDirectory(service, "Files1", "Files1", "root"));
                }

                // We should have a directory now because we either had it to begin with or we just created one.
                if (_Files.Count != 0)
                {

                    // This is the ID of the directory 
                    string directoryId = _Files[0].Id;

                    //Upload a file
                    //File newFile = DaimtoGoogleDriveHelper.uploadFile(service, @"c:\GoogleDevelop\dummyUploadFile.txt", directoryId);
                    File newFile = GoogleDrive.uploadFile(service, @"c:\Games\gtasamp.md5", directoryId);
                    // Update The file
                    //File UpdatedFile = DaimtoGoogleDriveHelper.updateFile(service, @"c:\GoogleDevelop\dummyUploadFile.txt", directoryId, newFile.Id);
                    File UpdatedFile = GoogleDrive.updateFile(service, @"c:\Games\gtasamp.md5", directoryId, newFile.Id);
                    // Download the file
                    GoogleDrive.downloadFile(service, newFile, @"C:\Games\download.txt");
                    // delete The file
                    FilesResource.DeleteRequest request = service.Files.Delete(newFile.Id);
                    request.Execute();
                }

                // Getting a list of ALL a users Files (This could take a while.)
                _Files = GoogleDrive.GetFiles(service, null);

                foreach (File item in _Files)
                {
                    Console.WriteLine(item.Title + " " + item.MimeType);
                }
            }
            catch (Exception ex)
            {

                int i = 1;
            }

            Console.ReadLine();


        }
    }
}

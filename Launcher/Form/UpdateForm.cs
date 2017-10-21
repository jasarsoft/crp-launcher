using Google.Apis.Auth.OAuth2;
using Google.Apis.Download;
using Google.Apis.Drive.v2;
using Google.Apis.Util.Store;
using Google.Apis.Services;

using Syncfusion.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Jasarsoft.Columbia.Library;

using GoogleFile = Google.Apis.Drive.v2.Data.File;
using System.Collections;
using Google.Apis.Drive.v2.Data;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Jasarsoft.Columbia.Launcher
{
    public partial class UpdateForm : Syncfusion.Windows.Forms.MetroForm
    {
        private int number;
        private double size;
        private ErrorResult errorResult;

        private enum ErrorResult
        {
            None,
            Missed,
            Network,
            Service,
            Download
        };

        public UpdateForm()
        {
            InitializeComponent();

            this.progressOne.Value = 0;
            this.progressAll.Value = 0;

            this.labelValue.Text = String.Empty;
            this.labelName.Text = "Ažuriranje æe uskoro poèeti...";
        }

        private void UpdateForm_Shown(object sender, EventArgs e)
        {
            this.progressOne.Maximum = 100;
            this.progressAll.Maximum = Launcher.Name.Length - 1;

            Thread thread = new Thread(() =>
            {
                Network net = new Network();
                GoogleApi api = new GoogleApi();
                
                Thread.Sleep(1000);
                errorResult = ErrorResult.None;
                
                DriveService service = Authentication.AuthenticateServiceAccount(api.Email, api.Key);
                if (service == null) errorResult = ErrorResult.Service;

                for (int i = 0; i < Launcher.Name.Length; i++)
                {
                    if (errorResult != ErrorResult.None) break;

                    this.BeginInvoke((MethodInvoker)delegate
                    {
                        progressOne.Value = 0;
                        progressAll.Value = i;
                        labelValue.Text = String.Empty;
                        
                        if (Launcher.Name[i].Length > 30)
                            labelName.Text = String.Format("Fajl {0}/{1}: {2}", i + 1, Launcher.Name.Length, String.Format("...{0}", Launcher.Name[i].Substring(Launcher.Name[i].Length - 24)));
                        else
                            labelName.Text = String.Format("Fajl {0}/{1}: {2}", i + 1, Launcher.Name.Length, Launcher.Name[i]);
                    });

                    bool exist = System.IO.File.Exists(Launcher.Name[i]);

                    if (!exist || Launcher.Valid[i] && HashFile.GetMD5(Launcher.Name[i]) != Launcher.Hash[i])
                    {
                        number = i;
                        if (!net.Available())
                        {
                            errorResult = ErrorResult.Network;
                            break;
                        }
   
                        string path = Path.GetDirectoryName(Launcher.Name[i]);
                        if (!Directory.Exists(path)) Directory.CreateDirectory(path);

                        if (Launcher.Size[number] > 1048576)
                            size = Launcher.Size[number] / 1048576.0;
                        else
                            size = Launcher.Size[number] / 1024.0;

                        Uri address = new Uri(String.Format("https://drive.google.com/uc?export=download&id={0}", Launcher.Link[i]));

                        using (WebClient client = new WebClient())
                        {
                            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
                            //client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted);

                            client.DownloadFileAsync(address, Launcher.Name[i]);
                            while (client.IsBusy) Thread.Sleep(500);
                        }

                        if (HashFile.GetMD5(Launcher.Name[i]) == Launcher.Hash[i]) continue;


                        //google drive api download
                        var request = service.Files.Get(Launcher.Link[i]);
                        //GoogleFile file = service.Files.Get(Launcher.Link[i]).Execute();

                        if (Launcher.Size[i] > 1048576)
                        {
                            request.MediaDownloader.ChunkSize = 1024 * 512;
                        } 
                        else
                        {
                            request.MediaDownloader.ChunkSize = 1024 * 4;
                        }

                        using (FileStream fs = new FileStream(Launcher.Name[i], FileMode.Create, FileAccess.Write))
                        {
                            request.MediaDownloader.ProgressChanged += (IDownloadProgress progress) =>
                            {
                                switch (progress.Status)
                                {
                                    case DownloadStatus.Downloading:
                                    {
                                        this.BeginInvoke((MethodInvoker)delegate
                                        {
                                            //double bytesIn = double.Parse(progress.BytesDownloaded.ToString());
                                            //double totalBytes = double.Parse(Launcher.Size[i].ToString());
                                            //double percentage = bytesIn / totalBytes * 100;
                                            //progressOne.Value = int.Parse(Math.Truncate(percentage).ToString());
                                            progressOne.Value = (int)(((double)progress.BytesDownloaded / Launcher.Size[i]) * 100);

                                            if (Launcher.Size[i] > 1048576)
                                                labelValue.Text = String.Format("{0:0.00}/{1:0.00} MB", progress.BytesDownloaded / 1048576.0, size);
                                            else
                                                labelValue.Text = String.Format("{0:0.00}/{1:0.00} KB", progress.BytesDownloaded / 1024.0, size);

                                            //if (Launcher.Size[i] < 1048576) //1MB = 1B * 1024 * 1024 = 1038576 B
                                            //    labelValue.Text = String.Format("{0:0.00}/{1:0.00} KB", Math.Truncate((bytesIn / 1024) * 100) / 100, Math.Truncate((totalBytes / 1024) * 100) / 100);
                                            //else
                                            //    labelValue.Text = String.Format("{0:0.00}/{1:0.00} MB", Math.Truncate((bytesIn / 1048576) * 100) / 100, Math.Truncate((totalBytes / 1048576) * 100) / 100);


                                            //////double bytesIn = double.Parse(progress.BytesDownloaded.ToString());
                                            //////double totalBytes = double.Parse(Launcher.Size[number].ToString());
                                            //////double percentage = bytesIn / totalBytes * 100;
                                            ////int value = (int)((progress.BytesDownloaded / Launcher.Size[number]) * 100);
                                            ////progressOne.Value = value;

                                            //if (Launcher.Size[number] < 1048576) //1MB = 1B * 1024 * 1024 = 1038576 B
                                            //    labelValue.Text = String.Format("{0}/{1} KB", (progress.BytesDownloaded / 1024), Launcher.Size[i] / 1024);
                                            //else
                                            //    labelValue.Text = String.Format("{0}/{1} MB", (progress.BytesDownloaded / 1048576), Launcher.Size[i] / 1048576);


                                            //double bytesIn = double.Parse(progress.BytesDownloaded.ToString());
                                            //double totalBytes = double.Parse(Launcher.Size[number].ToString());
                                            //double percentage = bytesIn / totalBytes * 100;
                                            //progressOne.Value = int.Parse(Math.Truncate(percentage).ToString());

                                            ////if (Launcher.Size[number] < 1048576) //1MB = 1B * 1024 * 1024 = 1038576 B
                                            ////    labelValue.Text = String.Format("{0:0.00}/{1:0.00} KB", Math.Truncate((bytesIn / 1024) * 100) / 100, Math.Truncate((totalBytes / 1024) * 100) / 100);
                                            ////else
                                            ////    labelValue.Text = String.Format("{0:0.00}/{1:0.00} MB", Math.Truncate((bytesIn / 1048576) * 100) / 100, Math.Truncate((totalBytes / 1048576) * 100) / 100);
                                        });

                                        if (Launcher.Size[i] > 1048576)
                                            request.MediaDownloader.ChunkSize += 1024 * 16;
                                        else
                                            request.MediaDownloader.ChunkSize += 1024 * 2;                                            

                                        break;
                                    }
                                    case DownloadStatus.Completed:
                                    {
                                        this.BeginInvoke((MethodInvoker)delegate
                                        {
                                            progressOne.Value = 100;
                                        });
                                        Thread.Sleep(100);
                                        break;
                                    }
                                    case DownloadStatus.Failed:
                                    {
                                        if (Launcher.Size[i] > 0) errorResult = ErrorResult.Download;
                                        break;
                                    }
                                }
                            };
                            request.Download(fs);
                        }

                        if (HashFile.GetMD5(Launcher.Name[i]) != Launcher.Hash[i]) errorResult = ErrorResult.Download;



                        //using (WebClient client = new WebClient())
                        //{
                        //    client.if (HashFile.GetMD5(Launcher.Name[i]) != Launcher.Hash[i]) errorResult = ErrorResult.Download; += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
                        //    client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted);

                        //    string path = Path.GetDirectoryName(Launcher.Name[i]);
                        //    if (!Directory.Exists(path)) Directory.CreateDirectory(path);

                        //    if (!net.Available())
                        //    {
                        //        errorResult = ErrorResult.Network;
                        //        break;
                        //    }

                        //    client.DownloadFileAsync(address, filename);
                        //    while (client.IsBusy) Thread.Sleep(1000);
                        //}
                        //address = String.Format("https://drive.google.com/uc?export=download&id={0}", Launcher.Link[i]);

                        //using (WebClient client = new WebClient())
                        //{
                        //    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
                        //    client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted);

                        //    string path = Path.GetDirectoryName(Launcher.Name[i]);
                        //    if (!Directory.Exists(path)) Directory.CreateDirectory(path);

                        //    if (!net.Available())
                        //    {
                        //        errorResult = ErrorResult.Network;
                        //        thread.Abort();
                        //        break;
                        //    }

                        //    client.DownloadFileAsync(new Uri(address), Launcher.Name[i]);
                        //    while (client.IsBusy) Thread.Sleep(1000);
                        //}

                        //if (HashFile.GetMD5(Launcher.Name[i]) != Launcher.Hash[i])
                        //{
                        //    errorResult = ErrorResult.Download;
                        //}
                    }
                    else
                    {
                        this.BeginInvoke((MethodInvoker)delegate
                        {
                            progressOne.Value = 100;
                        });
                        Thread.Sleep(100);
                    }
                }

                this.BeginInvoke((MethodInvoker)delegate
                {
                    this.Hide();

                    string text;
                    MessageTitle title = new MessageTitle();

                    if (errorResult == ErrorResult.None)
                    {
                        text = "Ažuriranje moda Columbia State je uspješno završeno.";
                        MessageBoxAdv.Show(text, title.InfoMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (errorResult == ErrorResult.Network)
                    {
                        text = "Vaša internet konekcija ne radi ili je prekinuta.";
                        MessageBoxAdv.Show(text, title.WarningMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (errorResult == ErrorResult.Download)
                    {
                        text = String.Format("Došlo je do pogreške prilikom ažuriranja na fajlu: {0}", Path.GetFileName(Launcher.Name[number]));
                        MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    //GC.Collect();
                    this.Close();
                });
            });


            thread.Priority = ThreadPriority.Lowest;
            thread.IsBackground = true;
            thread.Start();
        }

        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                progressOne.Value = (int)(((double)e.BytesReceived / Launcher.Size[number]) * 100);

                if (Launcher.Size[number] > 1048576)
                    labelValue.Text = String.Format("{0:0.00}/{1:0.00} MB", e.BytesReceived / 1048576.0, size);
                else
                    labelValue.Text = String.Format("{0:0.00}/{1:0.00} KB", e.BytesReceived / 1024.0, size);

                //double bytesIn = double.Parse(e.BytesReceived.ToString());
                //double totalBytes = double.Parse(Launcher.Size[number].ToString());
                //double percentage = bytesIn / totalBytes * 100;
                //progressOne.Value = int.Parse(Math.Truncate(percentage).ToString());

                //if (Launcher.Size[number] < 1048576) //1MB = 1B * 1024 * 1024 = 1038576 B
                //    labelValue.Text = String.Format("{0:0.00}/{1:0.00} KB", Math.Truncate((bytesIn / 1024) * 100) / 100, Math.Truncate((totalBytes / 1024) * 100) / 100);
                //else
                //    labelValue.Text = String.Format("{0:0.00}/{1:0.00} MB", Math.Truncate((bytesIn / 1048576) * 100) / 100, Math.Truncate((totalBytes / 1048576) * 100) / 100);
            });
        }

        private void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            int i = number;

            if (HashFile.GetMD5(Launcher.Name[i]) != Launcher.Hash[i])
            {
                errorResult = ErrorResult.Download;
            }
        }



        async Task DownloadFile(DriveService service, string fileName, string url)
        {
            var downloader = new MediaDownloader(service);
            downloader.ChunkSize = 1024 * 256;
            // add a delegate for the progress changed event for writing to console on changes
            downloader.ProgressChanged += Download_ProgressChanged;

            
            using (var fileStream = new System.IO.FileStream(fileName, System.IO.FileMode.Create, System.IO.FileAccess.Write))
            {
                var progress = await downloader.DownloadAsync(url, fileStream);
                
                if (progress.Status == DownloadStatus.Completed)
                {
                    MessageBox.Show("compete");
                }
                else
                {
                    string text = String.Format("Download {0} was interpreted in the middle. Only {1} were downloaded.",fileName, progress.BytesDownloaded);
                    MessageBox.Show(text);
                }
            }
        }
        private void Download_ProgressChanged(IDownloadProgress obj)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                double bytesIn = double.Parse(obj.BytesDownloaded.ToString());
                double totalBytes = double.Parse(Launcher.Size[number].ToString());
                double percentage = bytesIn / totalBytes * 100;
                progressOne.Value = int.Parse(Math.Truncate(percentage).ToString());

                if (Launcher.Size[number] < 1048576) //1MB = 1B * 1024 * 1024 = 1038576 B
                    labelValue.Text = String.Format("{0:0.00}/{1:0.00} KB", Math.Truncate((bytesIn / 1024) * 100) / 100, Math.Truncate((totalBytes / 1024) * 100) / 100);
                else
                    labelValue.Text = String.Format("{0:0.00}/{1:0.00} MB", Math.Truncate((bytesIn / 1048576) * 100) / 100, Math.Truncate((totalBytes / 1048576) * 100) / 100);
            });
        } 


        private static void UploadFile(DriveService service)
        {
            GoogleFile body = new GoogleFile();
            body.Title = "test upload";
            body.Description = "test upload";
            body.MimeType = "application/vnd.ms-excel";


            // GoogleFile's content.
            byte[] byteArray = System.IO.File.ReadAllBytes(@"C:\Users\Jasarsoft\Google Drive\Private\Expense\Boravak - Mostar.xlsx");
            MemoryStream stream = new MemoryStream(byteArray);
            try
            {
                FilesResource.InsertMediaUpload request = service.Files.Insert(body, stream, "application/vnd.google-apps.spreadsheet");
                request.Upload();

                GoogleFile file = request.ResponseBody;

                // Uncomment the following line to print the GoogleFile ID.
                // Console.WriteLine("GoogleFile ID: " + file.Id);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                //Console.WriteLine("An error occurred: " + e.Message);
            }
        }


        //private void workerUpdate_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    string address;
        //    Network net = new Network();

        //    Thread.Sleep(1000);
        //    errorResult = ErrorResult.None;

        //    for (int i = 0; i < Launcher.Name.Length; i++)
        //    {
        //        this.number = i;
        //        workerUpdate.ReportProgress(i);
        //        if (errorResult == ErrorResult.Download) return;

        //        if (Launcher.Valid[i])
        //            if (HashFile.GetMD5(Launcher.Name[i]) != Launcher.Hash[i])
        //            {
        //                address = String.Format("https://drive.google.com/uc?export=download&id={0}", Launcher.Link[i]);

        //                using (WebClient client = new WebClient())
        //                {
        //                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
        //                    client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted);

        //                    string path = Path.GetDirectoryName(Launcher.Name[i]);
        //                    if (!Directory.Exists(path)) Directory.CreateDirectory(path);

        //                    if (!net.Available())
        //                    {
        //                        errorResult = ErrorResult.Network;
        //                        return;
        //                    }

        //                    client.DownloadFileAsync(new Uri(address), Launcher.Name[i]);
        //                    while (client.IsBusy) Thread.Sleep(1000);
        //                }
        //            }
        //    }
        //}

        //private void workerUpdate_ProgressChanged(object sender, ProgressChangedEventArgs e)
        //{
        //    progressOne.Value = 100;
        //    progressAll.Value = e.ProgressPercentage;
        //    labelValue.Text = String.Empty;
        //    labelName.Text = String.Format("Fajl {0}/{1}: {2}", number + 1, Launcher.Name.Length, Launcher.Name[number]);
        //}

        //private void workerUpdate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    MessageBox.Show("zavrseno\n" + errorResult.ToString());
        //    this.Close();
        //}
    }
}
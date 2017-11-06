using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Text;
using System.Windows.Forms;
using Syncfusion.Windows.Forms;
using System.Net;
using System.IO;
using Google.Apis.Download;
using Google.Apis.Drive.v2;
using GoogleFile = Google.Apis.Drive.v2.Data.File;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;

namespace Jasarsoft.Columbia
{
    public partial class DownloadForm : Syncfusion.Windows.Forms.MetroForm
    {
        private int value;
        private int number;
        private bool stream;
        private double size;
        private List<int> id;
        private ErrorResult errorResult;

        delegate void ProgressSet(long bytesDownload);

        enum ErrorResult
        {
            None,
            Service,
            Network,
            Download
        };
        
        public DownloadForm()
        {
            InitializeComponent();

            this.value = 0;
            this.number = 0;
            this.stream = false;
            this.id = new List<int>();

            this.progressOne.Value = 0;
            this.progressAll.Value = 0;

            this.labelValue.Text = String.Empty;
            this.labelName.Text = "Ažuriranje æe uskoro poèeti...";

            this.DialogResult = System.Windows.Forms.DialogResult.Abort;
        }

        public DownloadForm(string task)
        {

        }

        public DownloadForm(bool stream)
        {
            InitializeComponent();

            this.value = 0;
            this.number = 0;
            this.stream = stream;
            this.id = new List<int>();

            this.progressOne.Value = 0;
            this.progressAll.Value = 0;

            this.labelValue.Text = String.Empty;
            this.labelName.Text = "Ažuriranje æe uskoro poèeti...";

            this.DialogResult = System.Windows.Forms.DialogResult.Abort;
        }


        public List<int> Id
        {
            get { return this.id; }
            set { this.id = value; }
        }


        //private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        //{
        //    this.BeginInvoke((MethodInvoker)delegate
        //    {
        //        double bytesIn = double.Parse(e.BytesReceived.ToString());
        //        double totalBytes = double.Parse(Launcher.Size[this.id[number]].ToString());
        //        double percentage = bytesIn / totalBytes * 100;
        //        progressOne.Value = int.Parse(Math.Truncate(percentage).ToString());

        //        int temp = number * 100;
        //        progressAll.Value = progressOne.Value + temp;

        //        labelName.Text = String.Format("Fajl {0}/{1}: {2}", number + 1, this.id.Count, Launcher.Name[this.id[number]]);
        //        if (Launcher.Size[this.id[number]] < 1048576) //1MB = 1B * 1024 * 1024 = 1038576 B
        //            labelValue.Text = String.Format("{0:0.00}/{1:0.00} KB", Math.Truncate((bytesIn / 1024) * 100) / 100, Math.Truncate((totalBytes / 1024) * 100) / 100);
        //        else
        //            labelValue.Text = String.Format("{0:0.00}/{1:0.00} MB", Math.Truncate((bytesIn / 1048576) * 100) / 100, Math.Truncate((totalBytes / 1048576) * 100) / 100);
        //    });
        //}

        //private void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        //{
        //    if (HashFile.GetMD5(Launcher.Name[this.id[number]]) != Launcher.Hash[this.id[number]])
        //    {
        //        this.wrong++;
        //    }
        //}

        private const int KB = 0x400;
        private const int DownloadChunkSize = 256 * KB;

        private Thread demoThread = null;


        

        /*private async Task Run()
        {
            DriveService service = GDriveAccount.Authenticate("columbia-state@columbia-state.iam.gserviceaccount.com", "Columbia State-99db1bd2a00e.json", new string[] { DriveService.Scope.DriveReadonly, DriveService.Scope.DriveMetadataReadonly });
            for (int i = 0; i < this.id.Count; i++)
            {
                await DownloadFile(service, Launcher.Url[number]);
            }
        }*/


        private void DownloadForm_Shown(object sender, EventArgs e)
        {
            this.progressOne.Maximum = 100;
            this.progressAll.Maximum = 100 * id.Count;

            Thread thread = new Thread(() =>
            {
                Network net = new Network();
                GoogleApi api = new GoogleApi();
                
                Thread.Sleep(1000);
                errorResult = ErrorResult.None;
                List<FileStream> fileStream = new List<FileStream>();
                
                this.BeginInvoke((MethodInvoker)delegate
                {
                    labelName.Text = "Spajanje na servis za preuzimanje...";                    
                });

                DriveService service = new GDriveAccount().Authenticate();
                if (service == null) errorResult = ErrorResult.Service;

                for (int i = 0; i < this.id.Count; i++)
                {
                    if (errorResult != ErrorResult.None) break;

                    value = i * 100;
                    number = this.id[i];
                    
                    if (!net.Available())
                    {
                        errorResult = ErrorResult.Network;
                        break;
                    }

                    this.BeginInvoke((MethodInvoker)delegate
                    {
                        progressOne.Value = 0;
                        progressAll.Value = value;
                        labelValue.Text = String.Empty;

                        if (Launcher.Name[number].Length > 30)
                            labelName.Text = String.Format("Fajl {0}/{1}: {2}", i + 1, this.id.Count, String.Format("...{0}", Launcher.Name[number].Substring(Launcher.Name[number].Length - 24)));
                        else
                            labelName.Text = String.Format("Fajl {0}/{1}: {2}", i + 1, this.id.Count, Launcher.Name[number]);
                    });

                    string path = Path.GetDirectoryName(Launcher.Name[number]);
                    if (!Directory.Exists(path)) Directory.CreateDirectory(path);

                    if (Launcher.Size[number] > 1048576)
                        size = Launcher.Size[number] / 1048576.0;
                    else
                        size = Launcher.Size[number] / 1024.0;
                  
                    Uri address = new Uri(String.Format("https://drive.google.com/uc?export=download&id={0}", Launcher.Link[number]));

                    /*using (WebClient client = new WebClient())
                    {
                        client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
                        //client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted);

                        client.DownloadFileAsync(address, Launcher.Name[number]);
                        while (client.IsBusy) Thread.Sleep(1000);
                    }

                    if (HashFile.GetMD5(Launcher.Name[number]) == Launcher.Hash[number])
                    {
                        if (stream)
                        {
                            fileStream.Clear();
                            for (int j = 0; j <= i; j++) fileStream.Add(new FileStream(Launcher.Name[number], FileMode.Open, FileAccess.Read, FileShare.Read));
                        }

                        continue;
                    }*/
                        

                    var request = service.Files.Get(Launcher.Link[number]);
                    
                    if (Launcher.Size[number] > 1048576)
                        request.MediaDownloader.ChunkSize = 1024 * 512;
                    else
                        request.MediaDownloader.ChunkSize = 1024 * 4;

                    //this.BeginInvoke((MethodInvoker)delegate
                    //{
                    //    progressOne.Value = 0;
                    //    progressAll.Value = value;
                    //    labelValue.Text = String.Empty;

                    //    if (Launcher.Name[number].Length > 30)
                    //        labelName.Text = String.Format("Fajl {0}/{1}: {2}", i + 1, this.id.Count, String.Format("...{0}", Launcher.Name[number].Substring(Launcher.Name[number].Length - 24)));
                    //    else
                    //        labelName.Text = String.Format("Fajl {0}/{1}: {2}", i + 1, this.id.Count, Launcher.Name[number]);
                    //});

                    using (FileStream fs = new FileStream(Launcher.Name[number], FileMode.Create, FileAccess.Write))
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
                                        //double totalBytes = double.Parse(Launcher.Size[number].ToString());
                                        //double percentage = bytesIn / totalBytes * 100;
                                        //progressOne.Value = int.Parse(Math.Truncate(percentage).ToString());

                                        progressOne.Value = (int)(((double)progress.BytesDownloaded / Launcher.Size[number]) * 100);
                                        progressAll.Value = progressOne.Value + value;

                                        if (Launcher.Size[number] > 1048576) //1MB = 1B * 1024 * 1024 = 1038576 B
                                        {
                                            request.MediaDownloader.ChunkSize += 1024;
                                            labelValue.Text = String.Format("{0:0.00}/{1:0.00} MB", progress.BytesDownloaded / 1048576.0, size);
                                        }   
                                        else
                                        {
                                            request.MediaDownloader.ChunkSize += 1024;
                                            labelValue.Text = String.Format("{0:0.00}/{1:0.00} KB", progress.BytesDownloaded / 1024.0, size);
                                        }  
                                    });

                                    break;
                                }
                                case DownloadStatus.Completed:
                                {
                                    this.BeginInvoke((MethodInvoker)delegate
                                    {
                                        progressOne.Value = 100;
                                        progressAll.Value = progressOne.Value + value;
                                    });
                                    Thread.Sleep(100);
                                    break;
                                }
                                case DownloadStatus.Failed:
                                {
                                    if (Launcher.Size[number] > 0) errorResult = ErrorResult.Download;
                                    break;
                                }
                            }
                        };

                        request.Download(fs);
                    }

                    if (HashFile.GetMD5(Launcher.Name[number]) != Launcher.Hash[number].ToUpper())
                    {
                        errorResult = ErrorResult.Download;
                        break;
                    }

                    if (stream)
                    {
                        fileStream.Clear();
                        for (int j = 0; j <= i; j++) fileStream.Add(new FileStream(Launcher.Name[number], FileMode.Open, FileAccess.Read, FileShare.Read));
                    } 

                    //number = i;
                    //fileName = Launcher.Name[this.id[i]];
                    //address = new Uri(String.Format("https://drive.google.com/uc?export=download&confirm=iBg2&id={0}", Launcher.Link[this.id[i]]));
                    ////address = new Uri(String.Format("https://drive.google.com/uc?id={0}", Launcher.Link[this.id[i]]));

                    //using (WebClient client = new WebClient())
                    //{
                    //    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
                    //    client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted);

                    //    if (!Directory.Exists(Path.GetDirectoryName(fileName))) Directory.CreateDirectory(Path.GetDirectoryName(fileName));

                    //    if (!net.Available())
                    //    {
                    //        errorResult = true;
                    //        break;
                    //    }
                            
                    //    client.DownloadFileAsync(address, fileName);
                    //    while (client.IsBusy) Thread.Sleep(1000);

                        //fileStream.Clear();
                        //for (int j = 0; j <= i; j++) fileStream.Add(new FileStream(Launcher.Name[this.id[i]], FileMode.Open, FileAccess.Read, FileShare.Read));
                   // }
                }

                this.BeginInvoke((MethodInvoker)delegate
                {
                    this.Hide();

                    string text = String.Empty;
                    MessageTitle title = new MessageTitle();

                    if (errorResult == ErrorResult.None)
                    {
                        text = String.Format("Ažuriranje {0} fajla/ova je uspješno izvršeno, klikni za nastavk.", this.id.Count);
                        MessageBoxAdv.Show(text, title.InfoMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    else if (errorResult == ErrorResult.Network)
                    {
                        text = "Došlo je do prekida internet konekcije, ažuriranje je prekinuto.";
                        MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                    }
                    else if (errorResult == ErrorResult.Service)
                    {
                        text = "Autentifikacija sa fajlovima nije validna, ažuriranje je prekinuto.";
                        MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                    }
                    else if (errorResult == ErrorResult.Download)
                    {
                        text = String.Format("Došlo je do pogreške na fajlu '{0}' tokom ažuriranja.", Path.GetFileName(Launcher.Name[number]));
                        MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                    }

                    //if (this.wrong > 0)
                    //{
                    //    MessageTitle title = new MessageTitle();
                    //    string text = String.Format("Došlo je do pogreške ukupno na {0} fajla/ova tokom ažuriranja.", this.wrong);
                    //    MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                    //}
                    //else if (errorResult)
                    //{
                    //    MessageTitle title = new MessageTitle();
                    //    string text = "Došlo je do prekida internet konekcije, ažuriranje je prekinuto.";
                    //    MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    //    this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                    //}
                    //else
                    //    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    
                    //else
                    //{
                    //    text = String.Format("Ažuriranje {0} fajla/ova uspješno je izvršeno!", this.id.Count);
                    //    MessageBoxAdv.Show(text, title.InfoMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}

                    fileStream.Clear();
                    fileStream = null;
                    GC.Collect();
                    this.Close();
                });
            });


            thread.Priority = ThreadPriority.Lowest;
            thread.IsBackground = true;
            thread.Start();
        }

        private async Task Run()
        {
            number = this.id[0];
            DriveService service = new GDriveAccount().Authenticate();

            
            await DownloadFile(service, Launcher.Url[number]);
        }

        private async Task DownloadFile(DriveService service, string url)
        {
            var downloader = new MediaDownloader(service);
            downloader.ChunkSize = DownloadChunkSize;
            // add a delegate for the progress changed event for writing to console on changes
            downloader.ProgressChanged += DownloadProgressChanged1;

            // figure out the right file type base on UploadFileName extension
            var fileName = Launcher.Name[number];

            using (var fileStream = new System.IO.FileStream(fileName,
                System.IO.FileMode.Create, System.IO.FileAccess.Write))
            {
                var progress = await downloader.DownloadAsync(url, fileStream);
                if (progress.Status == DownloadStatus.Completed)
                {
                    //Console.WriteLine(fileName + " was downloaded successfully");
                }
                else
                {
                    progressOne.Value = (int)(((double)progress.BytesDownloaded / Launcher.Size[number]) * 100);
                }
            }
        }

        private void Download_ProgressChanged(IDownloadProgress obj)
        {

            //MessageBox.Show("a");
            progressOne.Value = (int)(((double)obj.BytesDownloaded / Launcher.Size[number]) * 100);

            //this.BeginInvoke((MethodInvoker)delegate
            //{
            //    progressOne.Value = (int)(((double)obj.BytesDownloaded / Launcher.Size[number]) * 100);
            //    progressAll.Value = progressOne.Value + value;

            //    if (Launcher.Size[number] > 1048576) //1MB = 1B * 1024 * 1024 = 1038576 B
            //        labelValue.Text = String.Format("{0:0.00}/{1:0.00} MB", obj.BytesDownloaded / 1048576.0, size);
            //    else
            //        labelValue.Text = String.Format("{0:0.00}/{1:0.00} KB", obj.BytesDownloaded / 1024.0, size);
            //});
        } 


        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                progressOne.Value = (int)(((double)e.BytesReceived / Launcher.Size[number]) * 100);
                progressAll.Value = progressOne.Value + value;

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

        private void ThreadProgressOne(long bytes)
        {
            this.SetProgressOne(bytes);
        }

        private void SetProgressOne(long bytes)
        {
            if (this.progressOne.InvokeRequired)
            {
                ProgressSet p = new ProgressSet(SetProgressOne);
                this.Invoke(p, new object[] { bytes });
            }
            else
            {
                progressOne.Value = (int)(((double)bytes / Launcher.Size[number]) * 100);
            }
        }

        public void DoProcessing(IProgress<int> progress)
        {
            for (int i = 0; i != 100; ++i)
            {
                Thread.Sleep(100); // CPU-bound work
                if (progress != null)
                    progress.Report(i);
            }
        }

        private void DownloadProgressChanged1(IDownloadProgress obj)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                progressOne.Value = (int)(((double)obj.BytesDownloaded / Launcher.Size[number]) * 100);
                

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
    }
}

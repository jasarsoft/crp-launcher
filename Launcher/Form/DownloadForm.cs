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
using System.Resources;
using Jasarsoft.Columbia.Properties;

namespace Jasarsoft.Columbia
{
    public partial class DownloadForm : Syncfusion.Windows.Forms.MetroForm
    {
        private int value;
        private int number;
        private bool stream;
        private double fileSize;
        private List<int> id;
        private int errorNumber;

        private long downloadSize;
        private long downloadTotal;
        private int downloadNumber;
        private bool downloadWork;

        private bool sizeMB;
        
        private ErrorResult errorResult;

        private int fileMissed;
        private int fileUnknown;
        private int fileIncorrect;

        private const int KB = 0x400;
        private const int DownloadChunkSize = 256 * KB;

        DriveService service;
        List<ErrorFile> errorFiles;

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

            this.errorNumber = 0;

            this.downloadSize = 0;
            this.downloadTotal = 0;
            this.downloadNumber = 0;
            this.downloadWork = false;

            this.fileMissed = 0;
            this.fileUnknown = 0;
            this.fileIncorrect = 0;

            this.progressOne.Value = 0;
            this.progressAll.Value = 0;

            this.labelValue.Text = String.Empty;
            this.labelName.Text = "Molimo vas kliknite na Poèni da bih ste zapoèeli process ažuriranja potrebnih datoteka...";

            this.labelError.Text = String.Empty;
            this.labelErrorValue.Text = String.Empty;
            this.labelTotal.Text = String.Empty;
            this.labelTotalValue.Text = String.Empty;

            this.DialogResult = System.Windows.Forms.DialogResult.Abort;
        }


        public List<int> Id
        {
            get { return this.id; }
            set { this.id = value; }
        }


        private void DownloadForm_Shown(object sender, EventArgs e)
        {
            this.progressOne.Maximum = 100;
            this.progressAll.Maximum = 100 * id.Count;

            workerSlide.RunWorkerAsync();

            /*Thread thread = new Thread(() =>
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
                        fileSize = Launcher.Size[number] / 1048576.0;
                    else
                        fileSize = Launcher.Size[number] / 1024.0;
                  
                    Uri address = new Uri(String.Format("https://drive.google.com/uc?export=download&id={0}", Launcher.Link[number]));

                    //using (WebClient client = new WebClient())
                    //{
                    //    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
                    //    //client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted);
                    //
                    //    client.DownloadFileAsync(address, Launcher.Name[number]);
                    //    while (client.IsBusy) Thread.Sleep(1000);
                    //}
                    //
                    //if (HashFile.GetMD5(Launcher.Name[number]) == Launcher.Hash[number])
                    //{
                    //    if (stream)
                    //    {
                    //        fileStream.Clear();
                    //        for (int j = 0; j <= i; j++) fileStream.Add(new FileStream(Launcher.Name[number], FileMode.Open, FileAccess.Read, FileShare.Read));
                    //    }
                    //
                    //    continue;
                    //}
                        

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
                                            labelValue.Text = String.Format("{0:0.00}/{1:0.00} MB", progress.BytesDownloaded / 1048576.0, fileSize);
                                        }   
                                        else
                                        {
                                            request.MediaDownloader.ChunkSize += 1024;
                                            labelValue.Text = String.Format("{0:0.00}/{1:0.00} KB", progress.BytesDownloaded / 1024.0, fileSize);
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
            thread.Start();*/
        }


        private DialogResult MessageErrorInternet()
        {
            MessageTitle title = new MessageTitle();
            string text = "Vaša internet konekcija je nedostupna, provjerite vašu spojenost na internet.\n" +
                          "Trebate biti pravilno spojeni na internet kako bih nastavili sa skidanjem datoteka.\n" +
                          "Da li želite sada ponovo provjeriti vašu dostupnost internet konekcije i nastaviti?";

            return MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
        }

        private DialogResult MessageErrorService()
        {
            MessageTitle title = new MessageTitle();
            string text = "Spajanje na naš servis za preuzimanje datoteka nije trenutno moguæe ostvariti.\n" +
                          "Potrebno je uspješno se spojiti na servis kako bih mogli preuzimati datoteke sa njega.\n" +
                          "Da li želite sada ponovo pokušati se spojiti na naš servis i nastaviti sa preuzimanjem?";

            return MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
        }

        private DialogResult MessageErrorDownload(string file)
        {
            MessageTitle title = new MessageTitle();
            string text = "Skidanje i ažuriranje navedene datoteke nije upotpunosti uspješno izvršeno.\n" +
                          String.Format("Naziv datoteke: {0}\n", file) +
                          "Da li želite ponovo pokušati preuzeti istoimenu datoteku ili ne za nastavak preuzimanja?";

            return MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
        }

        private DialogResult MessageErrorLog()
        {
            MessageTitle title = new MessageTitle();
            string text = "Prilikom skidanja datoteka sa servisa došlo je do pogreške na nekima.\n" +
                          "Da li želite pogledati detaljan izvještaj datoteka koje se nisu ažurirale?";

            return MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
        }

        private DialogResult MessageInfoDownload()
        {
            MessageTitle title = new MessageTitle();
            string text = "Skidanje i ažuriranje datoteka sa download servisa je uspješno izvršeno\n" +
                          "i sada imate potpunu modifikaciju za pristup našem serveru, prijavite se.\n" +
                          String.Format("Ukupno je skinuto {0} datoteka èija je ukupna velièina {1:0.00} MB.", downloadNumber, downloadSize / 1048576.0);

            return MessageBoxAdv.Show(text, title.InfoMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private bool CheckInternet()
        {
            Network net = new Network();
            System.Windows.Forms.DialogResult dialog;

            do
            {
                if (net.Available()) return true;

                //ako internet nije dosptupan ide se na ponavljanje
                //ponavljajuce poruke i provjere interneta
                dialog = MessageErrorInternet();
            } while (dialog == DialogResult.Yes);

            return false;
        }

        private bool CheckService()
        {
            System.Windows.Forms.DialogResult dialog;

            do
            {
                service = new GDriveAccount().Authenticate();
                if (service != null) return true;
                dialog = MessageErrorService();
            } while (dialog == DialogResult.Yes);

            return false;
        }

        private async Task RepeatDownloadFile(DriveService service, string url)
        {
            System.Windows.Forms.DialogResult dialog;

            do
            {
                await DownloadFile(service, url);
                if (HashFile.GetMD5(Launcher.Name[number]) == Launcher.Hash[number].ToUpper())
                {
                    this.downloadNumber++;
                    this.downloadSize += Launcher.Size[number];
                    this.labelTotalValue.Text = String.Format("{0:0.00}/{1:0.00} MB", downloadSize / 1048576.0, downloadTotal / 1048576.0);
                    break;
                }
                this.Hide(); //skrivanje forme radi prikaza poruke
                dialog = MessageErrorDownload(Launcher.Name[number]);
                this.Show(); //pokazivanje forme nakon poruke
                
                if (dialog == DialogResult.No)
                {
                    this.errorFiles.Add(new ErrorFile(++errorNumber, Launcher.Name[number], Launcher.Size[number], "Neispravan"));
                }
                    
            } while (dialog == DialogResult.Yes);
        }

        private void ImageStreamLoad()
        {
            /*for(int i = 1; i < 4; i++)
           {
               string file = String.Format(".\\screenshots\\{0}.png", i);
               using (var stream = new System.IO.FileStream(file, FileMode.Open, FileAccess.Read))
               {
                   Image img = Image.FromStream(stream);
                   imageStreamer1.Images.Add(img);
               }
           }*/


            //WebClient client = new WebClient();

            StringCipher cipher = new StringCipher();

            for (int i = 1; i < 4; i++)
            {
                string address = String.Format("{0}{1}.png", i, cipher.Decrypt("jMMkUnP2v0pfVULgEcH6RJYfa5NVHXRqSJKK0pAfsVZi9YLPfEXWNA8epLcmfo+tiliEsRsWe1zvXo8w32CVmsRLXBERiU/O5C+PZjHReBYDOAZg/Tf12AE7J1oWAm3aAWP//SYdcHW5Pp7qoJBhykVFrCSIMhmB0OHFSCCOBYc="));
                using (var client = new WebClient())
                {
                    Stream stream = client.OpenRead(address);
                    Image img = Image.FromStream(stream);
                    imageStreamerSlide.Images.Add(img);
                    stream.Dispose();
                }
            }
        }

        private async Task Run()
        {
            this.downloadWork = true;
            if (!CheckInternet()) return;
            if (!CheckService()) return;

            this.errorNumber = 0;
            this.downloadSize = 0;
            this.downloadNumber = 0;
            this.errorFiles = new List<ErrorFile>();
            foreach (int id in this.id) downloadTotal += Launcher.Size[id];

            for (int i = 0; i < this.id.Count; i++)
            {
                //if (errorResult != ErrorResult.None) break;

                value = i * 100;
                number = this.id[i];
                if (!downloadWork) break;
                this.labelName.Text = String.Format("{0}/{1}: {2}", i + 1, this.id.Count, Launcher.Name[number]);

                if(errorNumber > 0)
                    this.labelErrorValue.Text = errorNumber.ToString();

                //postavka velicine datoteke u MB ili KB;
                if (Launcher.Size[number] > 1048576)
                {
                    this.sizeMB = true;
                    fileSize = Launcher.Size[number] / 1048576.0;
                }   
                else
                {
                    this.sizeMB = false;
                    fileSize = Launcher.Size[number] / 1024.0;
                }
                    

                //kreiranje direktorija ako nepostoji za trenutnu datoteku;
                string path = Path.GetDirectoryName(Launcher.Name[number]);
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);

                if (!CheckInternet()) return; //provjea internet konekcije prije download-a;
                //await DownloadFile(service, Launcher.Url[number]); //skidanje datoteke;

                //provjera hash vrijednosti skinute datoteke;
                await RepeatDownloadFile(service, Launcher.Url[number]);
                
            }
        }

        private async Task DownloadFile(DriveService service, string url)
        {
            var downloader = new MediaDownloader(service);
            downloader.ChunkSize = DownloadChunkSize;
            // add a delegate for the progress changed event
            downloader.ProgressChanged += Download_ProgressChanged;

            using (var fileStream = new System.IO.FileStream(Launcher.Name[number], FileMode.Create, FileAccess.Write))
            {
                var progress = await downloader.DownloadAsync(url, fileStream);
                if (progress.Status == DownloadStatus.Completed)
                {
                    //this.downloadNumber++;
                    //this.downloadSize += Launcher.Size[number];
                    //this.labelTotalValue.Text = String.Format("{0:0.00}/{1:0.00} MB", downloadSize / 1048576.0, downloadTotal / 1048576.0);

                }
                else if(progress.Status == DownloadStatus.Failed)
                {
                    
                }
            }
        }

        private void Download_ProgressChanged(IDownloadProgress obj)
        {
            progressOne.Invoke(new Action(() => progressOne.Value = (int)(((double)obj.BytesDownloaded / Launcher.Size[number]) * 100)));
            progressAll.Invoke(new Action(() => progressAll.Value = progressOne.Value + value));

            if (sizeMB)
                labelValue.Invoke(new Action(() => labelValue.Text = String.Format("{0:0.00}/{1:0.00} MB", obj.BytesDownloaded / 1048576.0, fileSize)));
            else
                labelValue.Invoke(new Action(() => labelValue.Text = String.Format("{0:0.00}/{1:0.00} KB", obj.BytesDownloaded / 1024.0, fileSize)));
        } 


        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                //double bytesIn = double.Parse(e.BytesReceived.ToString());
                //double totalBytes = double.Parse(Launcher.Size[number].ToString());
                //double percentage = bytesIn / totalBytes * 100;
                //progressOne.Value = int.Parse(Math.Truncate(percentage).ToString());
                progressOne.Value = (int)(((double)e.BytesReceived / Launcher.Size[number]) * 100);
                progressAll.Value = progressOne.Value + value;

                if (Launcher.Size[number] > 1048576)
                    labelValue.Text = String.Format("{0:0.00}/{1:0.00} MB", e.BytesReceived / 1048576.0, fileSize);
                else
                    labelValue.Text = String.Format("{0:0.00}/{1:0.00} KB", e.BytesReceived / 1024.0, fileSize);

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

        

        private async void buttonStart_Click(object sender, EventArgs e)
        {
            if(downloadWork)
            {
                this.downloadWork = false;
            }
            else
            {
                this.labelError.Text = "Ukupno grešaka:";
                this.labelErrorValue.Text = "-";
                this.labelTotal.Text = "Ukupno skinuto:";
                this.labelTotalValue.Text = "-";
                this.buttonStart.Text = "Prekini";
                await Run();
                this.downloadWork = false;
                if(errorNumber > 0)
                {
                    this.DialogResult = DialogResult.Abort;
                    if (MessageErrorLog() == DialogResult.Yes)
                    {
                        this.Hide();
                        FileForm ff = new FileForm(errorFiles);
                        ff.FileMissed = 0;
                        ff.FileUnknown = 0;
                        ff.FileIncorrect = errorNumber;
                        ff.FileTotal = this.Id.Count;
                        
                        ff.ShowDialog();
                        this.Show();
                    }
                    this.Close();
                    return;
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    this.Hide();
                    MessageInfoDownload();
                    this.Show();
                    this.Close();
                }
            }
        }

        private void workerSlide_DoWork(object sender, DoWorkEventArgs e)
        {
            StringCipher sc = new StringCipher();
            string address = sc.Decrypt("ZTGL4X6BtPz1U/42i4Ihos3SBIirLnFWzMAR9LisZgGdwRao/JF8a3OKcC5jeZD45hYcjNdSEBYFyX8qMEDABqFfZcW9L01aLFabHiPuoTAMGPHtihQgTa7sEJoTnbCWKvaBG8EuwFuV61hUKCXqe1qmxNskxfaPc7/S2b0MIho=");
            for (int i = 0; i < Launcher.SlideShow; i++)
            {
                using (var client = new WebClient())
                {
                    Stream stream = client.OpenRead(String.Format("{0}{1}.png", address, i));
                    Image img = Image.FromStream(stream);
                    imageStreamerSlide.Images.Add(img);
                    stream.Dispose();
                }
            }
        }

        private void workerSlide_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.pictureLogo.Hide();
            this.imageStreamerSlide.Show(); 
        }
    }
}

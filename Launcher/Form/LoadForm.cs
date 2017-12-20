using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using Syncfusion.Windows.Forms;
using System.Net.NetworkInformation;
using System.Diagnostics;
using Google.Apis.Download;
using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;
using GoogleFile = Google.Apis.Drive.v2.Data.File;


namespace Jasarsoft.Columbia
{
    public partial class LoadForm : Syncfusion.Windows.Forms.MetroForm
    {
        MainForm mainForm;
        
        List<int> missedFiles;
        List<string> unknownFiles;

        private enum ErrorResult
        {
            None,
            Edit,
            Work,
            Service,
            Network,
            Database,
            Unknown,
            Missed
        };

        public LoadForm()
        {
            InitializeComponent();

            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
            MessageBoxAdv.MetroColorTable.OKButtonBackColor = Color.Firebrick;
            MessageBoxAdv.MetroColorTable.OKButtonForeColor = Color.WhiteSmoke;
            MessageBoxAdv.MetroColorTable.NoButtonBackColor = Color.Firebrick;
            MessageBoxAdv.MetroColorTable.NoButtonForeColor = Color.WhiteSmoke;
            MessageBoxAdv.MetroColorTable.YesButtonBackColor = Color.Firebrick;
            MessageBoxAdv.MetroColorTable.YesButtonForeColor = Color.WhiteSmoke;
            MessageBoxAdv.MetroColorTable.CancelButtonBackColor = Color.Firebrick;
            MessageBoxAdv.MetroColorTable.CancelButtonForeColor = Color.WhiteSmoke;
            MessageBoxAdv.MetroColorTable.BackColor = Color.WhiteSmoke;
            MessageBoxAdv.MetroColorTable.ForeColor = Color.Black;
            MessageBoxAdv.MetroColorTable.BorderColor = Color.Firebrick;
            MessageBoxAdv.MetroColorTable.CaptionForeColor = Color.WhiteSmoke;
            MessageBoxAdv.MetroColorTable.CaptionBarColor = Color.Firebrick;
            MessageBoxAdv.MetroColorTable.CloseButtonColor = Color.WhiteSmoke;
            MessageBoxAdv.MetroColorTable.CloseButtonHoverColor = Color.RoyalBlue;
        }


        private void LoadForm_Shown(object sender, EventArgs e)
        {
            workerLoad.RunWorkerAsync();
        }


        private void workerLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            mainForm = new MainForm();
            e.Result = ErrorResult.None;
#if !DEBUG
            Process[] process = Process.GetProcessesByName("columbia");
            if (process.Length > 1)
            {
                e.Result = ErrorResult.Work;
                return;
            }

            if (Path.GetFileName(Application.ExecutablePath) != "columbia.exe")
            {
                e.Result = ErrorResult.Edit;
                return;
            }
#endif

            Network net = new Network();
            if (!net.Available())
            {
                e.Result = ErrorResult.Network;
                return;
            }
            

            Server s = new Server();
            if (s.Read())
            {
                Launcher.Locked = s.Locked;
                Launcher.Working = s.Working;
                Launcher.SlideShow = s.SlideShow;
                Launcher.Address = s.Address;
                Launcher.Password = s.Password;
                Launcher.Teamspeak = s.Teamspeak;
                Launcher.Website = s.Website;
                Launcher.Forum = s.Forum;
                Launcher.YouTube = s.YouTube;
                Launcher.Facebook = s.Facebook;
            }
            else
            {
                e.Result = ErrorResult.Database;
                return;
            }

            if(s.Working)
            {
                BaseFile bf = new BaseFile();
                if (bf.Read())
                {
                    Launcher.Valid = new bool[bf.Valid.Count];
                    Launcher.Name = new string[bf.Name.Count];
                    Launcher.Size = new long[bf.Size.Count];
                    Launcher.Hash = new string[bf.Hash.Count];
                    Launcher.Link = new string[bf.Link.Count];
                    Launcher.Url = new string[bf.Url.Count];

                    bf.Valid.CopyTo(Launcher.Valid);
                    bf.Name.CopyTo(Launcher.Name);
                    bf.Size.CopyTo(Launcher.Size);
                    bf.Hash.CopyTo(Launcher.Hash);
                    bf.Link.CopyTo(Launcher.Link);
                    bf.Url.CopyTo(Launcher.Url);
                }
                else
                {
                    e.Result = ErrorResult.Database;
                    return;
                }
            }

            DataFile dataFile = new DataFile();
#if !DEBUG
            Library dll = new Library();
            this.unknownFiles = new List<string>();
            dataFile.ReadUnknown(Launcher.Name, dll.Name);
            if (dataFile.UnknownFiles.Count > 0)
            {
                foreach (string unknown in dataFile.UnknownFiles) unknownFiles.Add(unknown);
                e.Result = ErrorResult.Unknown;
                return;
            }
#endif
            this.missedFiles = new List<int>();
            dataFile.ReadMissed(Launcher.Name);
            if (dataFile.MissedFiles.Count > 0)
            {
                
                foreach (int missed in dataFile.MissedFiles)
                {
#if !DEBUG
                    Trace.TraceInformation("workerLoad_DoWork(); Missed file ({0}): {1}", missed, Launcher.Name[missed]);
#endif
                    this.missedFiles.Add(missed);
                }
                    
                e.Result = ErrorResult.Missed;
                return;
            }
        }

        private void workerLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Hide();
            MessageTitle title = new MessageTitle();

            if (e.Result.ToString() == ErrorResult.Work.ToString())
            {
                string text = "Instanca aplikacije Columbia State Launcher-a je veæ pokrenuta.\n" + 
                              "Pokretanje više instanci nije dozvoljeno i ista neæe biti startovana.";

                MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
                return;
            }
            else if(e.Result.ToString() == ErrorResult.Service.ToString())
            {
                string text = "Prijava na servis Columbia State moda nije uspješno izvršena.\n" + 
                              "Pokušajte ponovo ili evidentirajte vašu grešku na forum.";
                MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
            else if (e.Result.ToString() == ErrorResult.Edit.ToString())
            {
                ProcessKiller killer = new ProcessKiller();

                killer.Samp();
                killer.SanAndreas();
                killer.Host();

                string text = "Naziv Columbia State Launcher aplikacije je neovlašteno izmjenjen!\n" +
                              "Svaka neovlaštena izmjena smatra se pokušajem nanoštenja štete istoj.\n" +
                              "Napomena, nažalost aplikacija se iz sigurnostnih razloga neæe pokrenuti.";

                MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Stop);

                Application.Exit();
                return;
            }
            else if (e.Result.ToString() == ErrorResult.Network.ToString())
            {            
                Network net = new Network();
                MessageBoxAdv.Show(net.Error, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
            else if (e.Result.ToString() == ErrorResult.Database.ToString())
            {
                string text = "Konekcija sa bazom podataka je neuspješna.\nKontaktirajte administratora na forumu ili pokušajte ponovo.";
                MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
            else if (e.Result.ToString() == ErrorResult.Unknown.ToString())
            {
                long size = 0;
                foreach(string file in unknownFiles)
                {
                    if(System.IO.File.Exists(file))
                        size += new System.IO.FileInfo(file).Length;
                }

                string message = String.Format("Vaša modifikacija sadrži {0} nepoznatih datoteka, velièine {1:0.00} MB.\n", unknownFiles.Count, size / 1048576.0) +
                                               "Da li želite iste obrisati sada i nastaviti sa uèitavanem launcher-a?\n" +
                                               "Napomena, aplikacija se neæe uèitati dok postoje strane nepredviðene datoteke.";

                if (System.Windows.Forms.DialogResult.Yes == MessageBoxAdv.Show(message, title.WarningMsg, MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    try
                    {
                        foreach (string name in this.unknownFiles) System.IO.File.Delete(name);

                        message = "Nepoznate datoteke su uspješno uklonjene, launcher æe se ponovo uèitati.";
                        MessageBoxAdv.Show(message, title.InfoMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.workerLoad.RunWorkerAsync();
                        return;
                    }
                    catch (Exception)
                    {
                        message = "Nepoznate datoteke nisu uspješno izbrisane, uèinite mehanièki uklanjanje!";
                        MessageBoxAdv.Show(message, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                Application.Exit();
                return;
            }
            else if (e.Result.ToString() == ErrorResult.Missed.ToString())
            {
                long size = 0;
                foreach (int id in missedFiles)
                {
                    if (System.IO.File.Exists(Launcher.Name[id]))
                        size += new System.IO.FileInfo(Launcher.Name[id]).Length;
                }

                string message = String.Format("Vašoj modifikaciji nedostaje {0} datoteka, ukupne velièine {1:0.00} MB.\n", missedFiles.Count, size / 1048576.0) +
                                               "Da li želite iste skinuti sada i nastaviti sa uèitavanem launcher-a?\n" +
                                               "Napomena, aplikacija se neæe uèitati dok sve datoteke ne budu ažurirane.";

                if (System.Windows.Forms.DialogResult.Yes == MessageBoxAdv.Show(message, title.WarningMsg, MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    DownloadForm dw = new DownloadForm();
                    foreach (int index in this.missedFiles) dw.Id.Add(index);
                    
                    if (dw.ShowDialog(this) == System.Windows.Forms.DialogResult.Abort)
                    {
                        message = "Nažalost skidanje novih datoteka nije uspješno izvršeno do kraja.\n" +
                                  "Columbia State Launcher ne može nastaviti sa daljnjim uèitavanjem.\n" +
                                  "Potražiti na forumu upustvo za pogrešku ovog tipa ili evidentirajte istu.";

                        MessageBoxAdv.Show(message, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Process.Start("https://columbia-state.com/");
                        Application.Exit();
                        return;
                    }
                }
                else
                {
                    Application.Exit();
                    return;
                }
            }

            if (Launcher.Working == false)
            {
                string text = "Columbia State Server je trenutno u procesu nadogradnje, pokušajte kasnije!";
                MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);

                Application.Exit();
                return;
            }

            mainForm.Show();
        }

        private void LoadForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ProcessKiller pk = new ProcessKiller();

            //pk.Samp();
            //pk.GtaSa();
            //pk.HostNm();
        }
    }
}

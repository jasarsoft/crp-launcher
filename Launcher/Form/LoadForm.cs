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
using Jasarsoft.Columbia.Library;

namespace Jasarsoft.Columbia.Launcher
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
            Network,
            Database,
            Unknown,
            Missed
        };

        public LoadForm()
        {
            InitializeComponent();

            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
            MessageBoxAdv.MetroColorTable.BackColor = Color.WhiteSmoke;
            MessageBoxAdv.MetroColorTable.ForeColor = Color.FromArgb(52, 52, 52);
            MessageBoxAdv.MetroColorTable.BorderColor = Color.FromArgb(17, 158, 218);
            MessageBoxAdv.MetroColorTable.CaptionForeColor = Color.FromArgb(52, 52, 52);
            MessageBoxAdv.MetroColorTable.CaptionBarColor = Color.FromArgb(17, 158, 218);
        }


        private void LoadForm_Shown(object sender, EventArgs e)
        {
            workerLoad.RunWorkerAsync();
        }

        private void workerLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            mainForm = new MainForm();

            Process[] process = Process.GetProcessesByName("samp-nm");
            if (process.Length > 1)
            {
                e.Result = ErrorResult.Work;
                return;
            }

            //if (Path.GetFileName(Application.ExecutablePath) != "samp-nm.exe")
            //{
            //    e.Result = ErrorResult.Edit;
            //    return;
            //}

            //Process[] hostNm = Process.GetProcessesByName("host-nm");
            //if (hostNm.Length > 0)
            //{
            //    foreach (Process proc in hostNm)
            //    {
            //        do
            //        {
            //            proc.Kill();
            //        } while (proc.HasExited == false);
            //    }
            //}

            //Process.Start("host-nm.exe");

            Network net = new Network();
            if (!net.Available())
            {
                e.Result = ErrorResult.Network;
                return;
            }
            e.Result = ErrorResult.None;


            BaseFile bf = new BaseFile();
            if (bf.Read())
            {
                Launcher.Valid = new bool[bf.Valid.Count];
                Launcher.Name = new string[bf.Name.Count];
                Launcher.Size = new long[bf.Size.Count];
                Launcher.Hash = new string[bf.Hash.Count];
                Launcher.Link = new string[bf.Link.Count];

                bf.Valid.CopyTo(Launcher.Valid);
                bf.Name.CopyTo(Launcher.Name);
                bf.Size.CopyTo(Launcher.Size);
                bf.Hash.CopyTo(Launcher.Hash);
                bf.Link.CopyTo(Launcher.Link);

                e.Result = ErrorResult.None;
            }
            else
            {
                e.Result = ErrorResult.Database;
                return;
            }

            Server s = new Server();
            if (s.Read())
            {
                Launcher.Locked = s.Locked;
                Launcher.Working = s.Working;
                Launcher.Address = s.Address;
                Launcher.Password = s.Password;
                Launcher.Teamspeak = s.Teamspeak;
                Launcher.Website = s.Website;
                Launcher.Forum = s.Forum;
                Launcher.YouTube = s.YouTube;
                Launcher.Facebook = s.Facebook;
                
                e.Result = ErrorResult.None;
            }
            else
            {
                e.Result = ErrorResult.Database;
                return;
            }

            
            Library dll = new Library();
            DataFile dataFile = new DataFile();
            this.unknownFiles = new List<string>();
            dataFile.ReadUnknown(Launcher.Name, dll.Name);
            if (dataFile.UnknownFiles.Count > 0)
            {
                foreach (string unknown in dataFile.UnknownFiles) unknownFiles.Add(unknown);
                e.Result = ErrorResult.Unknown;
                return;
            }

            this.missedFiles = new List<int>();
            dataFile.ReadMissed(Launcher.Name);
            if (dataFile.MissedFiles.Count > 0)
            {
                foreach (int missed in dataFile.MissedFiles) this.missedFiles.Add(missed);
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
                string text = "Imate veæ pokrenutu instancu Columbia State launchera.";
                MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
                return;
            }
            else if (e.Result.ToString() == ErrorResult.Edit.ToString())
            {
                ProcessKiller pk = new ProcessKiller();
                
                pk.Samp();
                pk.GtaSa();
                pk.HostNm();

                string text = "Columbia State launcher je neovlašteno izmjenjen!";
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
                string text = String.Format("Igra sadrži {0} nepoznatih fajlova.\nDa li želite ukloniti sve strane fajlove?", this.unknownFiles.Count);

                if (MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.YesNo, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        foreach (string name in this.unknownFiles) File.Delete(name);

                        text = "Nepoznati fajlovi su uspješno uklonjeni, pokrenite ponovo aplikaciju.";
                        MessageBoxAdv.Show(text, title.InfoMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        text = "Nepoznati fajlovi nisu uspješno izbrisani, uèinite ruèno uklanjanje!";
                        MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                Application.Exit();
                return;
            }
            else if (e.Result.ToString() == ErrorResult.Missed.ToString())
            {
                string text = String.Format("Otkriveno je {0} nedostajeæih fajlova od igre.\nDa li želite sada skinuti potrebne fajlove?", this.missedFiles.Count);

                if (MessageBoxAdv.Show(text, title.WarningMsg, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    DownloadForm dw = new DownloadForm();
                    foreach (int index in this.missedFiles) dw.Id.Add(index);
                    
                    if (dw.ShowDialog(this) == System.Windows.Forms.DialogResult.Abort)
                    {
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
                string text = "Columbia State server je trenutno u procesu nadogradnje, pokušajte kasnije!";
                MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);

                Application.Exit();
                return;
            }

            mainForm.Show();
        }

        private void LoadForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ProcessKiller pk = new ProcessKiller();

            pk.Samp();
            pk.GtaSa();
            pk.HostNm();
        }
    }
}

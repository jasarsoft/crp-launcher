using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;

using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using Syncfusion.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace Jasarsoft.Columbia
{
    public partial class MainForm : Syncfusion.Windows.Forms.MetroForm
    {
        //FileStream[] fileStream;
        //FileStream test;

        //List<FileStream> locks;
        //FileStream s2 = new FileStream("samp.dll", FileMode.Open, FileAccess.Read, FileShare.Read);

        //int number = 0;

        Library library;
        DataFile dataFile;
        ErrorResult errorResult;
        
        //List<int> id = new List<int>();

        List<FileStream> fileStream;

        enum ErrorResult
        {
            None,
            Task
        };

        public MainForm()
        {
            InitializeComponent();

            this.library = new Library();
            this.dataFile = new DataFile();
            this.fileStream = new List<FileStream>();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SampRegistry sr = new SampRegistry();

            sr.Default();
            if (!sr.Check()) sr.Create();
            else if (!sr.Valid()) sr.Write();
            else sr.Read();

            this.textName.Text = sr.PlayerName;

            if (Launcher.Locked)
            {
                this.textPassword.Enabled = true;
                this.textPassword.Text = String.Empty;
            }
            else
            {
                this.textPassword.Enabled = false;
                this.textPassword.Text = "0123456789";
            }
            
        }


        private void WorkerCheck_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(3000);
            foreach(string file in Launcher.Name)
            {
                Thread.Sleep(100);
                if (!File.Exists(file))
                {
                    e.Cancel = true;
                    return;
                }
            }
            //if (!library.Check())
            //{
            //    e.Cancel = true;
            //    return;
            //}

            Thread.Sleep(3000);
            if (dataFile.CheckUnknown(Launcher.Name, library.Name))
            {
                e.Cancel = true;
                return;
            }

            Thread.Sleep(3000);
            if (dataFile.CheckMissed(Launcher.Name))
            {
                e.Cancel = true;
                return;
            }
        }

        private void WorkerCheck_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageTitle title = new MessageTitle();
                ProcessKiller killer = new ProcessKiller();

                killer.Samp();
                killer.SanAndreas();
                killer.Host();

                string message = "Greška, otkriveni su pokušaji izmjene modifikacije tokom rada.\n" +
                                 "Columbia State Launcher æe se zatovriti iz sigurnosnih razloga.\n" +
                                 "Napomena, izmjene modifikacije nisu dozvoljene od strane korisnika.";
                
                MessageBoxAdv.Show(message, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //workerGame.CancelAsync();
                //workerHost.CancelAsync();
                Application.Exit();
                return;
            }

            workerCheck.RunWorkerAsync();
        }


        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            if(this.textName.Text.ToLower() == this.textName.Text.ToLower())
            {
                MessageTitle title = new MessageTitle();

                string message = "Korisnièko ime ne može biti poèetno postaljeno (Ime_Prezime).\n" +
                                 "Unesite vaše korisnièko za prijavu na server formata 'Ime_Prezime'.";

                MessageBoxAdv.Show(message, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.textName.Text.Length < 4)
            {
                MessageTitle title = new MessageTitle();
                string text = "Korisnièko ime mora sadržavati najmanje 4 karaktera.\nFormat korisnièkog imena mora biti 'Ime_Prezime'.";
                MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textName.Text = "Ime_Prezime";
                //this.Show();
                return;
            }

            if (this.textName.Text.Length > 21)
            {
                MessageTitle title = new MessageTitle();
                string text = "Korisnièko ime može imati najviše 21 karakter.\nFormat korisnièkog imena mora biti 'Ime_Prezime'.";
                MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textName.Text = "Ime_Prezime";
                //this.Show();
                return;
            }

            //if (!this.textName.Text.Contains("_"))
            //{
            //    MessageTitle title = new MessageTitle();
            //    string text = "Korisnièko ime mora sadržavati znak '_' u sebi.\nFormat korisnièkog imena mora biti 'Ime_Prezime'.";
            //    MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.textName.Text = "Ime_Prezime";
            //    //this.Show();
            //    return;
            //}

            //if (this.textName.Text.Contains("_"))
            //{
            //    string temp = this.textName.Text.Remove(this.textName.Text.IndexOf("_"), 1);
            //    if (temp.Contains("_"))
            //    {
            //        MessageTitle title = new MessageTitle();
            //        string text = "Korisnièko ime može samo sadržavati jednu donju-crtu '_'.\nFormat korisnièkog imena mora biti 'Ime_Prezime'.";
            //        MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        this.textName.Text = "Ime_Prezime";
            //        //this.Show();
            //        return;
            //    }
            //}

            if (!Regex.IsMatch(this.textName.Text, @"^[a-zA-Z_]+$"))
            {
                MessageTitle title = new MessageTitle();
                string text = String.Format("Korisnièko ime može sadržavati samo slova i znak donje-crte '_'.\nFormat korisnièkog imena mora biti 'Ime_Prezime', maksimalne dužine 21 karakter.");
                MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textName.Text = "Ime_Prezime";
                return;
            }

            //string name = this.textName.Text.Substring(0, this.textName.Text.IndexOf("_"));
            //string surname = this.textName.Text.Substring(this.textName.Text.IndexOf("_") + 1);

            //if (name.Length < 3 || surname.Length < 4)
            //{
            //    MessageTitle title = new MessageTitle();
            //    string text = "Dio 'Ime' može imati najamnje 3 slova, dok 'Prezime' najmanje 4 slova.\nFormat korisnièkog imena mora biti 'Ime_Prezime', maksimalne dužine 21 karakter.";
            //    MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.textName.Text = "Ime_Prezime";
            //    //this.Show();
            //    return;
            //}

            //if (name.Substring(0, 1) != name.Substring(0, 1).ToUpper())
            //{
            //    MessageTitle title = new MessageTitle();
            //    string text =String.Format("Dio '{0}' mora poèinjati velikim slovom.\nFormat korisnièkog imena mora biti 'Ime_Prezime'.", name);
            //    MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.textName.Text = "Ime_Prezime";
            //    return;
            //}

            //if (surname.Substring(0, 1) != surname.Substring(0, 1).ToUpper())
            //{
            //    MessageTitle title = new MessageTitle();
            //    string text = String.Format("Dio '{0}' mora poèinjati velikim slovom.\nFormat korisnièkog imena mora biti 'Ime_Prezime'.", surname);
            //    MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.textName.Text = "Ime_Prezime";
            //    return;
            //}

            Process[] sampRun = Process.GetProcessesByName("gtasamp");
            if (sampRun.Length > 0)
            {
                MessageTitle title = new MessageTitle();
                string text = "Imate veæ pokrenutu SAMP aplikaciju, zatvorite je!";
                MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Process[] gtaRun = Process.GetProcessesByName("gtasa");
            if (gtaRun.Length > 0)
            {
                MessageTitle title = new MessageTitle();
                string text = "Imate veæ pokrenutu GTA San Andreas igru, zatvorite je!";
                MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SampRegistry sr = new SampRegistry();
            sr.Default();
            if (!sr.Check())
                sr.Create();
            //else if (!sr.Valid())
            //    sr.Write();
            else
                sr.Read();

            if (sr.PlayerName != this.textName.Text)
            {
                sr.PlayerName = this.textName.Text;
                sr.Write();
            }

            if (Launcher.Locked && Launcher.Password != this.textPassword.Text)
            {
                MessageTitle title = new MessageTitle();
                string text = "Columbia State server je zakljuèan, vaša lozinka je pogrešna.";
                MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ValidForm vf = new ValidForm();
            if (vf.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                vf = null;
                GC.Collect();

                ProcessStartInfo processInfo = new ProcessStartInfo();
                processInfo.FileName = "gtasamp.exe";
                processInfo.WorkingDirectory = @".\";
                processInfo.Arguments = String.Format("{0} {1}", Launcher.Address, Launcher.Password);
                Process.Start(processInfo);

                Process host = new Process();
                host.StartInfo.FileName = "host-cs.exe";
                host.StartInfo.Arguments = "cs_silent14";
                host.StartInfo.WorkingDirectory = ".\\";
                host.Start();

                workerCheck.RunWorkerAsync();
                workerGame.RunWorkerAsync();
                workerHost.RunWorkerAsync();
                //this.Hide();
                return;
            }
            else
            {
                //MessageTitle title = new MessageTitle();
                //string text = "Columbia State server je zakljuèan, vaša lozinka je pogrešna.";
                //MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Application.Exit();
            return;
        }

        private void ButtonLogin_MouseHover(object sender, EventArgs e)
        {
            this.buttonLogin.BackColor = Color.DarkBlue;
        }

        private void ButtonLogin_MouseLeave(object sender, EventArgs e)
        {
            this.buttonLogin.BackColor = Color.Firebrick;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //ProcessKiller pk = new ProcessKiller();

            //pk.Samp();
            //pk.GtaSa();
            //pk.HostNm();
        }

        private void MenuHelpItemLauncher_Click(object sender, EventArgs e)
        {
            AboutForm al = new AboutForm();

            al.ShowDialog(this);
        }

        private void MenuHelpItemRules_Click(object sender, EventArgs e)
        {
            RulesForm rf = new RulesForm();

            rf.ShowDialog(this);
        }

        private void MenuLinkItemForum_Click(object sender, EventArgs e)
        {
            Process.Start(Launcher.Forum);
        }

        private void MenuLinkItemYouTube_Click(object sender, EventArgs e)
        {
            Process.Start(Launcher.YouTube);
        }

        private void MenuLinkItemFacebook_Click(object sender, EventArgs e)
        {
            Process.Start(Launcher.Facebook);
        }

        private void MenuLinkItemTeamSpeak_Click(object sender, EventArgs e)
        {
            RegistryKey localKey32 = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry32);

            localKey32 = localKey32.OpenSubKey(@"SOFTWARE\TeamSpeak 3 Client");
            if (localKey32 != null)
            {
                object value = localKey32.GetValue(null);
                if (value != null)
                {
                    ProcessStartInfo info = new ProcessStartInfo();

                    info.FileName = "ts3client_win32.exe";
                    info.WorkingDirectory = value.ToString();
                    info.Arguments = String.Format("ts3server://{0}?port={1}", Launcher.Teamspeak.Substring(0, Launcher.Teamspeak.IndexOf(":")), Launcher.Teamspeak.Substring(Launcher.Teamspeak.IndexOf(":") + 1));

                    if (File.Exists(String.Format("{0}\\{1}", value.ToString(), info.FileName)))
                    {
                        Process.Start(info);
                        return;
                    }
                }
            }

            RegistryKey localKey64 = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);

            localKey64 = localKey64.OpenSubKey(@"SOFTWARE\TeamSpeak 3 Client"); 
            if (localKey64 != null)
            {
                object value = localKey64.GetValue(null);
                if (value != null)
                {
                    ProcessStartInfo info = new ProcessStartInfo();

                    info.FileName = "ts3client_win64.exe";
                    info.WorkingDirectory = value.ToString();
                    info.Arguments = String.Format("ts3server://{0}?port={1}", Launcher.Teamspeak.Substring(0, Launcher.Teamspeak.IndexOf(":")), Launcher.Teamspeak.Substring(Launcher.Teamspeak.IndexOf(":") + 1));

                    if (File.Exists(String.Format("{0}\\{1}", value.ToString(), info.FileName)))
                    {
                        Process.Start(info);
                        return;
                    }
                    
                }
            }

            MessageTitle title = new MessageTitle();
            string text = "Vi nemate instaliran Teamspeak 3!";
            MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
            Process.Start("https://www.teamspeak.com/teamspeak3.html");
        }

        private void MenuFileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MenuFileAdmin_Click(object sender, EventArgs e)
        {
            LoginForm lf = new LoginForm(this.textName.Text);

            lf.ShowDialog(this);
        }

        private void MenuFileClient_Click(object sender, EventArgs e)
        {
            ButtonLogin_Click(sender, e);
        }

        private void MenuToolsCheck_Click(object sender, EventArgs e)
        {
            CheckForm cf = new CheckForm();

            cf.ShowDialog(this);
        }

        private void MenuToolsDownload_Click(object sender, EventArgs e)
        {
            UpdateForm uf = new UpdateForm();

            uf.ShowDialog(this);
        }

        private void MenuHelpItemNovaMahala_Click(object sender, EventArgs e)
        {
            DescriptionForm anm = new DescriptionForm();

            anm.ShowDialog(this);
        }


        private void WorkerHost_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(1000);
            Process[] process = Process.GetProcessesByName("host-cs");
            if (process.Length != 1) e.Cancel = true;
        }

        private void WorkerHost_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                ProcessKiller killer = new ProcessKiller();

                killer.Samp();
                killer.SanAndreas();
                killer.Host();

                Application.Exit();
                return;
            }

            workerHost.RunWorkerAsync();
        }


        private void WorkerGame_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(5000);
            Process[] process = Process.GetProcessesByName("gtasa");
            if (process.Length != 1) e.Cancel = true;
        }

        private void WorkerGame_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                ProcessKiller killer = new ProcessKiller();

                killer.Samp();
                killer.SanAndreas();
                killer.Host();

                Application.Exit();
                return;
            }

            workerGame.RunWorkerAsync();
        }

        private void MenuToolsUpdate_Click(object sender, EventArgs e)
        {
            MessageTitle title = new MessageTitle();
            string text = "Da li ste sigurni da želite provjeriti nadogradnju launchera?\n" +
                          "Napomena, aplikacija æe se pokrenuti ponovo nakon ažuriranja.";
            DialogResult dialog = MessageBoxAdv.Show(text, title.InfoMsg, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dialog == DialogResult.Yes)
            {
                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = "update-cs.exe";
                info.WorkingDirectory = ".\\";
                info.Arguments = "cs_silent14";
                Process.Start(info);
                Application.Exit();
            }   
        }
    }
}

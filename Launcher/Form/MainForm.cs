using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;

using System.Text;
using System.Windows.Forms;
using Jasarsoft.Columbia.Library;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using Syncfusion.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace Jasarsoft.Columbia.Launcher
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


        private void workerCheck_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(3000);
            if (!library.Check())
            {
                e.Cancel = true;
                return;
            }

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

        private void workerCheck_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageTitle title = new MessageTitle();
                string text = "Otkrivene su neke izmjene na igri tokom rada.\nAplikacija �e se zatvoriti iz sigurnosnih razloga.";
                MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                workerGame.CancelAsync();
                workerHost.CancelAsync();
                Application.Exit();
                return;
            }

            workerCheck.RunWorkerAsync();
        }


        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (this.textName.Text.Length < 4)
            {
                MessageTitle title = new MessageTitle();
                string text = "Korisni�ko ime mora sadr�avati najmanje 4 karaktera.\nFormat korisni�kog imena mora biti 'Ime_Prezime'.";
                MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textName.Text = "Ime_Prezime";
                //this.Show();
                return;
            }

            if (this.textName.Text.Length > 21)
            {
                MessageTitle title = new MessageTitle();
                string text = "Korisni�ko ime mo�e imati najvi�e 21 karakter.\nFormat korisni�kog imena mora biti 'Ime_Prezime'.";
                MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textName.Text = "Ime_Prezime";
                //this.Show();
                return;
            }

            //if (!this.textName.Text.Contains("_"))
            //{
            //    MessageTitle title = new MessageTitle();
            //    string text = "Korisni�ko ime mora sadr�avati znak '_' u sebi.\nFormat korisni�kog imena mora biti 'Ime_Prezime'.";
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
            //        string text = "Korisni�ko ime mo�e samo sadr�avati jednu donju-crtu '_'.\nFormat korisni�kog imena mora biti 'Ime_Prezime'.";
            //        MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        this.textName.Text = "Ime_Prezime";
            //        //this.Show();
            //        return;
            //    }
            //}

            if (!Regex.IsMatch(this.textName.Text, @"^[a-zA-Z_]+$"))
            {
                MessageTitle title = new MessageTitle();
                string text = String.Format("Korisni�ko ime mo�e sadr�avati samo slova i znak donje-crte '_'.\nFormat korisni�kog imena mora biti 'Ime_Prezime', maksimalne du�ine 21 karakter.");
                MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textName.Text = "Ime_Prezime";
                return;
            }

            //string name = this.textName.Text.Substring(0, this.textName.Text.IndexOf("_"));
            //string surname = this.textName.Text.Substring(this.textName.Text.IndexOf("_") + 1);

            //if (name.Length < 3 || surname.Length < 4)
            //{
            //    MessageTitle title = new MessageTitle();
            //    string text = "Dio 'Ime' mo�e imati najamnje 3 slova, dok 'Prezime' najmanje 4 slova.\nFormat korisni�kog imena mora biti 'Ime_Prezime', maksimalne du�ine 21 karakter.";
            //    MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.textName.Text = "Ime_Prezime";
            //    //this.Show();
            //    return;
            //}

            //if (name.Substring(0, 1) != name.Substring(0, 1).ToUpper())
            //{
            //    MessageTitle title = new MessageTitle();
            //    string text =String.Format("Dio '{0}' mora po�injati velikim slovom.\nFormat korisni�kog imena mora biti 'Ime_Prezime'.", name);
            //    MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.textName.Text = "Ime_Prezime";
            //    return;
            //}

            //if (surname.Substring(0, 1) != surname.Substring(0, 1).ToUpper())
            //{
            //    MessageTitle title = new MessageTitle();
            //    string text = String.Format("Dio '{0}' mora po�injati velikim slovom.\nFormat korisni�kog imena mora biti 'Ime_Prezime'.", surname);
            //    MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.textName.Text = "Ime_Prezime";
            //    return;
            //}

            Process[] sampRun = Process.GetProcessesByName("gtasamp");
            if (sampRun.Length > 0)
            {
                MessageTitle title = new MessageTitle();
                string text = "Imate ve� pokrenutu SAMP aplikaciju, zatvorite je!";
                MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Process[] gtaRun = Process.GetProcessesByName("gtasa");
            if (gtaRun.Length > 0)
            {
                MessageTitle title = new MessageTitle();
                string text = "Imate ve� pokrenutu GTA San Andreas igru, zatvorite je!";
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
                string text = "Columbia State server je zaklju�an, va�a lozinka je pogre�na.";
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

                Process.Start("host-cs.exe");
                workerCheck.RunWorkerAsync();
                workerHost.RunWorkerAsync();
                workerGame.RunWorkerAsync();
                this.Hide();
                return;
            }

            Application.Exit();
            return;
        }

        private void buttonLogin_MouseHover(object sender, EventArgs e)
        {
            this.buttonLogin.BackColor = Color.ForestGreen;
        }

        private void buttonLogin_MouseLeave(object sender, EventArgs e)
        {
            this.buttonLogin.BackColor = Color.FromArgb(22, 165, 220);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ProcessKiller pk = new ProcessKiller();

            pk.Samp();
            pk.GtaSa();
            pk.HostNm();
        }

        private void menuHelpItemLauncher_Click(object sender, EventArgs e)
        {
            AboutForm al = new AboutForm();

            al.ShowDialog(this);
        }

        private void menuHelpItemRules_Click(object sender, EventArgs e)
        {
            RulesForm rf = new RulesForm();

            rf.ShowDialog(this);
        }

        private void menuLinkItemForum_Click(object sender, EventArgs e)
        {
            Process.Start(Launcher.Forum);
        }

        private void menuLinkItemYouTube_Click(object sender, EventArgs e)
        {
            Process.Start(Launcher.YouTube);
        }

        private void menuLinkItemFacebook_Click(object sender, EventArgs e)
        {
            Process.Start(Launcher.Facebook);
        }

        private void menuLinkItemTeamSpeak_Click(object sender, EventArgs e)
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

        private void menuFileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuFileAdmin_Click(object sender, EventArgs e)
        {
            LoginForm lf = new LoginForm(this.textName.Text);

            lf.ShowDialog(this);
        }

        private void menuFileClient_Click(object sender, EventArgs e)
        {
            buttonLogin_Click(sender, e);
        }

        private void menuToolsCheck_Click(object sender, EventArgs e)
        {
            CheckForm cf = new CheckForm();

            cf.ShowDialog(this);
        }

        private void menuToolsDownload_Click(object sender, EventArgs e)
        {
            UpdateForm uf = new UpdateForm();

            uf.ShowDialog(this);
        }

        private void menuHelpItemNovaMahala_Click(object sender, EventArgs e)
        {
            DescriptionForm anm = new DescriptionForm();

            anm.ShowDialog(this);
        }


        private void workerHost_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(500);
            Process[] process = Process.GetProcessesByName("host-cs");
            if (process.Length != 1) e.Cancel = true;
        }

        private void workerHost_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                Process[] process = Process.GetProcessesByName("gtasa");

                if (process.Length > 0)
                {
                    foreach (Process temp in process)
                    {
                        do
                        {
                            temp.Kill();
                        } while (temp.HasExited == false);
                    }
                }

                Application.Exit();
                return;
            }

            workerHost.RunWorkerAsync();
        }


        private void workerGame_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(5000);
            Process[] process = Process.GetProcessesByName("gtasa");
            if (process.Length != 1) e.Cancel = true;
        }

        private void workerGame_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                Process[] process = Process.GetProcessesByName("host-cs");
                if (process.Length > 0)
                {
                    foreach (Process temp in process)
                    {
                        do
                        {
                            temp.Kill();
                        } while (temp.HasExited == false);
                    }
                }

                Application.Exit();
                return;
            }

            workerGame.RunWorkerAsync();
        }
     
    }
}

using Syncfusion.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Jasarsoft.ColumbiaState.Host
{
    public partial class MainForm : Syncfusion.Windows.Forms.MetroForm
    {
        private ErrorResult errorResult;
        private List<string> allFiles;
        private List<FileStream> fileStream;

        private enum ErrorResult
        {
            Process,
            MultiInstance
        }

        public MainForm()
        {
            InitializeComponent();

            this.fileStream = new List<FileStream>();
            this.allFiles = new List<string>(Directory.GetFiles(@".\", "*.*", SearchOption.AllDirectories));

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

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Path.GetFileName(Application.ExecutablePath) != "host-cs.exe")
            {
                ProcessKiller pk = new ProcessKiller();
                MessageTitle title = new MessageTitle();

                pk.GtaSa();
                pk.Samp();
                pk.SampColumbia();

                string text = "Columbia State Host aplikacija je neovlašteno izmjenjena!";
                MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Stop);

                Application.Exit();
                return;
            }


            if (!File.Exists("columbia.exe"))
            {
                ProcessKiller pk = new ProcessKiller();
                MessageTitle title = new MessageTitle();

                pk.GtaSa();
                pk.Samp();
                pk.SampColumbia();
                
                string text = "Columbia State glavna aplikacija ne postoji ili je preimenovana!";
                MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Stop);

                Application.Exit();
                return;
            }

            Process[] nmProcess = Process.GetProcessesByName("columbia");
            if (nmProcess.Length == 0)
            {
                Process.Start("columbia.exe");
                Application.Exit();
                return;
            }
            
            if (nmProcess.Length > 1)
            {
                ProcessKiller pk = new ProcessKiller();
                MessageTitle title = new MessageTitle();

                pk.Samp();
                pk.GtaSa();
                pk.SampColumbia();

                string text = "Columbia State launcher pokrenut je sa više instanci!";
                MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Stop);

                Application.Exit();
                return;
            }

            Process[] hosts = Process.GetProcessesByName("host-cs");
            if (hosts.Length == 1)
            {
                this.workerStream.RunWorkerAsync();
                this.workerNM.RunWorkerAsync();
                this.Hide();
            }
            else
            {
                ProcessKiller pk = new ProcessKiller();
                MessageTitle title = new MessageTitle();

                pk.Samp();
                pk.GtaSa();
                pk.SampColumbia();

                string text = "Columbia State host ne pokreæite Vi!";
                MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Stop);

                Application.Exit();
                return;
            }  
        }

        private void workerStream_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(3000);

            this.fileStream.Clear();
            foreach (string name in this.allFiles)
            {
                if (name.Contains("modloader.log")) continue;
                if (!File.Exists(name))
                {
                    e.Cancel = true;
                    return;
                }
                    
                this.fileStream.Add(new FileStream(name, FileMode.Open, FileAccess.Read, FileShare.Read));
            }
        }

        private void workerStream_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                Process[] process = Process.GetProcessesByName("columbia");
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
                workerNM.CancelAsync();
                return;
            }

            this.workerStream.RunWorkerAsync();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }


        private void workerNM_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(500);
            Process[] process = Process.GetProcessesByName("columbia");
            if (process.Length != 1) e.Cancel = true;
        }

        private void workerNM_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

                workerStream.CancelAsync();
                Application.Exit();
                return;
            }

            workerNM.RunWorkerAsync();
        }
    }
}

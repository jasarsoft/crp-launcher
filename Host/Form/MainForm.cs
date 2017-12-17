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

namespace Jasarsoft.Columbia.Host
{
    public partial class MainForm : Syncfusion.Windows.Forms.MetroForm
    {
        private ErrorResult errorResult;
        private List<string> fileList;
        private List<FileStream> fileStream;
        private StringCipher cipher;

        private const string appHost = "zIDXfr0Hq/BxlxwjMy0DSv0g+92mKGERfI7c3FWFuyOPm78JMmAstEBS2IlKjTtZoqCN5FwOi1t7kLIufAYFKk88Kbpe94oAu1dLD3ZBi02PyM31CxBwyc5lxh0IQJFf"; //host-cs.exe
        private const string appColumbia = "lYimDIzBdJeAOkOtHUIvl4wgQeIff81rcGRiOvhCQazK8kMqIQaayRxKMVi1MCcTi71+OU40QaDJsUYYnvBttV1rBItazVhZ7aTsC12ENTgWzsNjMK5HL7psI8HEQ394"; //columbia.exe

        private enum ErrorResult
        {
            Process,
            MultiInstance
        }

        public MainForm()
        {
            InitializeComponent();
            this.Visible = false;

            this.cipher = new StringCipher();
            this.fileStream = new List<FileStream>();
            this.fileList = new List<string>(Directory.GetFiles(@".\", "*.*", SearchOption.AllDirectories));

            MessageBoxSettings();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Hide();
            
            if (Path.GetFileName(Application.ExecutablePath) != cipher.Decrypt(appHost))
            {
                ProcessKiller pk = new ProcessKiller();
                MessageTitle title = new MessageTitle();

                pk.Samp();
                pk.SanAndreas();
                
                string message = "Naziv Columbia State Host aplikacije je neovlašteno izmjenjen!\n" +
                                 "Svaka neovlaštena izmjena smatra se pokušajem nanoštenja štete.\n" +
                                 "Korisnici koji tako pokušavaju mogu dobiti trajnu blokadu pristupa.";

                MessageBoxAdv.Show(message, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Stop);

                Application.Exit();
                return;
            }


            if (!File.Exists(cipher.Decrypt(appColumbia)))
            {
                //ProcessKiller pk = new ProcessKiller();
                MessageTitle title = new MessageTitle();

                //pk.Samp();
                //pk.SanAndreas();
                Thread t1 = new Thread(new ThreadStart(SampKiller));
                t1.Priority = ThreadPriority.Lowest;
                t1.IsBackground = true;
                t1.Start();

                Thread t2 = new Thread(new ThreadStart(SanAndreasKiller));
                t2.Priority = ThreadPriority.Lowest;
                t2.IsBackground = true;
                t2.Start();

                string message = "Glavna aplikacija Columbia State ne potoji ili je preimenovana.\n" +
                                 "Svaka neovlaštena izmjena smatra se pokušajem nanoštenja štete.\n" +
                                 "Korisnici koji tako pokušavaju mogu dobiti trajnu blokadu pristupa.";

                //string message = "Columbia State glavna aplikacija ne postoji ili je preimenovana!";
                MessageBoxAdv.Show(message, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Stop);

                Application.Exit();
                return;
            }

            Process[] nmProcess = Process.GetProcessesByName("columbia");
            if (nmProcess.Length == 0)
            {
                Process.Start(cipher.Decrypt(appColumbia));
                Application.Exit();
                return;
            }
            
            if (nmProcess.Length > 1)
            {
                //ProcessKiller pk = new ProcessKiller();
                MessageTitle title = new MessageTitle();

                //pk.Samp();
                //pk.SanAndreas();
                //pk.Columbia();
                Thread t1 = new Thread(new ThreadStart(SampKiller));
                t1.Priority = ThreadPriority.Lowest;
                t1.IsBackground = true;
                t1.Start();

                Thread t2 = new Thread(new ThreadStart(SanAndreasKiller));
                t2.Priority = ThreadPriority.Lowest;
                t2.IsBackground = true;
                t2.Start();

                string message = "Aplikacija Columbia State Launcher je pokrenut sa više instanci.\n" +
                                 "Isto narušava trenutni rad pa se novo pokretanje neæe dozvoliti.";
                
                MessageBoxAdv.Show(message, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Stop);

                Application.Exit();
                return;
            }

            Process[] hosts = Process.GetProcessesByName("host-cs");
            if (hosts.Length == 1)
            {
                this.workerStream.RunWorkerAsync();
                this.workerColumbia.RunWorkerAsync();
            }
            else
            {
                MessageTitle title = new MessageTitle();
                string message = "Aplikaciju Columbia State Host ne pokreæete direktno Vi.\n" +
                                 "Isto narušava trenutni rad pa se pokretanje neæe dozovliti.";

                MessageBoxAdv.Show(message, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Stop);

                Application.Exit();
                return;
            }  
        }

        private void workerStream_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(3000);

            this.fileStream.Clear();
            foreach (string name in this.fileList)
            {
                if (!File.Exists(name))
                {
                    if (name.Contains("VHUD_debug.log")) continue;
                    if (name.Contains("modloader\\modloader.log")) continue;
                    this.fileStream.Add(new FileStream(name, FileMode.Open, FileAccess.Read, FileShare.Read));
                }
                else
                {
                    e.Cancel = true;
                    break;
                }
            }
        }

        private void workerStream_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                ColumbiaKiller();
                SanAndreasKiller();
                workerColumbia.CancelAsync();
                return;
            }

            this.workerStream.RunWorkerAsync();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }


        private void workerColumbia_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(500);
            Process[] process = Process.GetProcessesByName("columbia");
            if (process.Length != 1) e.Cancel = true;
        }

        private void workerColumbia_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                SanAndreasKiller();
                workerStream.CancelAsync();
                Application.Exit();
                return;
            }

            workerColumbia.RunWorkerAsync();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*Thread t1 = new Thread(new ThreadStart(SampKiller));
            t1.Priority = ThreadPriority.Highest;
            t1.Start();

            Thread t2 = new Thread(new ThreadStart(SanAndreasKiller));
            t2.Priority = ThreadPriority.Highest;
            t2.IsBackground = true;
            t2.Start();*/
        }

        private void MessageBoxSettings()
        {
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

        private void SampKiller()
        {
            Process[] allProcess = Process.GetProcessesByName("gtasamp");
            if (allProcess.Length > 0)
            {
                foreach (Process tempProcess in allProcess)
                {
                    do
                    {
                        tempProcess.Kill();
                        tempProcess.WaitForExit();
                    } while (tempProcess.HasExited == false);
                }
            }
        }

        private void SanAndreasKiller()
        {
            Process[] allProcess = Process.GetProcessesByName("gtasa");
            if (allProcess.Length > 0)
            {
                foreach (Process tempProcess in allProcess)
                {
                    do
                    {
                        tempProcess.Kill();
                        tempProcess.WaitForExit();
                    } while (tempProcess.HasExited == false);
                }
            }
        }

        private void ColumbiaKiller()
        {
            Process[] allProcess = Process.GetProcessesByName("columbia");
            if (allProcess.Length > 0)
            {
                foreach (Process tempProcess in allProcess)
                {
                    do
                    {
                        tempProcess.Kill();
                        tempProcess.WaitForExit();
                    } while (tempProcess.HasExited == false);
                }
            }
        }
    }
}

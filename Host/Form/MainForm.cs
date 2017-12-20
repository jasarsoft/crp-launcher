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
        private string mode;
        private List<string> fileList;
        private List<FileStream> fileStream;
        private StringCipher cipher;

        private readonly List<int> skipId;
        private readonly string[] skipFiles;

        private const string runMode = "6+37Xpr7Ij/N7wPYg3U2M9rFrwNPm86YGI0EGiCwl6Hgx0en6lxQfTuxK416epvmZMxBthTT1dTNcuiEDge2Tt1PKSjNVCfYq5RORDWWzHhndpn8xuVVDaxKSDhrEPgW"; //cs_silent14 
        private const string appHost = "zIDXfr0Hq/BxlxwjMy0DSv0g+92mKGERfI7c3FWFuyOPm78JMmAstEBS2IlKjTtZoqCN5FwOi1t7kLIufAYFKk88Kbpe94oAu1dLD3ZBi02PyM31CxBwyc5lxh0IQJFf"; //host-cs.exe
        private const string appColumbia = "lYimDIzBdJeAOkOtHUIvl4wgQeIff81rcGRiOvhCQazK8kMqIQaayRxKMVi1MCcTi71+OU40QaDJsUYYnvBttV1rBItazVhZ7aTsC12ENTgWzsNjMK5HL7psI8HEQ394"; //columbia.exe

        private const string processHost = "XxHjZ+mej41bvZnWwOaE7h9zFKdtqQ2+L3VFm5RjrXmznQ8MCIV1A7gumVh/rw0PuYv8DtdIzRwSmwzcFeUrXIhIofUu3dGOMntBDW/yopyJybD38t5uZ1zMeMYMfYfQ"; //host-cs
        private const string processColumbia = "1/HpTNI78Z0B5A7s8izzMpXBTYe0NFTyMN/MAyjosdzqWDivfMc94Kw76EynJ+vjGuU+MJVJgkzcKdu0OrsT/kAFB9wmGAtcF/ewIrT3+G8D0A8srdvhz7KZ8hSFm9B9"; //columbia


        public MainForm(string args = null)
        {
            InitializeComponent();

            this.cipher = new StringCipher();
            this.fileStream = new List<FileStream>();
            this.fileList = new List<string>(Directory.GetFiles(@".\", "*.*", SearchOption.AllDirectories));
            this.mode = args;
            MessageBoxSettings();

            this.skipFiles = new string[]
            {
                "VHUD_debug.log",
                "modloader\\modloader.log"
            };

            this.skipId = new List<int>();

            for(int i = 0; i < fileList.Count; i++)
            {
                for(int j = 0; j < skipFiles.Length; j++)
                {
                    if (fileList[i].Contains(skipFiles[j]))
                    {
                        skipId.Add(i);
                        Trace.TraceInformation("Preskakanje streama; ID: {0}; File: {1};", i, fileList[i]);
                    }  
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Hide();
            
            if (Path.GetFileName(Application.ExecutablePath) != cipher.Decrypt(appHost))
            {
                MessageTitle title = new MessageTitle();
                //ProcessKiller killer = new ProcessKiller();

                //killer.Samp();
                //killer.SanAndreas();
                
                string message = "Naziv Columbia State Host aplikacije je neovlašteno izmjenjen!\n" +
                                 "Svaka neovlaštena izmjena smatra se pokušajem nanoštenja štete istoj.\n" +
                                 "Napomena, nažalost aplikacija se iz sigurnostnih razloga se gasi.";

                MessageBoxAdv.Show(message, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Stop);

                Application.Exit();
                return;
            }


            if (!File.Exists(cipher.Decrypt(appColumbia)))
            {
                MessageTitle title = new MessageTitle();
                //ProcessKiller killer = new ProcessKiller();

                //killer.Samp();
                //killer.SanAndreas();

                string message = "Glavna aplikacija Columbia State Launcher ne potoji ili je preimenovana.\n" +
                                 "Svaka neovlaštena izmjena smatra se pokušajem nanoštenja štete istoj.\n" +
                                 "Napomena, launcher nije potpun i aplikacija se iz sigurnostnih razloga gasi.";

                MessageBoxAdv.Show(message, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Stop);

                Application.Exit();
                return;
            }

            Process[] columbia = Process.GetProcessesByName(cipher.Decrypt(processColumbia));
            if (columbia.Length == 0)
            {
                Process.Start(cipher.Decrypt(appColumbia));
                Application.Exit();
                return;
            }

            if (mode != cipher.Decrypt(runMode))
            {
                MessageTitle title = new MessageTitle();
                string message = "Aplikaciju Columbia State Host ne pokreæete direktno Vi.\n" +
                                 "Isto narušava trenutni rad pa se pokretanje neæe dozovliti.";

                MessageBoxAdv.Show(message, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Stop);

                Application.Exit();
                return;
            }

            //provera da li je app columbia (launcher) pokrenuta vise puta
            //sama app columbia takodje pri prokretanju provjera svoje instance procesa
            //tako da ova provjera nije potrebna dok je ima u columbia app
            if (columbia.Length > 1)
            {
                MessageTitle title = new MessageTitle();
                ProcessKiller killer = new ProcessKiller();

#if TRACE
                Trace.TraceError("Process '{0}' je pokrenut u više instanci.", columbia.ToString());
                Trace.TraceInformation("Zatvaranje (ubijanje) procesa '{0}';", columbia.ToString());
#endif
                killer.Columbia(); //zatvaranje procesa columbia.exe

                string message = "Aplikacija Columbia State Launcher je pokrenut sa više instanci.\n" +
                                 "Isto narušava trenutni rad pa se novo pokretanje neæe dozvoliti.\n" +
                                 "Napomena, svi procesi Columbia State Launchera æe biti uništeni.";
                
                MessageBoxAdv.Show(message, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Stop);

                Application.Exit();
                return;
            }

            Process[] hosts = Process.GetProcessesByName(cipher.Decrypt(processHost));
            if (hosts.Length == 1)
            {
                this.workerStream.RunWorkerAsync();
                this.workerColumbia.RunWorkerAsync();
            }
            else
            {
                MessageTitle title = new MessageTitle();
                string message = "Aplikacija Columbia State Host veæ je pokrenuta od strane launchera.\n" +
                                 "Ista je specijalno napravljena za pozadinske kontrole samog launchera\n" +
                                 "praæenje njegovog rada u trenutnom vremenu te zaštitu igraèa i modifikacije.";

                MessageBoxAdv.Show(message, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Stop);

                //Application.Exit();
                return;
            }  
        }

        private void workerStream_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(10000);

            bool skip = false;
            //this.fileStream.Clear();
            for(int i = 0; i < fileList.Count; i++)
            {
                for(int j = 0; j < skipId.Count; j++)
                {
                    if (i == skipId[j])
                    {
                        skip = true;
                        break;
                    }
                }
                
                if(File.Exists(fileList[i]))
                {
                    if (skip) continue;
#if !DEBUG
                    Thread.Sleep(100);
                    fileStream[i].Close();
                    this.fileStream.Remove(fileStream[i]);
                    this.fileStream.Add(new FileStream(fileList[i], FileMode.Open, FileAccess.Read, FileShare.Read));
#else
                    fileStream[i].Close(); Trace.TraceInformation("Stream na datoteku je zatvorena. ({0})", fileList[i]);
                    this.fileStream.Remove(fileStream[i]); Trace.TraceInformation("Stream je uklonjen. ({0})", fileList[i]);
                    this.fileStream.Add(new FileStream(fileList[i], FileMode.Open, FileAccess.Read, FileShare.Read));
                    Trace.TraceInformation("Stream je dodat. ({0})", fileList[i]);
#endif
                }
                else
                {
                    e.Cancel = true;
                    break;
                }
            }

            /*foreach (string name in this.fileList)
            {
                if (File.Exists(name))
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
            }*/
        }

        private void workerStream_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
#if DEBUG
            Trace.TraceInformation("workerStream_RunWorkerCompleted(); Start;");
            Trace.TraceInformation("workerStream_RunWorkerCompleted(); e.Cancelled = {0}", e.Cancelled);
            if (e.Cancelled)
            {
                ProcessKiller killer = new ProcessKiller();

                killer.Samp();          Trace.TraceInformation("workerStream_RunWorkerCompleted(); Call killer.Samp();");
                killer.SanAndreas();    Trace.TraceInformation("workerStream_RunWorkerCompleted(); Call killer.SanAndreas();");

                //workerColumbia.CancelAsync();
                return;
            }

            this.workerStream.RunWorkerAsync();
            Trace.TraceInformation("workerStream_RunWorkerCompleted(); Call workerStream.RunWorkerAsync()");
#endif
            if (e.Cancelled)
            {
                ProcessKiller killer = new ProcessKiller();

                killer.Samp();
                killer.SanAndreas();
                
                //workerColumbia.CancelAsync();
                return;
            }

            this.workerStream.RunWorkerAsync();
        }

        private void workerColumbia_DoWork(object sender, DoWorkEventArgs e)
        {
#if DEBUG
            Trace.TraceInformation("workerColumbai_DoWork(); Ulaz i spavanje 5s");
            Thread.Sleep(5000);
            Trace.TraceInformation("workerColumbia_DoWork(); Zavrseno spavanje");
            
            Process[] process = Process.GetProcessesByName(cipher.Decrypt(processColumbia));
            Trace.TraceInformation("workerColumbia_DoWork(); Procesa columbia ima {0}", process.Length);
            if (process.Length != 1)
            {
                e.Cancel = true;
                Trace.TraceError("workerColumbia_DoWork(); process.Lenght != 1; e.Cancel = true;");
            }
            Trace.TraceInformation("workerColumbia_DoWork(); Kraj");
#else
            Thread.Sleep(5000);
            Process[] process = Process.GetProcessesByName(cipher.Decrypt(processColumbia));
            if (process.Length != 1) e.Cancel = true;
#endif
        }

        private void workerColumbia_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
#if DEBUG
            Trace.TraceInformation("workerColumbia_RunWorkerCompleted(); Start;");
            Trace.TraceInformation("workerColumbia_RunWorkerCompleted(); e.Cancel = {0}", e.Cancelled);
            if (e.Cancelled)
            {
                ProcessKiller killer = new ProcessKiller();

                killer.Samp();          Trace.TraceInformation("workerColumbia_RunWorkerCompleted(); Call killer.Samp();");
                killer.SanAndreas();    Trace.TraceInformation("workerColumbia_RunWorkerCompleted(); Call killer.SanAndreas();");

                //workerStream.CancelAsync();
                Application.Exit();     Trace.TraceInformation("workerColumbia_RunWorkerCompleted(); Call Application.Exit();");
                return;
            }
#else
            if (e.Cancelled)
            {
                ProcessKiller killer = new ProcessKiller();

                killer.Samp();
                killer.SanAndreas();
                
                //workerStream.CancelAsync();
                Application.Exit();
                return;
            }

            workerColumbia.RunWorkerAsync();
#endif
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.Hide();
#if DEBUG
            Trace.TraceInformation("MainForm_Shown(); Called");
#endif
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
#if DEBUG
            Trace.TraceInformation("MessageBoxSettings(); Start;");
#endif
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
#if DEBUG
            Trace.TraceInformation("MessageBoxSettings(); End;");
#endif
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Syncfusion.Windows.Forms;


namespace Jasarsoft.Columbia
{
    public partial class ValidForm : Syncfusion.Windows.Forms.MetroForm
    {
        //private int number;
        private List<int> id;
        //FileStream[] fileStream;
        List<FileStream> fileStream;

        public ValidForm()
        {
            InitializeComponent();

            this.id = new List<int>();
            this.DialogResult = System.Windows.Forms.DialogResult.Abort;
        }

        private void ValidForm_Load(object sender, EventArgs e)
        {
            this.progressLoad.Value = 0;
            this.progressLoad.Maximum = Launcher.Name.Length - 1;
            this.labelName.Text = "Validacija æe automatski zapoèeti...";
        }

        private void ValidForm_Shown(object sender, EventArgs e)
        {
            workerFile.RunWorkerAsync();
        }

        private void WorkerFile_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Cancel = false;
            Thread.Sleep(1000);

            Library lib = new Library();
            DataFile df = new DataFile();
            
            this.fileStream = new List<FileStream>();

            for (int i = 0; i < Launcher.Name.Length; i++)
            {
                workerFile.ReportProgress(i);

                if (df.CheckUnknown(Launcher.Name, lib.Name))
                {
                    e.Cancel = true;
                    return;
                }

                if (df.CheckMissed(Launcher.Name))
                {
                    e.Cancel = true;
                    return;
                }

                if (!File.Exists(Launcher.Name[i]))
                {
                    e.Cancel = true;
                    return;
                }

                if (Launcher.Valid[i])
                {
                    string hash = HashFile.GetMD5(Launcher.Name[i]);
                    
                    if (hash == null)
                    {
                        e.Cancel = true;
                        return;
                    }

                    if (hash != Launcher.Hash[i].ToUpper())
                    {
                        this.id.Add(i);
                        continue;
                    }

                    this.fileStream.Clear();
                    for (int j = 0; j <= i; j++)
                    {
                        if (this.id.Count > 0)
                        {
                            bool skip = false;
                            foreach (int index in this.id)
                            {
                                if (j == index)
                                {
                                    skip = true;
                                    break;
                                }
                            }
                            if (skip) continue;
                        }
                       
                        this.fileStream.Add(new FileStream(Launcher.Name[j], FileMode.Open, FileAccess.Read, FileShare.Read));
                    }
                }
            }
        }

        private void WorkerFile_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressLoad.Value = e.ProgressPercentage;
            if(Launcher.Name[e.ProgressPercentage].Length > 45)
            {
                string filename = String.Format(@"...{0}", Launcher.Name[e.ProgressPercentage].Substring(Launcher.Name[e.ProgressPercentage].Length - 40));
                this.labelName.Text = String.Format("{0}/{1}: {2}", e.ProgressPercentage + 1, Launcher.Name.Length, filename);
            }
            else
                this.labelName.Text = String.Format("{0}/{1}: {2}", e.ProgressPercentage + 1, Launcher.Name.Length, Launcher.Name[e.ProgressPercentage]);
        }

        private void WorkerFile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Hide();

            string text;
            MessageTitle title = new MessageTitle();

            if (e.Cancelled)
            {
                //workerFile.CancelAsync();
                text = String.Format("Tokom provjere došlo je do neovlaštene izmjene fajlova.\nAplikacija iz sigurnostnih razloga bit æe zatvorena, pokušajte ponovo.");
                MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //Application.Exit();
                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                //return;
            }
            else if (this.id.Count > 0)
            {
                text = String.Format("Ukupno ima {0} fajlova za ažuriranje.\nDa li želite sada izvršiti nadogradnju istih?", this.id.Count);
                if (MessageBoxAdv.Show(text, title.WarningMsg, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    DownloadForm dw = new DownloadForm(true);
                    foreach (int index in this.id) dw.Id.Add(index);

                    if (dw.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    else
                        this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                }
                else
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                }
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }

            #if DEBUG
            Library lib = new Library();
            if (!lib.Valid())
            {
                text = "Columbia State Launcher biblioteke nisu validne!";
                MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
            }
            #endif
                
            this.fileStream.Clear();
            this.fileStream = null;
            GC.Collect();
            this.Close();
        }

    }
}

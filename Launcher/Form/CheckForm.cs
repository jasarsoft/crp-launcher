using Syncfusion.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Jasarsoft.Columbia
{
    public partial class CheckForm : Syncfusion.Windows.Forms.MetroForm
    {
        private ButtonStatus buttonWork;

        private enum ButtonStatus
        {
            ButtonStart,
            ButtonCancel
        };

        private enum ErrorResult
        {
            None,
            Missed,
            Unknown,            
            Validated
        };

        public CheckForm()
        {
            InitializeComponent();
        }

        private void CheckForm_Load(object sender, EventArgs e)
        {
            this.progressLoad.Value = 0;
            this.buttonWork = ButtonStatus.ButtonStart;
            this.progressLoad.Maximum = Launcher.Name.Length - 1;
            this.labelName.Text = "Molimo vas kliknite na Poèni da pokrente provjeru.";
        }

        private void workerFile_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = ErrorResult.None;
            // Get the BackgroundWorker that raised this event.
            BackgroundWorker worker = sender as BackgroundWorker;

            Library lib = new Library();
            DataFile df = new DataFile();

            if (df.CheckMissed(Launcher.Name))
            {
                e.Result = ErrorResult.Missed;
                return;
            }

            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            if (df.CheckUnknown(Launcher.Name, lib.Name))
            {
                e.Result = ErrorResult.Unknown;
                return;
            }

            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            for (int i = 0; i < Launcher.Name.Length; i++)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                workerFile.ReportProgress(i);

                if (Launcher.Valid[i])
                    if (HashFile.GetMD5(Launcher.Name[i]) != Launcher.Hash[i].ToUpper())
                    {
                        e.Result = ErrorResult.Validated;
                        return;
                    }      
            }
        }

        private void workerFile_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressLoad.Value = e.ProgressPercentage;
            this.labelName.Text = String.Format("Fajl {0}/{1}: {2}", e.ProgressPercentage + 1, Launcher.Name.Length, Launcher.Name[e.ProgressPercentage]);
        }

        private void workerFile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Hide();
            buttonStart.Enabled = true;

            string text;
            MessageTitle title = new MessageTitle();

            if(e.Cancelled)
            {
                text = "Provjera datoteka od Columbia State modifikacije je prekunita.\n";
                text += "Za više informacija o upustvima i provjeri posjetite naš forum.";
                MessageBoxAdv.Show(text, title.WarningMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (e.Result.ToString() == ErrorResult.None.ToString())
            {
                text = "Columbia State mod fajlovi su adekvatni i ažurirani.";
                MessageBoxAdv.Show(text, title.InfoMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (e.Result.ToString() == ErrorResult.Unknown.ToString())
            {
                text = "Columbia State mod sadrži nepoznate i/ili strane fajlove.";
                MessageBoxAdv.Show(text, title.WarningMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(e.Result.ToString() == ErrorResult.Missed.ToString())
            {
                text = "Columbia State mod nije potpun, neki fajlovi nedostaju.";
                MessageBoxAdv.Show(text, title.WarningMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (e.Result.ToString() == ErrorResult.Validated.ToString())
            {
                text = "Columbia State mod nije ažuriran na zadnju verziju.";
                MessageBoxAdv.Show(text, title.WarningMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //GC.Collect();
            this.Close();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = false;

            if (workerFile.IsBusy)
            {
                buttonStart.Text = "Poèni";
                workerFile.CancelAsync();
            }   
            else
            {
                buttonStart.Text = "Prekini";
                workerFile.RunWorkerAsync();
                buttonStart.Enabled = true;
            }     
        }
    }
}

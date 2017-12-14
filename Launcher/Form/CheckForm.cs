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
        private int number;
        private int fileMissed;
        private int fileUnknown;
        private int fileIncorrect;
        private int fileTotal;
        private bool errorResult;
        private List<CheckFile> files;
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

            this.number = 0;
            this.fileMissed = 0;
            this.fileUnknown = 0;
            this.fileIncorrect = 0;
            this.fileTotal = 0;
            this.errorResult = false;
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
            files = new List<CheckFile>();
            e.Result = ErrorResult.None;
            // Get the BackgroundWorker that raised this event.
            BackgroundWorker worker = sender as BackgroundWorker;

            Library lib = new Library();
            DataFile df = new DataFile();

            //provjera nedostajucih fajlova
            if (df.CheckMissed(Launcher.Name))
            {
                errorResult = true;
                //e.Result = ErrorResult.Missed;
                df.ReadMissed(Launcher.Name);
                foreach(int id in df.MissedFiles)
                {
                    fileMissed++;
                    files.Add(new CheckFile(++number, Launcher.Name[id], Launcher.Size[id], "Nedostaje"));
                }
                    
                //return;
            }
            //provjera da li je pritisnut prekid
            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            //provjera nepoznatih fajlova
            if (df.CheckUnknown(Launcher.Name, lib.Name))
            {
                errorResult = true;
                //e.Result = ErrorResult.Unknown;
                df.ReadUnknown(Launcher.Name, lib.Name);
                foreach (string file in df.UnknownFiles)
                {
                    fileUnknown++;
                    long length = new System.IO.FileInfo(file).Length;
                    files.Add(new CheckFile(++number, file, length, "Nepoznat"));
                }
                //return;
            }
            //provjera da li je pritisnut prekid
            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            //provjera hash fajlova koji su oznaceni za provjeru (valid)
            for (int i = 0; i < Launcher.Name.Length; i++)
            {
                //provjera da li je pritisnuto za prekid
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                workerFile.ReportProgress(i);
#if DEBUG
                //Thread.Sleep(250);
#endif

                if (Launcher.Valid[i])
                {
                    if (HashFile.GetMD5(Launcher.Name[i]) != Launcher.Hash[i].ToUpper())
                    {
                        fileIncorrect++;
                        errorResult = true;
                        files.Add(new CheckFile(++number, Launcher.Name[i], Launcher.Size[i], "Neispravan"));
                        //e.Result = ErrorResult.Validated;
                        //return;
                    }
                }                                         
            }
        }

        private void workerFile_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressLoad.Value = e.ProgressPercentage;
            if (Launcher.Name[e.ProgressPercentage].Length > 45)
            {
                string filename = String.Format(@"...{0}", Launcher.Name[e.ProgressPercentage].Substring(Launcher.Name[e.ProgressPercentage].Length - 40));
                this.labelName.Text = String.Format("{0}/{1}: {2}", e.ProgressPercentage + 1, Launcher.Name.Length, filename);
            }
            else
                this.labelName.Text = String.Format("{0}/{1}: {2}", e.ProgressPercentage + 1, Launcher.Name.Length, Launcher.Name[e.ProgressPercentage]);
        }

        private void workerFile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            buttonStart.Text = "Poèni";
            buttonStart.Enabled = true;
            this.progressLoad.Value = 0;
            this.labelName.Text = "Molimo vas kliknite na Poèni da pokrente provjeru.";

            string text;
            MessageTitle title = new MessageTitle();

            if(e.Cancelled)
            {
                text = "Provjera datoteka od Columbia State modifikacije je prekunita.\n";
                text += "Za više informacija o upustvima i provjeri posjetite naš forum.";
                MessageBoxAdv.Show(text, title.WarningMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(errorResult)
            {
                text = "Vaša modifikacija sadrži nekoliko pogrešaka sa datotekama.\n";
                text += "Da li želite detaljno pogledati listu datoteka sa greškom?.";
                if(MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    FileForm ff = new FileForm(files);
                    ff.FileMissed = this.fileMissed;
                    ff.FileUnknown = this.fileUnknown;
                    ff.FileIncorrect = this.fileIncorrect;
                    ff.FileTotal = Launcher.Name.Length;

                    ff.ShowDialog();
                }
            }
            else
            {
                text = "Vaša datoteke su ispravne i korektne sa Columbia State modifikacijom.\n";
                text += "Sada možete legalno i pravno pristupit našem serveru i uživati u igri.";
                MessageBoxAdv.Show(text, title.InfoMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = false;

            if (workerFile.IsBusy)
            {
                MessageTitle title = new MessageTitle();
                string text = "Da li ste sigurni da želite prekinuti provjeru vaši datoteka?";
                if(MessageBoxAdv.Show(text, title.WarningMsg, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    buttonStart.Text = "Poèni";
                    workerFile.CancelAsync();
                }
            }   
            else
            {
                buttonStart.Text = "Prekini";
                workerFile.RunWorkerAsync();
                buttonStart.Enabled = true;
                this.labelName.Text = "Priprema za provjeru vaši datoteka...";
            }     
        }
    }
}

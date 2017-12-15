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
        private int number;
        private List<int> id;
        private int errorNumber;
        private int fileMissed;
        private int fileUnknown;
        private int fileIncorrect;
        //FileStream[] fileStream;
        List<FileStream> fileStream;
        List<ErrorFile> errorFiles;

        public ValidForm()
        {
            InitializeComponent();

            this.number = 0;
            this.errorNumber = 0;
            this.fileMissed = 0;
            this.fileUnknown = 0;
            this.fileIncorrect = 0;
            this.id = new List<int>();
            this.DialogResult = System.Windows.Forms.DialogResult.Abort;
        }

        private void ValidForm_Load(object sender, EventArgs e)
        {
            this.progressLoad.Value = 0;
            this.progressLoad.Maximum = Launcher.Name.Length - 1;
            this.labelName.Text = "Validacija �e automatski zapo�eti...";
        }

        private void ValidForm_Shown(object sender, EventArgs e)
        {
            workerFile.RunWorkerAsync();
        }

        private void WorkerFile_DoWork(object sender, DoWorkEventArgs e)
        {
            this.number = 0;
            this.fileMissed = 0;
            this.fileUnknown = 0;
            this.fileIncorrect = 0;
            Library lib = new Library();
            DataFile df = new DataFile();
            this.errorFiles = new List<ErrorFile>();
            this.fileStream = new List<FileStream>();
            BackgroundWorker worker = sender as BackgroundWorker;

            //provjera nepoznatih fajlova
            if (df.CheckUnknown(Launcher.Name, lib.Name))
            {
                df.ReadUnknown(Launcher.Name, lib.Name);
                foreach(string file in df.UnknownFiles)
                {
                    //ako fajl u medjuvremenu nestane
                    if (!File.Exists(file)) continue;
                    this.fileUnknown++; //brojac nepoznatih fajlova
                    long length = new System.IO.FileInfo(file).Length;
                    this.errorFiles.Add(new ErrorFile(++number, file, length, "Nepoznat"));
                }                
            }
            //provjera zahtjeva za izlaz
            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            //provjera nedostajucih fajlova
            if(df.CheckMissed(Launcher.Name))
            {
                df.ReadMissed(Launcher.Name);
                foreach(int id in df.MissedFiles)
                {
                    this.id.Add(id); //fajl koji nedotaje takodje se dodaje na listu za skidanje (download);
                    this.fileMissed++; //brojac nedostajucih fajlova
                    this.errorFiles.Add(new ErrorFile(++number, Launcher.Name[id], Launcher.Size[id], "Nedostaje"));
                }

            }
            //provjera zahtjeva za izlaz
            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            //provjera za sve fajlove;
            for (int i = 0; i < Launcher.Name.Length; i++)
            {
                workerFile.ReportProgress(i);
                //provjera zahtjeva za izlaz
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                if (File.Exists(Launcher.Name[i]) && Launcher.Valid[i])
                {
                    if (HashFile.GetMD5(Launcher.Name[i]) != Launcher.Hash[i].ToUpper())
                    {
                        this.id.Add(i);
                        this.fileIncorrect++;
                        this.errorFiles.Add(new ErrorFile(++number, Launcher.Name[i], Launcher.Size[i], "Neispravan"));
                    }

                    /*this.fileStream.Clear();
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
                    }*/
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
            string text;
            MessageTitle title = new MessageTitle();

            if (e.Cancelled)
            {
                text = "Validacija datoteka od Columbia State modifikacije je prekunita.\n";
                text += "Ne mo�ete se spojiti na server sve dok uspje�no ne zavr�ite validaciju.";
                MessageBoxAdv.Show(text, title.WarningMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //workerFile.CancelAsync();
                //text = String.Format("Tokom provjere do�lo je do neovla�tene izmjene fajlova.\nAplikacija iz sigurnostnih razloga bit �e zatvorena, poku�ajte ponovo.");
                //MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //Application.Exit();
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
                //return;
            }
            else if(this.fileUnknown > 0 || this.fileMissed > 0 || this.fileIncorrect > 0)
            {
                text = "Va�a modifikacija sadr�i nekoliko pogre�aka sa datotekama.\n";
                text += "Da li �elite detaljno pogledati listu datoteka sa gre�kom?.";
                if (MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    FileForm ff = new FileForm(this.errorFiles);
                    ff.FileMissed = this.fileMissed;
                    ff.FileUnknown = this.fileUnknown;
                    ff.FileIncorrect = this.fileIncorrect;
                    ff.FileTotal = Launcher.Name.Length;

                    ff.ShowDialog();
                }

                //ako potoje nepoznate datoteke, ponudit ce se brisanje istih
                //i ako se izvede brisanje onda ce se nastaviti sa vlidacijom
                if(this.fileUnknown > 0)
                {
                    text = "Da bih ste se uspje�no spojili na server potrebno je da uklonite nepoznate fajlove.\n";
                    text += "Da li �elite sada ukloniti nepoznate fajlove i tako omogu�iti uspje�nu validaciju datoteka?\n";
                    text += "Napomena, datoteke koje su u listi tj. zapisniku ozna�ene kao nepoznate �e biti trajno uklonjene.";
                    if (MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                    {
                        Library libs = new Library();
                        DataFile df = new DataFile();
                        df.ReadUnknown(Launcher.Name, libs.Name);
                        foreach (string file in df.UnknownFiles)
                        {
                            if (!File.Exists(file)) continue;
                            File.Delete(file);
                        }

                        text = "Nepoznate datoteke su uspje�no obrisane, sada mo�ete nastaviti.";
                        MessageBoxAdv.Show(text, title.InfoMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //korisnik je odabrao da ne zeli ukloniti nepoznate fajlove
                        //time se validacija ne ispunjava i prekida se zatvaranjem forme
                        this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                        this.Close();
                        return;
                    }
                }

                //ako potoje nedotajuce i nekorektne datoteke onda ce biti ponudjeno skidanje istih
                //u slucaju da se uspjesno izvede validacija ce biti nastavljena dalje;
                if(this.fileMissed > 0 || this.fileIncorrect > 0)
                {
                    long lenght = 0;
                    //sabira se ukupna velicina svih pojedinih fajlova na listi za download
                    foreach (int id in this.id) lenght += Launcher.Size[id];
                    text = "Da bih ste se spojili uspje�no na server sve datoteke trebaju biti validne.\n";
                    text += "Da li �elite sada skinuti potrebne datotke i tako omogu�iti uspje�nu validaciju?\n";
                    text += String.Format("Napomena, broj datoteka za skidanje je {0} i ukupna veli�ina je {1:0.00}MB.", this.fileMissed + this.fileIncorrect, lenght/1048576.0);
                    if (MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                    {
                        this.Hide();
                        DownloadForm dw = new DownloadForm();
                        foreach (int index in this.id) dw.Id.Add(index);
                        if(dw.ShowDialog() == DialogResult.Abort)
                        {
                            //a�uriranje datoteka nije uspje�no izvr�eno i validacija se prekida;
                            text = "Skidanje i a�uriranje datoteka sa servisa nije uspje�no izvr�eno.\n";
                            text += "Na�alost validacija ne mo�e biti nastavljena dalje, poku�ajte ponovo.\n";
                            text += "U slu�aju da ne mo�e pro�i postupak validacije, obratite se na forumu.";
                            MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                            this.Close();
                            return;
                        }

                        /*if (dw.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        else
                            this.DialogResult = System.Windows.Forms.DialogResult.Abort;*/
                    }
                    else
                    {
                        //korisnik je odabrao da ne zeli skinuti protrebne fajlove
                        //time validacija ne mo�e biti zadovoljena i forma se zatvara
                        this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                        this.Close();
                        return;
                    }
                }
            }
            /*else if (this.id.Count > 0)
            {
                text = String.Format("Ukupno ima {0} fajlova za a�uriranje.\nDa li �elite sada izvr�iti nadogradnju istih?", this.id.Count);
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
            }*/

#if DEBUG
            /*Library lib = new Library();
            if (!lib.Valid())
            {
                text = "Columbia State Launcher biblioteke nisu validne!";
                MessageBoxAdv.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
            }*/
#endif

            //this.fileStream.Clear();
            //this.fileStream = null;
            //GC.Collect();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}

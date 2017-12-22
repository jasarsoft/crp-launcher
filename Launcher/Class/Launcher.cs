using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Syncfusion.Windows.Forms;

namespace Jasarsoft.Columbia
{
    internal static class Launcher
    {
        private static bool[] valid;
        private static string[] name;
        private static long[] size;
        private static string[] hash;
        private static string[] link;
        private static string[] url;

        private static bool locked;
        private static bool worked;
        private static int slideshow;
        private static string address;
        private static string password;
        private static string teampspeak;
        private static string website;
        private static string forum;
        private static string facebook;
        private static string youtube;
        private static string email;
        

        public static bool[] Valid
        {
            get { return valid; }
            set { valid = value; }
        }

        public static string[] Name
        {
            get { return name; }
            set { name = value; }
        }

        public static long[] Size
        {
            get { return size; }
            set { size = value; }
        }

        public static string[] Hash
        {
            get { return hash; }
            set { hash = value; }
        }

        public static string[] Link
        {
            get { return link; }
            set { link = value; }
        }

        public static string[] Url
        {
            get { return url; }
            set { url = value; }
        }


        public static bool Locked
        {
            get { return locked; }
            set { locked = value; }
        }

        public static bool Working
        {
            get { return worked; }
            set { worked = value; }
        }

        public static int SlideShow
        {
            get { return slideshow; }
            set { slideshow = value; }
        }

        public static string Address
        {
            get { return address; }
            set { address = value; }
        }

        public static string Password
        {
            get { return password; }
            set { password = value; }
        }

        public static string Teamspeak
        {
            get { return teampspeak; }
            set { teampspeak = value; }
        }

        public static string Website
        {
            get { return website; }
            set { website = value; }
        }

        public static string Forum
        {
            get { return forum; }
            set { forum = value; }
        }

        public static string Facebook
        {
            get { return facebook; }
            set { facebook = value; }
        }


        public static string YouTube
        {
            get { return youtube; }
            set { youtube = value; }
        }

        public static string Email
        {
            get { return email; }
            set { email = value; }
        }
        

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
#if !DEBUG
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Library lib = new Library();
            if (!lib.Valid())
            {
                MessageTitle title = new MessageTitle();
                string message = "Biblioteke datoteka od Columbia State Launchera nisu isparavne.\n" +
                                 "Da li želite pokreniti servis ažuriranja i nadomjestiti ispravnim?\n" +
                                 "Napomena, aplikacija ne može biti pokrenuta dok ne budu datoteke validne.";

                if (MessageBox.Show(message, title.ErrorMsg, MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.No) return;
                //pokretanje sistema ažuriranja
                if(File.Exists(".\\update-cs.exe"))
                {
                    Process process = new Process();
                    process.StartInfo.FileName = "update-cs.exe";
                    process.StartInfo.Arguments = "cs_silent14";
                    process.StartInfo.WorkingDirectory = ".\\";
                    process.StartInfo.UseShellExecute = false;
                    process.Start();
                }
                else
                {
                    message = "Servis Columbia State Launcher Update trenutno ne postoji.\n" +
                              "Ovaj korak će biti implemnetiran u novijim ažuriranjima launchera.";

                    MessageBox.Show(message, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                return;
            }

            MySqlLauncher lan = new MySqlLauncher();
            if (lan.Read())
            {
                if(HashFile.GetMD5("columbia.exe") != lan.HashLauncher || HashFile.GetMD5("host-cs.exe") != lan.HashHost)
                {
                    MessageTitle title = new MessageTitle();
                    string message = "Vaša verzija Columbia State Launchera nije posljednja.\n" +
                                     "Da li želite sada ažurirati launcher na zadnju verziju?\n" +
                                     "Napomena, za pristpu našem serveru aplikacija treba biti najnovija.";
                    if(DialogResult.Yes == MessageBoxAdv.Show(message, title.ErrorMsg, MessageBoxButtons.YesNo, MessageBoxIcon.Error))
                    {
                        if (File.Exists(".\\update-cs.exe"))
                        {
                            Process process = new Process();
                            process.StartInfo.FileName = "update-cs.exe";
                            process.StartInfo.Arguments = "cs_silent14";
                            process.StartInfo.WorkingDirectory = ".\\";
                            process.StartInfo.UseShellExecute = false;
                            process.Start();
                        }
                        else
                        {
                            message = "Servis Columbia State Launcher Update trenutno ne postoji.\n" +
                                      "Ovaj korak će biti implemnetiran u novijim ažuriranjima launchera.";

                            MessageBoxAdv.Show(message, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    return;
                }
                else if (HashFile.GetMD5("update-cs.exe") != lan.HashUpdate)
                {
                    MessageTitle title = new MessageTitle();
                    string message = "Vaša verzija Columbia State Update servisa nije posljednja.\n" +
                                     "Da li želite sada ažurirati update servis na zadnju verziju?\n" +
                                     "Napomena, za pristpu našem serveru servis treba biti najnoviji.";

                    MessageBoxAdv.Show(message, title.ErrorMsg, MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                    message = "Implementacija u novim ažuriranjem Columbia State Launcher-a.";
                    MessageBoxAdv.Show(message, title.InfoMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageTitle title = new MessageTitle();
                string message = "Nažalost došlo je do greške pri spajanju sa bazom podataka.\n" +
                                 "Provjerite svoju internet konekciju ili kontaktirajte administraciju.";
                MessageBoxAdv.Show(message, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            lan = null;
            lib = null;

            if (args.Length > 0)
            {
                string message;
                MessageTitle title = new MessageTitle();
                if(args[0] == "0")
                {
                    message = "Ažuriranje Columbia State Launchera je uspješno urađeno.\n" +
                              "Želimo vam ugodno korištenje, sve primjedbe pišite na forumu.";
                    MessageBoxAdv.Show(message, title.InfoMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    message = "Ažuriranje Columbia State Launchera je neuspješno.\n" +
                              "Detaljnije obrađena poruka u novijim nadogradnjama.";
                    MessageBoxAdv.Show(message, title.InfoMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }              
            }
#endif

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new LoadForm());
            //Application.Run(new DownloadForm());
        }   
    }
}

using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Jasarsoft.Columbia.Launcher
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
        private static string address;
        private static string password;
        private static string teampspeak;
        private static string website;
        private static string forum;
        private static string youtube;
        private static string facebook;
        

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

        public static string YouTube
        {
            get { return youtube; }
            set { youtube = value; }
        }

        public static string Facebook
        {
            get { return facebook; }
            set { facebook = value; }
        }


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            #if !DEBUG
            Jasarsoft.Columbia.Library.Launcher lan = new Jasarsoft.Columbia.Library.Launcher();
            if (lan.Read())
            {
                if(HashFile.GetMD5("columbia.exe") != lan.Hash)
                {
                    MessageTitle title = new MessageTitle();
                    string text = "Columbia State Launcher nije validan.";
                    MessageBox.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }
            else
            {
                MessageTitle title = new MessageTitle();
                string text = "Konekcija sa bazom podataka nije moguća.";
                MessageBox.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            Library lib = new Library();
            if (!lib.Valid())
            {
                MessageTitle title = new MessageTitle();
                string text = "Columbia State Launcher biblioteke nisu validne.";
                MessageBox.Show(text, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            lan = null;
            lib = null;
            #endif

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Application.Run(new LoadForm());
        }

        
    }
}

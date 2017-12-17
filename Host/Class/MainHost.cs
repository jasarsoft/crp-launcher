using System;
using System.IO;
using System.Windows.Forms;

namespace Jasarsoft.Columbia.Host
{
    static class MainHost
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            StringCipher cipher = new StringCipher();
            string filename = "5rtZ18wWFTYO/vKvHJRZadRMQ8wumQfrPKfx6VniCZ5m+J1cH7fsfWlIi+hII2N6nmaepvnc8f2DGt31FcOflOtG8Gtj1t3v9rh8mDs7SA2L7WcR7EdH2ZW4V3jlUrLK"; ////Syncfusion.Shared.Base.dll

            if (!File.Exists(cipher.Decrypt(filename))) 
            {
                MessageTitle title = new MessageTitle();
                string message = "Columbia State Host aplkacija je neovlašteno i izolovano pokrenuta.\n" +
                                 "Aplikacija ne može biti nastaljvena te se iz sigurnostih razloga gasi.";
                MessageBox.Show(message, title.ErrorMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}

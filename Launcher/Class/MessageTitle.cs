using System;

namespace Jasarsoft.Columbia.Launcher
{
    internal class MessageTitle
    {
        private string infoMsg;
        private string errorMsg;
        private string warningMsg;

        //default contructor
        public MessageTitle()
        {
            this.infoMsg = "SAMP Columbia State | Info";
            this.errorMsg = "SAMP Columbia State | Greška";
            this.warningMsg = "SAMP Columbia State | Upozorenje";
        }


        //property
        public string InfoMsg
        {
            get { return this.infoMsg; }
        }

        public string ErrorMsg
        {
            get { return this.errorMsg; }
        }

        public string WarningMsg
        {
            get { return this.warningMsg; }
        }
    }
}

using System;
using System.Net.NetworkInformation;

namespace Jasarsoft.Columbia.Library
{
    public class Network
    {

        public string Error 
        {
            get 
            {
                string text;

                text = "Vaša internet konekcija trenutno nije u dostupna!";
                text += Environment.NewLine;
                text += "Aplikacija ne može nastaviti sa radom bez ovog resursa.";

                return text;
            } 
        }

        public bool Available()
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

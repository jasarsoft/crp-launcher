using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Text;

namespace Jasarsoft.Columbia.Library
{
    public class Download
    {
        private string url = "https://mega.nz/#!0Nwi0SAD!aDb8XelO0Z72zzVOyKkT7LReu-y2TKOIwWuTYjcu7nY";
        private string name = "eax1.dll";


        public bool Test()
        {
            WebClient client = new WebClient();

            client.DownloadFile(url, name);
            client.DownloadFile("https://mega.nz/#!ERQCmQAI!aDb8XelO0Z72zzVOyKkT7LReu-y2TKOIwWuTYjcu7nY", ".\\test\\eax2.dll");
            return true;
        }

        public bool File(string link, string path)
        {
            //CG.Web.MegaApiClient.MegaApiClient client = new CG.Web.MegaApiClient.MegaApiClient();
            //client.LoginAnonymous();

            //using (var fileStream = new FileStream(path, FileMode.Create))
            //{
            //    using (var downloadStream = new ProgressionStream(client.Download(new Uri(link)), this.PrintProgression))
            //    {
            //        downloadStream.CopyTo(fileStream);
            //    }
            //}


            try
            {
                //WebClient client = new WebClient();
                //client.Headers.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 8.0)");
                //client.DownloadFile(link, path);
                return true;
            }
            catch (WebException)
            {
                return false;
            }
            //WebClient client = new WebClient();
            //client.Headers.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 8.0)");
            //client.DownloadFile(link, path);
            
            //return true;
        }

        private void PrintProgression(double progression)
        {
            //Console.WriteLine(progression);
        }
        
    }
}

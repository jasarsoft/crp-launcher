using System;
using System.Threading;
using System.Threading.Tasks;

using Google;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Download;
using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;
using Google.Apis.Logging;
using Google.Apis.Services;
using Google.Apis.Upload;
using System.Net;

namespace Test_Download
{
    class Program
    {
        static Program()
        {
            // initialize the log instance
            ApplicationContext.RegisterLogger(new Log4NetLogger());
            Logger = ApplicationContext.Logger.ForType<ResumableUpload<Program>>();
        }

        #region Consts

        private const int KB = 0x400;
        private const int DownloadChunkSize = 256 * KB;

        // CHANGE THIS with full path to the file you want to upload
        private const string UploadFileName = @"FILE_TO_UPLOAD";

        // CHANGE THIS with a download directory
        private const string DownloadDirectoryName = @"DIRECTORY_FOR_DOWNLOADING";

        // CHANGE THIS if you upload a file type other than a jpg
        private const string ContentType = @"image/jpeg";

        #endregion

        /// <summary>The logger instance.</summary>
        private static readonly ILogger Logger;

        /// <summary>The Drive API scopes.</summary>
        private static readonly string[] Scopes = new[] { DriveService.Scope.DriveFile, DriveService.Scope.Drive };

        /// <summary>
        /// The file which was uploaded. We will use its download Url to download it using our media downloader object.
        /// </summary>
        private static File uploadedFile;

        static void Main(string[] args)
        {
            try
            {
                new Program().Run().Wait();
            }
            catch (AggregateException ex)
            {
                foreach (var e in ex.InnerExceptions)
                {
                    Console.WriteLine("ERROR: " + e.Message);
                }
            }
        }

        private async Task Run()
        {
            GoogleWebAuthorizationBroker.Folder = "Drive.Sample";
            GoogleCredential credential;
            using (var stream = new System.IO.FileStream("Columbia State-99db1bd2a00e.json",
                System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream).CreateScoped(Scopes);
            }

            // Create the service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Columbia State",
            });

            // uploaded succeeded
            await DownloadFile(service, "https://doc-0c-7o-docs.googleusercontent.com/docs/securesc/bq8oq8h3l68rlgehm8u6cvhlru1c2c5b/48ortuv2d80sl6ji3ddqol603omk19rv/1509213600000/12017929765300884506/09884659862440838168/0Byi5ne7d961QcGpCN3VDZE5jSWM?e=download&gd=true");
        }

        private async Task DownloadFile(DriveService service, string url)
        {
            var downloader = new MediaDownloader(service);
            downloader.ChunkSize = DownloadChunkSize;
            // add a delegate for the progress changed event for writing to console on changes
            downloader.ProgressChanged += Download_ProgressChanged;

            // figure out the right file type base on UploadFileName extension
            var fileName = "test.txt";

            using (var fileStream = new System.IO.FileStream(fileName,
                System.IO.FileMode.Create, System.IO.FileAccess.Write))
            {
                var progress = await downloader.DownloadAsync(url, fileStream);
                if (progress.Status == DownloadStatus.Completed)
                {
                    Console.WriteLine(fileName + " was downloaded successfully");
                }
                else
                {
                    Console.WriteLine("Download {0} was interpreted in the middle. Only {1} were downloaded. ",
                        fileName, progress.BytesDownloaded);
                }
            }
        }

        static void Download_ProgressChanged(IDownloadProgress progress)
        {
            Console.WriteLine(progress.Status + " " + progress.BytesDownloaded);
        }
    }
}

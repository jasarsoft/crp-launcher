using Google.Apis.Drive.v2;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Google.Apis.Util.Store;
using System.Threading;
using System.Net;

namespace Jasarsoft.Columbia
{
    public class GDriveAccount
    {
        string[] scopes;

        public GDriveAccount()
        {
            scopes = new string[] 
            {
                DriveService.Scope.DriveReadonly,
                DriveService.Scope.DriveMetadataReadonly
            };
        }
           
        public DriveService Authenticate()
        {
            WebClient client = new WebClient();
            GDrivePrivate gdp = new GDrivePrivate();
                        
            try
            {
                Stream stream = client.OpenRead(gdp.Credential);
                GoogleCredential credential = GoogleCredential.FromStream(stream).CreateScoped(scopes);
                stream.Close();

                return new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = gdp.Name,
                });
            }
            catch (Exception ex)
            {
                throw new Exception("CreateServiceAccountDriveFailed", ex);
            }
        }
    }
}

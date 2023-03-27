using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;

namespace GoogleFile
{
    internal class Program
    {
        private const string PathToService = @"C:\POC\AirlineManagementSystem\GoogleFile\savvysavings-f89540f9c198.json";        
        private const string UploadFieName = "C:\\Users\\5126\\Pictures\\Screenshots\\testimage.png";
        
        // Dev folder Id 
        private const string DirId = "1sxFK3Bpg4FWfXsqBVBLXToa0PPEyuGka"; 

        static async Task Main(string[] args)
        {
            // Load the service account cred and define the scope of its access.
            var credential = GoogleCredential.FromFile(PathToService).CreateScoped(DriveService.ScopeConstants.Drive);

            // create the Drive service
            var srv = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential
            });

            // Upload file Metadata
            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = $"{Guid.NewGuid()}.jpg",
                Parents = new List<string>() { DirId }
            };

            //create a new file on google drive
            await using (var fileSource = new FileStream(UploadFieName, FileMode.Open, FileAccess.Read))
            {
                var req = srv.Files.Create(fileMetadata, fileSource, "image/jpeg");

                req.Fields = "*";

                var result = await req.UploadAsync(CancellationToken.None);

                if(result.Status == Google.Apis.Upload.UploadStatus.Failed)
                {
                    Console.WriteLine($"Error: {result.Exception.Message}");
                }

                var uploadResult = req.ResponseBody;

                Console.WriteLine($"https://drive.google.com/uc?export=view&id={uploadResult.Id}");
            }
        }
    }
}
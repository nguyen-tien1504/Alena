using Google.Cloud.Storage.V1;

namespace Alena.Services
{
    public class FirestoreService : IFirestoreService
    {
        private readonly StorageClient _storageClient;
        private const string BucketName = "test-6daef.appspot.com";
        public FirestoreService(StorageClient storageClient)
        {
            this._storageClient = storageClient;
        }

        public async Task<string> UploadFile(string name, IFormFile file)
        {
            using var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            var blob = await _storageClient.UploadObjectAsync(BucketName,
            $"{name}", file.ContentType, stream);
            //var photoUri = new Uri(blob.MediaLink);
            string photoUri = $"https://storage.googleapis.com/{BucketName}/{name}";
            return photoUri;
        }

        public async void DeleteFile(string imgUri)
        {
            string imgName = imgUri.Substring(imgUri.LastIndexOf('/') + 1);
            await _storageClient.DeleteObjectAsync(BucketName, imgName);
        }
    }
}

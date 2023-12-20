namespace Alena.Services
{
    public interface IFirestoreService
    {
        public Task<string> UploadFile(string name, IFormFile file);
        public void DeleteFile(string imgUri);
    }
}

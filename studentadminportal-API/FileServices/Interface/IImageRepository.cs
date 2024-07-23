namespace studentadminportal_API.FileServices.Interface
{
    public interface IImageRepository
    {
        Task<string> Upload(IFormFile file, string fileName);
    }
}

using TestProject.Core.Application.Responses;

namespace TestProject.Core.Application.Services
{
  
    public interface IFileService
    {
        FileResponse UploadImage(IFormFile file);

        string GetImageUrl(string imageId);
        Task<string> UploadDocument(IFormFile file);
    }
}

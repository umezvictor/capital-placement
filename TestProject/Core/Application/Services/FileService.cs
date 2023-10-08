using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using TestProject.Core.Application.Responses;

namespace TestProject.Core.Application.Services
{
    public class FileService : IFileService
    {
        private readonly IConfiguration _configuration;

        public FileService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public FileResponse UploadImage(IFormFile file)
        {

            if (file != null)
            {
                Account account = new Account();
                account.ApiKey = _configuration["CloudinarySettings:ApiKey"];
                account.ApiSecret = _configuration["CloudinarySettings:ApiSecret"]; 
                account.Cloud = _configuration["CloudinarySettings:Cloud"];

                Cloudinary cloudinary = new Cloudinary(account);

                var fileId = Guid.NewGuid().ToString();

                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.FileName, file.OpenReadStream()),
                    PublicId = fileId
                };
                var uploadResult = cloudinary.Upload(uploadParams);
               

                if (uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return new FileResponse { FileId = fileId, Success = true, Message = "upload successful" };
                }

                return new FileResponse { FileId = "", Success = false };


            }

            return new FileResponse { FileId = "", Success = false, Message = "File not  found" };

        }



        public string GetImageUrl(string imageId)
        {
            string url = "";
            if (imageId != null)
            {
                Account account = new Account();
                account.ApiKey = _configuration["CloudinarySettings:ApiKey"];
                account.ApiSecret = _configuration["CloudinarySettings:ApiSecret"];
                account.Cloud = _configuration["CloudinarySettings:Cloud"];

                Cloudinary cloudinary = new Cloudinary(account);

                var result = cloudinary.GetResource(imageId);
                url = result.Url;
                


            }

            return url;

        }


        public async Task<string> UploadDocument(IFormFile file)
        {
            string uniqueFileName = "";
            if(file.Length > 0)
            {
                //create a directory
                var directory = $@"{AppDomain.CurrentDomain.BaseDirectory}" + "\\Resumes";

                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);


                string path = $"{directory}\\{uniqueFileName}";
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
           return uniqueFileName;
        }
    }

}

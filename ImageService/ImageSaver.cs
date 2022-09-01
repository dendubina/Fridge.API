using System.IO;
using Contracts.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace ImageService
{
    public class ImageSaver : IImageService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IConfiguration _config;

        public ImageSaver(IWebHostEnvironment webHostEnvironment, IConfiguration config)
        {
            _environment = webHostEnvironment;
            _config = config;
        }

        public async Task<string> AddImageReturnPath(IFormFile image)
        {
            string imagesFolder = _config["ImagesFolder"];
            string folderToSave = _environment.WebRootPath + imagesFolder;

            string filename = Path.GetRandomFileName();
            filename = Path.GetFileNameWithoutExtension(filename);

            filename += Path.GetExtension(image.FileName);

            string fullPath = Path.Combine(folderToSave, filename);

            await using (var stream = File.Create(fullPath))
            {
                await image.CopyToAsync(stream);
            }

            string pathToImg = Path.Combine(imagesFolder, filename);

            return "https://localhost:5001" + pathToImg;
        }
    }
}

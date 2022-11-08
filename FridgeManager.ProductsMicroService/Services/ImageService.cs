using System;
using System.IO;
using System.IO.Abstractions;
using System.Threading.Tasks;
using FridgeManager.ProductsMicroService.Contracts;
using FridgeManager.ProductsMicroService.Models.Options;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace FridgeManager.ProductsMicroService.Services
{
    public class ImageService : IImageService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ImageServiceOptions _options;
        private readonly IFileSystem _fileSystem;

        public ImageService(IWebHostEnvironment webHostEnvironment, IOptions<ImageServiceOptions> options, IFileSystem fileSystem)
        {
            _environment = webHostEnvironment;
            _fileSystem = fileSystem;
            _options = options.Value;
        }

        public async Task<string> AddImageGetPath(IFormFile image)
        {
            if (image is null)
            {
                throw new ArgumentException("Image must not be null", nameof(image));
            }

            string folderToSave = Path.Combine(_environment.WebRootPath, _options.FolderToSave);

            string filename = $"{GetRandomFileName}{Path.GetExtension(image.FileName)}";

            await using (var stream = _fileSystem.File.Create(Path.Combine(folderToSave, filename)))
            {
                await image.CopyToAsync(stream);
            }

            return $"https://localhost:5002/{_options.FolderToSave}/{filename}";
        }

        private static string GetRandomFileName => DateTime.Now.Ticks.ToString();
    }
}

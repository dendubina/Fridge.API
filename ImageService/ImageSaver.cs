using System;
using System.IO;
using System.IO.Abstractions;
using Contracts.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using ImageService.Options;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;

namespace ImageService
{
    public class ImageSaver : IImageService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ImageServiceOptions _options;
        private readonly IFileSystem _fileSystem;

        public ImageSaver(IWebHostEnvironment webHostEnvironment, IOptions<ImageServiceOptions> options, IFileSystem fileSystem)
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

            return $"https://localhost:5001/{_options.FolderToSave}/{filename}";
        }

        private static string GetRandomFileName => DateTime.Now.Ticks.ToString();
    }
}

using System;
using System.IO;
using System.IO.Abstractions;
using System.Threading.Tasks;
using FridgeManager.ProductsMicroService.Contracts;
using FridgeManager.ProductsMicroService.Models.Options;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace FridgeManager.ProductsMicroService.Services
{
    public class ImageService : IImageService, IDisposable
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ImageServiceOptions _options;
        private readonly IFileSystem _fileSystem;
        private readonly StorageClient _storageClient;

        public ImageService(IWebHostEnvironment webHostEnvironment, IOptions<ImageServiceOptions> options, IFileSystem fileSystem)
        {
            _environment = webHostEnvironment;
            _fileSystem = fileSystem;
            _options = options.Value;
            _storageClient = StorageClient.Create(GoogleCredential.FromFile(_options.PathToCredentialFile));
        }

        public async Task<string> AddImageGetPath(IFormFile image)
        {
            if (image is null)
            {
                throw new ArgumentException("Image must not be null", nameof(image));
            }

            string path;

            try
            {
                path = await UploadToCloud(image);
            }
            catch
            {
                path = await UploadLocally(image);
            }

            return path;
        }

        private async Task<string> UploadToCloud(IFormFile image)
        {
            using var stream = new MemoryStream();
            await image.CopyToAsync(stream);
            var fileName = GetRandomFileName(image);

            var created = await _storageClient.UploadObjectAsync(_options.BucketName, fileName, null, stream);

            return created.MediaLink;
        }

        private async Task<string> UploadLocally(IFormFile image)
        {
            string folderToSave = Path.Combine(_environment.WebRootPath, _options.FolderToSave);

            string filename = GetRandomFileName(image);

            await using (var stream = _fileSystem.File.Create(Path.Combine(folderToSave, filename)))
            {
                await image.CopyToAsync(stream);
            }

            return $"https://localhost:5002/{_options.FolderToSave}/{filename}";
        }

        public void Dispose()
            => _storageClient.Dispose();

        private static string GetRandomFileName(IFormFile file) => $"{DateTime.Now.Ticks}{Path.GetExtension(file.FileName)}";
    }
}

using System.Collections.Generic;
using System.IO;
using System.Linq;
using Entities.DTO.Products;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace zFridge.API.Validators.Products
{
    public class ProductForManipulationDtoValidator : AbstractValidator<ProductForManipulationDto>
    {
        private const double MaxImageSizeMB = 1;

        private readonly Dictionary<string, List<byte[]>> _fileSignatures = new()
        {

            {".png", new List<byte[]>
            {
                new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A },
            } },

            {".bmp", new List<byte[]>
            {
                new byte[] { 0x42, 0x4D },
            } },

            {".jpeg", new List<byte[]>
            {
                new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 },
                new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 },
            } },

            {".jpg", new List<byte[]>
            {
                new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                new byte[] { 0xFF, 0xD8, 0xFF, 0xE1 },
                new byte[] { 0xFF, 0xD8, 0xFF, 0xE8 },
            } },
        };

        public ProductForManipulationDtoValidator()
        {
            RuleFor(product => product.Name)
                .NotEmpty();

            RuleFor(product => product.DefaultQuantity)
                .GreaterThan(0);

            RuleFor(product => product.Image)
                .Must(ValidImageExtension).WithMessage("Wrong image extension")
                .Must(ValidImageSize).WithMessage($"Image size must be less than {MaxImageSizeMB}MB")
                .When(product => product.Image is not null);
        }

        private bool ValidImageExtension(IFormFile file)
        {
            var ext = Path.GetExtension(file.FileName).ToLower();

            if (!_fileSignatures.ContainsKey(ext))
            {
                return false;
            }

            using var reader = new BinaryReader(file.OpenReadStream());

            var signatures = _fileSignatures[ext];

            var headerBytes = reader.ReadBytes(signatures.Max(m => m.Length));

            return signatures.Any(signature => headerBytes.Take(signature.Length).SequenceEqual(signature));
        }

        private bool ValidImageSize(IFormFile file)
        {
            return !(file.Length > 1048576 * MaxImageSizeMB); // 1 MB * MaxImageSize
        }
    }
}

using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using ProductsService.Models;

namespace ProductsService.Validators
{
    public class ProductForManipulationValidator : AbstractValidator<ProductForManipulation>
    {
        private const double MaxImageSizeMb = 1;

        private readonly Dictionary<string, List<byte[]>> _fileSignatures = new()
        {

            {
                ".png",
                new List<byte[]>
            {
                new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A },
            }
            },
            {
                ".bmp",
                new List<byte[]>
            {
                new byte[] { 0x42, 0x4D },
            }
            },
            {
                ".jpeg",
                new List<byte[]>
            {
                new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 },
                new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 },
            }
            },
            {
                ".jpg",
                new List<byte[]>
            {
                new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                new byte[] { 0xFF, 0xD8, 0xFF, 0xE1 },
                new byte[] { 0xFF, 0xD8, 0xFF, 0xE8 },
            }
            },
        };

        public ProductForManipulationValidator()
        {
            RuleFor(product => product.Name)
                .NotNull().NotEmpty();

            RuleFor(product => product.DefaultQuantity)
                .GreaterThan(0);

            RuleFor(product => product.Image)
                .Must(IsValidImageExtension).WithMessage("Wrong image extension")
                .Must(IsValidImageSize).WithMessage($"Image size must be less than {MaxImageSizeMb}MB")
                .When(product => product.Image is not null);
        }

        private bool IsValidImageExtension(IFormFile file)
        {
            var fileExtension= Path.GetExtension(file.FileName).ToLower();

            if (!_fileSignatures.ContainsKey(fileExtension))
            {
                return false;
            }

            using var reader = new BinaryReader(file.OpenReadStream());

            var validSignatures = _fileSignatures[fileExtension];

            var fileHeaderBytes = reader.ReadBytes(validSignatures.Max(m => m.Length));

            return validSignatures.Any(signature => fileHeaderBytes.Take(signature.Length).SequenceEqual(signature));
        }

        private static bool IsValidImageSize(IFormFile file)
            => !(file.Length > 1048576 * MaxImageSizeMb); // 1 MB * MaxImageSize
    }
}

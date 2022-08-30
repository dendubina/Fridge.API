using Microsoft.AspNetCore.Http;

namespace Entities.DTO.Products
{
    public class ProductForManipulationDto
    {
        public string Name { get; set; }

        public int DefaultQuantity { get; set; }

        public IFormFile Image { get; set; }
    }
}

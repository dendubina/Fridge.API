using Microsoft.AspNetCore.Http;

namespace Fridge.ProductsService.Models
{
    public class ProductForManipulation
    {
        public string Name { get; set; }

        public int DefaultQuantity { get; set; }

        public IFormFile Image { get; set; }
    }
}

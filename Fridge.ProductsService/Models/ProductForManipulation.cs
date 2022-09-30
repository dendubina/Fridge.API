using Microsoft.AspNetCore.Http;

namespace FridgeManager.ProductsMicroService.Models
{
    public class ProductForManipulation
    {
        public string Name { get; set; }

        public int DefaultQuantity { get; set; }

        public IFormFile Image { get; set; }
    }
}

using System;

namespace Fridge.ProductsService.Models
{
    public class ProductForReturn
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ImageSource { get; set; }

        public int DefaultQuantity { get; set; }
    }
}

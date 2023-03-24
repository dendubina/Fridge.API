using System;
using System.ComponentModel.DataAnnotations;

namespace ProductsService.EF.Entities
{
    public class Product
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int DefaultQuantity { get; set; }

        public string ImageSource { get; set; }
    }
}

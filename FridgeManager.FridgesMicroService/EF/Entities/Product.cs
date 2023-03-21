using System;
using System.ComponentModel.DataAnnotations;

namespace FridgesService.EF.Entities
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

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int DefaultQuantity { get; set; }

        public string ImageSource { get; set; }

        public ICollection<FridgeProduct> Fridges { get; set; }
    }
}

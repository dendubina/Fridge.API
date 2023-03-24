using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FridgesService.EF.Entities
{
    public class FridgeProduct
    {
        public Guid Id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [ForeignKey(nameof(Fridge))]
        public Guid FridgeId { get; set; }

        [Required]
        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }

        public Fridge Fridge { get; set; }

        public Product Product { get; set; }
    }
}

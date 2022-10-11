using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FridgeManager.FridgesMicroService.EF.Entities
{
    public class Fridge
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string OwnerName { get; set; }

        [Required]
        [ForeignKey(nameof(FridgeModel))]
        public Guid FridgeModelId { get; set; }

        public FridgeModel FridgeModel { get; set; }

        public ICollection<FridgeProduct> Products { get; set; }
    }
}

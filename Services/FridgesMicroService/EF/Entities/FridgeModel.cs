using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FridgesService.EF.Entities
{
    public class FridgeModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Year { get; set; }

        public ICollection<Fridge> Fridges { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public class FridgeModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public ICollection<Fridge> Fridges { get; set; }
    }
}

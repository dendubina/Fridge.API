using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public class Fridge
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public Guid FridgeModelId { get; set; }
        public FridgeModel FridgeModel { get; set; }
        public ICollection<FridgeProduct> Products { get; set; }
    }
}

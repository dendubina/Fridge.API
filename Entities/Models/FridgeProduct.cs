using System;

namespace Entities.Models
{
    public class FridgeProduct
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public Guid FridgeId { get; set; }
        public Guid ProductId { get; set; }
        public Fridge Fridge { get; set; }
    }
}

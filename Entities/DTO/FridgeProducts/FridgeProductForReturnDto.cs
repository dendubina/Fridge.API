using System;

namespace Entities.DTO.FridgeProducts
{
    public class FridgeProductForReturnDto
    {
        public Guid FridgeId { get; set; }

        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }
    }
}

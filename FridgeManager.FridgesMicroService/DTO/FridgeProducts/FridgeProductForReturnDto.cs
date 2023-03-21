using System;

namespace FridgesService.DTO.FridgeProducts
{
    public class FridgeProductForReturnDto
    {
        public Guid Id { get; set; }

        public Guid FridgeId { get; set; }

        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public string ImageSource { get; set; }

        public int Quantity { get; set; }
    }
}

using System;

namespace FridgeManager.FridgesMicroService.DTO.FridgeProducts
{
    public class FridgeProductForManipulationDto
    {
        public Guid ProductId { get; set; }

        public int Quantity { get; set; }
    }
}

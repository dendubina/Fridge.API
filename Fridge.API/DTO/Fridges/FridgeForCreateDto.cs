using System.Collections.Generic;
using FridgeManager.FridgesMicroService.DTO.FridgeProducts;

namespace FridgeManager.FridgesMicroService.DTO.Fridges
{
    public class FridgeForCreateDto 
    {
        public string Name { get; set; }

        public string OwnerName { get; set; }

        public string ModelName { get; set; }

        public int ModelYear { get; set; }

        public IEnumerable<FridgeProductForManipulationDto> FridgeProducts { get; set; }
    }
}

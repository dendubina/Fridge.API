using System.Collections.Generic;
using FridgesService.DTO.FridgeProducts;

namespace FridgesService.DTO.Fridges
{
    public class FridgeForCreateDto 
    {
        public string Name { get; set; }

        public string ModelName { get; set; }

        public int ModelYear { get; set; }

        public IEnumerable<FridgeProductForManipulationDto> FridgeProducts { get; set; }
    }
}

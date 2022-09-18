using System.Collections.Generic;
using Entities.DTO.FridgeProducts;

namespace Entities.DTO.Fridges
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

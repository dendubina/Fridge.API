using System;
using System.Collections.Generic;
using Entities.DTO.FridgeProducts;

namespace Entities.DTO.Fridges
{
    public class FridgeForReturnDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string OwnerName { get; set; }

        public string ModelName { get; set; }

        public int ModelYear { get; set; }

        public IEnumerable<FridgeProductForReturnDto> FridgeProducts { get; set; }
    }
}

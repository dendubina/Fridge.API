using System;
using System.Collections.Generic;
using FridgesService.DTO.FridgeProducts;
using FridgesService.DTO.Owner;

namespace FridgesService.DTO.Fridges
{
    public class FridgeForReturnDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ModelName { get; set; }

        public int ModelYear { get; set; }

        public IEnumerable<FridgeProductForReturnDto> FridgeProducts { get; set; }

        public OwnerForReturnDto Owner { get; set; }
    }
}

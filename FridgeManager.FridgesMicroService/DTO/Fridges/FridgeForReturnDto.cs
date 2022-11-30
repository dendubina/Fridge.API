using System;
using System.Collections.Generic;
using FridgeManager.FridgesMicroService.DTO.FridgeProducts;
using FridgeManager.FridgesMicroService.DTO.Owner;

namespace FridgeManager.FridgesMicroService.DTO.Fridges
{
    public class FridgeForReturnDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string OwnerName { get; set; }

        public string ModelName { get; set; }

        public int ModelYear { get; set; }

        public IEnumerable<FridgeProductForReturnDto> FridgeProducts { get; set; }

        public OwnerForReturnDto Owner { get; set; }
    }
}

using System;

namespace Entities.DTO.Fridge
{
    public class FridgeDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string OwnerName { get; set; }

        public string ModelName { get; set; }

        public int ModelYear { get; set; }
    }
}

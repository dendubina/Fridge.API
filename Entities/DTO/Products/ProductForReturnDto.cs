using System;

namespace Entities.DTO.Products
{
    public class ProductForReturnDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int DefaultQuantity { get; set; }
    }
}

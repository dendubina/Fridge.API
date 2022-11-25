using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FridgeManager.ReportAzureFunction.Models
{
    internal class Fridge
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string OwnerName { get; set; }

        public string OwnerEmail { get; set; }

        public string ModelName { get; set; }

        public int ModelYear { get; set; }

        [JsonPropertyName("fridgeProducts")]
        public IEnumerable<Product> Products { get; set; }
    }
}

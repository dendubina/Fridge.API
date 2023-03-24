using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ReportAzureFunction.Models
{
    internal class Fridge
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ModelName { get; set; }

        public int ModelYear { get; set; }

        public Owner Owner { get; set; }

        [JsonPropertyName("fridgeProducts")]
        public IEnumerable<Product> Products { get; set; }
    }
}

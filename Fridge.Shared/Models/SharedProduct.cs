using System;
using Fridge.Shared.Models.Constants;

namespace Fridge.Shared.Models
{
    public class SharedProduct
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int DefaultQuantity { get; set; }

        public string ImageSource { get; set; }

        public ActionType ActionType { get; set; }
    }
}

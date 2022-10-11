using System;
using FridgeManager.Shared.Models.Constants;

namespace FridgeManager.Shared.Models
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

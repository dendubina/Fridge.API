using Entities.DTO.FridgeProducts;
using FluentValidation;

namespace Entities.Validators.FridgeProducts
{
    public class FridgeProductForManipulationDtoValidator : AbstractValidator<FridgeProductForManipulationDto>
    {
        public FridgeProductForManipulationDtoValidator()
        {
            RuleFor(fridgeProduct => fridgeProduct.Quantity).GreaterThan(0);
        }
    }
}

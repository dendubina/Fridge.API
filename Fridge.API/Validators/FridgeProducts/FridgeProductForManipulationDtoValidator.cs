using Entities.DTO.FridgeProducts;
using FluentValidation;

namespace zFridge.API.Validators.FridgeProducts
{
    public class FridgeProductForManipulationDtoValidator : AbstractValidator<FridgeProductForManipulationDto>
    {
        public FridgeProductForManipulationDtoValidator()
        {
            RuleFor(fridgeProduct => fridgeProduct.Quantity).GreaterThan(0);
        }
    }
}

using FluentValidation;
using FridgesService.DTO.FridgeProducts;

namespace FridgesService.Validators.FridgeProducts
{

    public class FridgeProductForManipulationDtoValidator : AbstractValidator<FridgeProductForManipulationDto>
    {
        public FridgeProductForManipulationDtoValidator()
        {
            RuleFor(fridgeProduct => fridgeProduct.Quantity)
                .GreaterThan(0);
        }
    }
}

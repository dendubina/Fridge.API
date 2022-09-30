using FluentValidation;
using FridgeManager.FridgesMicroService.DTO.FridgeProducts;

namespace FridgeManager.FridgesMicroService.Validators.FridgeProducts
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

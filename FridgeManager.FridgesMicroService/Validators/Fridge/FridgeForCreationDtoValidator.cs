using FluentValidation;
using FridgesService.DTO.Fridges;
using FridgesService.Validators.FridgeProducts;

namespace FridgesService.Validators.Fridge
{
    public class FridgeForCreationDtoValidator : AbstractValidator<FridgeForCreateDto>
    {
        public FridgeForCreationDtoValidator()
        {
            RuleFor(fridge => fridge.Name)
                .NotNull()
                .NotEmpty();

            RuleFor(fridge => fridge.ModelName)
                .NotNull()
                .NotEmpty();

            RuleFor(fridge => fridge.ModelYear)
                .GreaterThan(0)
                .WithMessage("ModelYear must be greater than 0");

            RuleForEach(fridge => fridge.FridgeProducts)
                .SetValidator(new FridgeProductForManipulationDtoValidator())
                .When(fridge => fridge.FridgeProducts is not null);
        }
    }
}

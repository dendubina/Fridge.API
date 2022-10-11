using FluentValidation;
using FridgeManager.FridgesMicroService.DTO.Fridges;
using FridgeManager.FridgesMicroService.Validators.FridgeProducts;

namespace FridgeManager.FridgesMicroService.Validators.Fridge
{
    public class FridgeForCreationDtoValidator : AbstractValidator<FridgeForCreateDto>
    {
        public FridgeForCreationDtoValidator()
        {
            RuleFor(fridge => fridge.Name)
                .NotNull()
                .Length(3, 20).WithMessage("Name length must be between 3 and 20 chars");

            RuleFor(fridge => fridge.OwnerName)
                .NotNull()
                .Length(3, 20).WithMessage("OwnerName length must be between 3 and 20 chars");

            RuleFor(fridge => fridge.ModelName)
                .NotNull()
                .Length(3, 20).WithMessage("ModelName length must be between 3 and 20 chars");

            RuleFor(fridge => fridge.ModelYear)
                .GreaterThan(0)
                .WithMessage("ModelYear must be greater than 0");

            RuleForEach(fridge => fridge.FridgeProducts)
                .SetValidator(new FridgeProductForManipulationDtoValidator())
                .When(fridge => fridge.FridgeProducts is not null);
        }
    }
}

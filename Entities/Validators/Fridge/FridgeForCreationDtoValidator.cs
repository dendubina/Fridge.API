using Entities.DTO.Fridges;
using FluentValidation;

namespace Entities.Validators.Fridge
{
    public class FridgeForCreationDtoValidator : AbstractValidator<FridgeForCreateDto>
    {
        public FridgeForCreationDtoValidator()
        {
            RuleFor(fridge => fridge.Name).NotNull();
            RuleFor(fridge => fridge.Name).Length(3, 20).WithMessage("Name length must be between 3 and 20 chars");

            RuleFor(fridge => fridge.OwnerName).NotNull();
            RuleFor(fridge => fridge.OwnerName).Length(3, 20).WithMessage("OwnerName length must be between 3 and 20 chars");

            RuleFor(fridge => fridge.ModelName).NotNull();
            RuleFor(fridge => fridge.ModelName).Length(3, 20).WithMessage("ModelName length must be between 3 and 20 chars");

            RuleFor(fridge => fridge.ModelYear).GreaterThan(0).WithMessage("ModelYear must be > 0");
        }
    }
}

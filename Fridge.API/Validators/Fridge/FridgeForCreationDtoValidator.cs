using System.Threading.Tasks;
using Contracts.Interfaces;
using Entities.DTO.FridgeProducts;
using Entities.DTO.Fridges;
using FluentValidation;
using zFridge.API.Validators.FridgeProducts;

namespace zFridge.API.Validators.Fridge
{
    public class FridgeForCreationDtoValidator : AbstractValidator<FridgeForCreateDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public FridgeForCreationDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

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
                .WithMessage("ModelYear must be > 0");

            RuleForEach(fridge => fridge.FridgeProducts)
                .SetValidator(new FridgeProductForManipulationDtoValidator())
                .MustAsync((fridge, cancellation) => IsProductExists(fridge)).WithMessage("Product doesn't exists in database")
                .When(fridge => fridge.FridgeProducts is not null);
        }

        private async Task<bool> IsProductExists(FridgeProductForManipulationDto fridgeProduct)
        {
            var product = await _unitOfWork.Products.GetProductAsync(fridgeProduct.ProductId, trackChanges: false);

            return product is not null;
        }
    }
}

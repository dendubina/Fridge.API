using System;
using System.Threading.Tasks;
using Contracts.Interfaces;
using Entities.DTO.FridgeProducts;
using FluentValidation;

namespace Fridge.API.Validators.FridgeProducts
{

    public class FridgeProductForManipulationDtoValidator : AbstractValidator<FridgeProductForManipulationDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public FridgeProductForManipulationDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(fridgeProduct => fridgeProduct.Quantity)
                .GreaterThan(0);

            RuleFor(x => x.ProductId)
                .MustAsync((id, cancellation) => IsProductExists(id))
                .WithMessage("Product doesn't exists in database");
        }

        private async Task <bool> IsProductExists(Guid productId)
        {
            var product = await _unitOfWork.Products.GetProductAsync(productId, trackChanges: false);

            return product is not null;
        }
    }
}

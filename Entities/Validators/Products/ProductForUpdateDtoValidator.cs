using Entities.DTO.Products;
using FluentValidation;

namespace Entities.Validators.Products
{
    public class ProductForUpdateDtoValidator : AbstractValidator<ProductForUpdateDto>
    {
        public ProductForUpdateDtoValidator()
        {
            RuleFor(product => product.DefaultQuantity).GreaterThan(0);
        }
    }
}

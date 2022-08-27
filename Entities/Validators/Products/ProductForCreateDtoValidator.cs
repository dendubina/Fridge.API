﻿using Entities.DTO.Products;
using FluentValidation;

namespace Entities.Validators.Products
{
    public class ProductForCreateDtoValidator : AbstractValidator<ProductForCreateDto>
    {
        public ProductForCreateDtoValidator()
        {
            RuleFor(product => product.Name).NotNull().NotEmpty();

            RuleFor(product => product.DefaultQuantity).GreaterThan(0);
        }
    }
}

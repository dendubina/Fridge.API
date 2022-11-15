using FluentValidation;
using FridgeManager.AuthMicroService.Models;

namespace FridgeManager.AuthMicroService.Validators
{
    public class SignUpModelValidator : AbstractValidator<SignUpModel>
    {
        public SignUpModelValidator()
        {
            RuleFor(x => x.UserName)
                .NotNull().NotEmpty()
                .MinimumLength(3);

            RuleFor(x => x.Email)
                .NotNull().NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotNull().NotEmpty()
                .Equal(x => x.Password);
        }
    }
}

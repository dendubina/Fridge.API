using FluentValidation;
using FridgeManager.AuthMicroService.Models;

namespace FridgeManager.AuthMicroService.Validators
{
    public class SignInModelValidator : AbstractValidator<SignInModel>
    {
        public SignInModelValidator()
        {
            RuleFor(x => x.UserName)
                .NotNull().NotEmpty();

            RuleFor(x => x.Password)
                .NotNull().NotEmpty();
        }
    }
}

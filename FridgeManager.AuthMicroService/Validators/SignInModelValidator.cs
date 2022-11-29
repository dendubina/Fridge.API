using FluentValidation;
using FridgeManager.AuthMicroService.Models.Request;

namespace FridgeManager.AuthMicroService.Validators
{
    public class SignInModelValidator : AbstractValidator<SignInModel>
    {
        public SignInModelValidator()
        {
            RuleFor(x => x.Email)
                .NotNull().NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotNull().NotEmpty();
        }
    }
}

using AuthService.Models.Request;
using FluentValidation;

namespace AuthService.Validators
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

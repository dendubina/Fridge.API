using AuthService.Models.Request;
using FluentValidation;

namespace AuthService.Validators
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

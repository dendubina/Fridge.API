using AuthService.Models.Request;
using FluentValidation;

namespace AuthService.Validators
{
    public class EmailConfirmModelValidator : AbstractValidator<EmailConfirmModel>
    {
        public EmailConfirmModelValidator()
        {
            RuleFor(x => x.UserId)
                .NotNull().NotEmpty();

            RuleFor(x => x.Token)
                .NotNull().NotEmpty();
        }
    }
}

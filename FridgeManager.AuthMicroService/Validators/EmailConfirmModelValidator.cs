using FluentValidation;
using FridgeManager.AuthMicroService.Models;

namespace FridgeManager.AuthMicroService.Validators
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

using FluentValidation;
using FridgeManager.AuthMicroService.Models.DTO;

namespace FridgeManager.AuthMicroService.Validators
{
    public class UserToUpdateValidator : AbstractValidator<UserToUpdate>
    {
        public UserToUpdateValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().NotEmpty();

            RuleFor(x => x.UserName)
                .NotNull().NotEmpty();

            RuleFor(x => x.Email)
                .NotNull().NotEmpty()
                .EmailAddress();
        }
    }
}

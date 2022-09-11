using Entities.DTO.User;
using FluentValidation;

namespace Fridge.API.Validators.User
{
    public class UserSignInDtoValidator : AbstractValidator<UserSignInDto>
    {

        public UserSignInDtoValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty();

            RuleFor(x => x.Password)
                .MinimumLength(3);
        }
    }
}

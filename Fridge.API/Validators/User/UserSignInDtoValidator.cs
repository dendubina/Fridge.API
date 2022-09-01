using Contracts.Interfaces;
using Entities.DTO.User;
using FluentValidation;

namespace zFridge.API.Validators.User
{
    public class UserSignInDtoValidator : AbstractValidator<UserSignInDto>
    {

        public UserSignInDtoValidator(IAuthService authService)
        {
            RuleFor(x => x.UserName)
                .NotEmpty();

            RuleFor(x => x.Password)
                .MinimumLength(3);
        }
    }
}

using Entities.DTO.User;
using FluentValidation;

namespace zFridge.API.Validators.User
{
    public class UserSignUpDtoValidator : AbstractValidator<UserSignUpDto>
    {
        public UserSignUpDtoValidator()
        {
            RuleFor(x => x.UserName)
                .MinimumLength(3);

            RuleFor(x => x.Password)
                .MinimumLength(3)
                .Equal(x => x.PasswordConfirm);

        }
    }
}

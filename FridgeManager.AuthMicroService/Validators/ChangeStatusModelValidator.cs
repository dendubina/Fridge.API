using AuthService.EF.Constants;
using AuthService.Models.Request;
using FluentValidation;

namespace AuthService.Validators
{
    public class ChangeStatusModelValidator : AbstractValidator<ChangeStatusModel>
    {
        public ChangeStatusModelValidator()
        {
            RuleFor(x => x.Status)
                .NotNull().NotEmpty()
                .IsEnumName(typeof(UserStatus), caseSensitive: false);
        }
    }
}

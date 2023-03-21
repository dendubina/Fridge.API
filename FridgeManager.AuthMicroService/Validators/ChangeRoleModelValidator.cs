using AuthService.EF.Constants;
using AuthService.Models.Request;
using FluentValidation;

namespace AuthService.Validators
{
    public class ChangeRoleModelValidator : AbstractValidator<ChangeRoleModel>
    {
        public ChangeRoleModelValidator()
        {
            RuleFor(x => x.Role)
                .NotNull().NotEmpty()
                .IsEnumName(typeof(RoleNames), caseSensitive: false);
        }
    }
}

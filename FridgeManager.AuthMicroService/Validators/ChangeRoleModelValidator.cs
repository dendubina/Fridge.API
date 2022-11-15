using FluentValidation;
using FridgeManager.AuthMicroService.EF.Constants;
using FridgeManager.AuthMicroService.Models;

namespace FridgeManager.AuthMicroService.Validators
{
    public class ChangeRoleModelValidator : AbstractValidator<ChangeRoleModel>
    {
        public ChangeRoleModelValidator()
        {
            RuleFor(x => x.Role)
                .NotNull()
                .NotEmpty()
                .IsEnumName(typeof(RoleNames), caseSensitive: false);
        }
    }
}

using FluentValidation;
using FridgeManager.AuthMicroService.EF.Constants;
using FridgeManager.AuthMicroService.Models.Request;

namespace FridgeManager.AuthMicroService.Validators
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

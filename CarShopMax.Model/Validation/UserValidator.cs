using FluentValidation;

namespace CarShopMax.Model.Validation;

public class UserValidator : AbstractValidator<User>
{

    public UserValidator()
    {
        RuleFor(procedure => procedure.Email).NotNull().NotEmpty().MinimumLength(10).MaximumLength(60);
        RuleFor(procedure => procedure.Password).NotNull().NotEmpty().MinimumLength(10).MaximumLength(50);
    }

}

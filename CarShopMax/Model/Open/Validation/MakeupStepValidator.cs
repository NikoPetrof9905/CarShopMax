using FluentValidation;

namespace CarShopMax.Model.Open.Validation;

public class MakeupStepValidator : AbstractValidator<MakeupStep>
{

    /// <summary>
    /// FluentValidation validator for the object.
    /// </summary>
    public MakeupStepValidator()
    {
        RuleFor(procedure => procedure.Name).NotNull().NotEmpty().MinimumLength(3).MaximumLength(20);
        RuleFor(procedure => procedure.Description).NotNull().NotEmpty().MinimumLength(0).MaximumLength(200);
        RuleFor(procedure => procedure.Color).NotNull().NotEmpty();
    }

}

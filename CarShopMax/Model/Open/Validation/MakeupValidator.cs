using FluentValidation;

namespace CarShopMax.Model.Open.Validation;

public class MakeupValidator : AbstractValidator<Makeup>
{

    /// <summary>
    /// FluentValidation validator for the object.
    /// </summary>
    public MakeupValidator()
    {
        RuleFor(procedure => procedure.Name).NotNull().NotEmpty().MinimumLength(3).MaximumLength(20);
        RuleFor(procedure => procedure.Description).NotNull().NotEmpty().MinimumLength(0).MaximumLength(200);
        RuleForEach(procedure => procedure.Steps).SetValidator(new MakeupStepValidator());
    }

}

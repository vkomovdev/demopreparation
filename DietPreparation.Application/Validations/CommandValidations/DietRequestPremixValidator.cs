using DietPreparation.Common.Enums;
using DietPreparation.Common.Extensions;
using DietPreparation.Models.DTO;
using DietPreparation.Utilities.Validator;
using FluentValidation;

namespace DietPreparation.Application.Validations.CommandValidations;

public class DietRequestPremixValidator : Validator<DietRequestPremixDto>
{
	public DietRequestPremixValidator()
	{
		RuleFor(s => s.Id)
			.GreaterThanOrEqualTo(0)
			.WithErrorCodeMustBeNonNegative();

		RuleFor(s => s.Premix)
			.Must(s => s!.IsDeleted == false)
			.Must(s => s!.PremixUsed == false)
			.When(s => s != null && s.Premix != null)
			.WithErrorCodePremixMustBeActive();

		RuleFor(s => s.Amount)
			.NotNull()
			.GreaterThan(0)
			.WithErrorCodeMustBeNonNegative();

		RuleFor(s => s.UnitOfMeasure)
			.In(UnitOfMeasure.Gram, UnitOfMeasure.Kilogram, UnitOfMeasure.Pound)
			.WithErrorCodeInvalidValue();
	}
}

using DietPreparation.Common.Consts;
using DietPreparation.Common.Enums;
using DietPreparation.Common.Extensions;
using DietPreparation.Models.DTO;
using DietPreparation.Utilities.Validator;
using FluentValidation;

namespace DietPreparation.Application.Validations.CommandValidations;

public class DietRequestDrugValidator : Validator<DietRequestDrugDto>
{
	public DietRequestDrugValidator()
	{
		RuleFor(s => s.Id)
			.GreaterThanOrEqualTo(0)
			.WithErrorCodeRequired();

		RuleFor(s => s.Drug)
			.Must(s => s!.IsActive)
			.When(s => s != null && s.Drug != null)
			.WithErrorCodeDrugMustBeActive();

		RuleFor(s => s.Amount)
			.NotNull()
			.GreaterThan(0)
			.WithErrorCodeMustBeNonNegative();

		RuleFor(s => s.UnitOfMeasure)
			.In(UnitOfMeasure.Milligram, UnitOfMeasure.Gram, UnitOfMeasure.Kilogram, UnitOfMeasure.Pound)
			.WithErrorCodeInvalidValue();

		RuleFor(s => s.MfgLot)
			.NotNull()
			.MaximumLength(FieldLengthes.Small)
			.WithErrorCodeRequired();
	}
}

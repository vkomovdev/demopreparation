using DietPreparation.Common.Consts;
using DietPreparation.Common.Enums;
using DietPreparation.Common.Extensions;
using DietPreparation.Models.DTO;
using DietPreparation.Utilities.Validator;
using FluentValidation;

namespace DietPreparation.Application.Validations.CommandValidations;

public class DietRequestSampleValidator : Validator<DietRequestSampleDto>
{
	public DietRequestSampleValidator()
	{
		RuleFor(s => s.Id)
			.GreaterThanOrEqualTo(0)
			.WithErrorCodeMustBeNonNegative();

		RuleFor(s => s.Amount)
			.NotNull()
			.GreaterThan(0)
			.WithErrorCodeMustBeNonNegative();

		RuleFor(s => s.UnitOfMeasure)
			.In(UnitOfMeasure.Gram, UnitOfMeasure.Kilogram, UnitOfMeasure.Pound)
			.WithErrorCodeInvalidValue();

		RuleFor(s => s.AnalysisType)
			.NotNull()
			.WithErrorCodeRequired();

		RuleFor(s => s.Disposition)
			.MaximumLength(FieldLengthes.ExtraExtraSmall)
			.WithErrorCodeInvalidLength();

		RuleFor(s => s.Comment)
			.MaximumLength(FieldLengthes.Large)
			.WithErrorCodeInvalidLength();
	}
}
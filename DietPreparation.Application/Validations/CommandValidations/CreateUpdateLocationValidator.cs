using DietPreparation.Common.Consts;
using DietPreparation.Models.DTO;
using DietPreparation.Utilities.Validator;
using FluentValidation;

namespace DietPreparation.Application.Validations.CommandValidations;

public class CreateUpdateLocationValidator : Validator<LocationUpdateDto>
{
	public CreateUpdateLocationValidator()
	{
		RuleFor(s => s.Description)
			.NotEmpty()
			.WithErrorCodeRequired()
			.MaximumLength(FieldLengthes.Middle)
			.WithErrorCodeInvalidLength();

		RuleFor(s => s.Building)
			.NotEmpty()
			.WithErrorCodeRequired()
			.MaximumLength(FieldLengthes.ExtraExtraSmall)
			.WithErrorCodeInvalidLength();

		RuleFor(s => s.Floor)
			.MaximumLength(FieldLengthes.ExtraExtraSmall)
			.WithErrorCodeInvalidLength();
		RuleFor(s => s.Lab)
			.MaximumLength(FieldLengthes.ExtraExtraSmall)
			.WithErrorCodeInvalidLength();

		RuleFor(s => s.BusinessUnit)
			.GreaterThanOrEqualTo(0)
			.WithErrorCodeMustBeNonNegative();
	}
}
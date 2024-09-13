using DietPreparation.Application.Commands.Requests;
using DietPreparation.Common.Consts;
using DietPreparation.Utilities.Validator;
using FluentValidation;

namespace DietPreparation.Application.Validations.CommandValidations;

public class CreateBasalDietValidator : Validator<CreateBasalDietRequest>
{
	public CreateBasalDietValidator()
	{
		RuleFor(s => s.Code)
			.NotEmpty()
			.WithErrorCodeRequired()
			.MaximumLength(FieldLengthes.Middle)
			.WithErrorCodeInvalidLength();

		RuleFor(s => s.Name)
			.NotEmpty()
			.WithErrorCodeRequired()
			.MaximumLength(FieldLengthes.Middle)
			.WithErrorCodeInvalidLength();

		RuleFor(s => s.DateCreate)
			.LessThanOrEqualTo(DateTime.Now)
			.WithErrorCodeInvalidValue();

		RuleFor(s => s.BasalDietIngredients)
			.NotEmpty()
			.WithErrorCodeRequired();

		RuleFor(s => s)
			.Must(HasSumPercentOfIngredientsEqualsOneHundred)
			.WithErrorCodeMustBeTotalAmountGreaterThanSamplesAmount();
	}

	private bool HasSumPercentOfIngredientsEqualsOneHundred(CreateBasalDietRequest dto)
	{
		var percentSum = dto.BasalDietIngredients?.Sum(x => x.PercentOfDiet) ?? 0;

		return Math.Round(percentSum, DefaultNumbers.DecimalDigitsCount) == 100;
	}
}

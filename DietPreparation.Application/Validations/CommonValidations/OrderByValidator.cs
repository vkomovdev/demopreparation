using DietPreparation.Common.Consts;
using DietPreparation.Common.Extensions;
using DietPreparation.Models.DTO.FilterOptions;
using DietPreparation.Utilities.Validator;
using FluentValidation;

namespace DietPreparation.Application.Validations.CommonValidations;

public class OrderByValidator : Validator<OrderByDto>
{
	public OrderByValidator()
	{
		RuleFor(s => s.Slope)
			.NotEmpty()
			.WithErrorCodeRequired()
			.Must(value => value.In(DefaultStrings.Asc, DefaultStrings.Desc))
			.WithErrorCodeIncorrectSlope();
	}
}
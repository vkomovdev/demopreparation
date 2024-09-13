using DietPreparation.Application.Queries.Requests.PWOs;
using DietPreparation.Application.Validations.CommonValidations;
using DietPreparation.Utilities.Validator;
using FluentValidation;

namespace DietPreparation.Application.Validations.QueryValidations;

public class GetDietRequestSearchQueryValidator : Validator<GetDietRequestSearchQueryRequest>
{
	public GetDietRequestSearchQueryValidator()
	{
		RuleFor(s => s.FilterBy)
			.NotNull()
			.WithErrorCodeRequired();

		RuleFor(s => s.OrderBy!)
			.SetValidator(new OrderByValidator());

		RuleFor(x => x.FilterBy!.LotYear)
			.NotEmpty()
			.When(x => !string.IsNullOrEmpty(x.FilterBy!.LotNumber))
			.WithErrorCodeRequired();

	}
}
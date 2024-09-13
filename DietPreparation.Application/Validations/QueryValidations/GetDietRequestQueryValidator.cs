using DietPreparation.Application.Queries.Requests.DietRequests;
using DietPreparation.Utilities.Validator;
using FluentValidation;

namespace DietPreparation.Application.Validations.QueryValidations;

public class GetDietRequestQueryValidator : Validator<GetDietRequestQueryRequest>
{
	public GetDietRequestQueryValidator()
	{
		RuleFor(s => s.Id)
			.NotNull()
			.GreaterThan(0)
			.WithErrorCodeRequired();
	}
}
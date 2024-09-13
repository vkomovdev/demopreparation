using DietPreparation.Application.Queries.Requests.DietRequests;
using DietPreparation.Application.Validations.CommonValidations;
using DietPreparation.Utilities.Validator;
using FluentValidation;

namespace DietPreparation.Application.Validations.QueryValidations;

public class GetDietRequestsQueryValidator : Validator<GetDietRequestsQueryRequest>
{
	public GetDietRequestsQueryValidator()
	{
		RuleFor(s => s.FilterBy)
			.NotNull()
			.WithErrorCodeRequired();

		RuleFor(s => s.OrderBy!)
			.SetValidator(new OrderByValidator());
	}
}

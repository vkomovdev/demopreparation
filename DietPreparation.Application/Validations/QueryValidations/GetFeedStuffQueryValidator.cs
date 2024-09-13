using DietPreparation.Application.Queries.Requests.FeedStuffs;
using DietPreparation.Utilities.Validator;
using FluentValidation;

namespace DietPreparation.Application.Validations.QueryValidations;

public class GetFeedStuffQueryValidator : Validator<GetFeedStuffQueryRequest>
{
	public GetFeedStuffQueryValidator()
	{
		RuleFor(s => s.FeedStuffId)
			.NotEmpty()
			.WithErrorCodeRequired();
	}
}
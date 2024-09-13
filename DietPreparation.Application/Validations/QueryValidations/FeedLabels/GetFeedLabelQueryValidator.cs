using DietPreparation.Application.Queries.Requests.FeedLabels;
using DietPreparation.Utilities.Validator;
using FluentValidation;

namespace DietPreparation.Application.Validations.QueryValidations.FeedLabels;

public class GetFeedLabelQueryValidator : Validator<GetFeedLabelQueryRequest>
{
	public GetFeedLabelQueryValidator()
	{
		RuleFor(s => s.Id)
			.NotNull()
			.GreaterThan(0)
			.WithErrorCodeRequired();

		RuleFor(s => s.Sequence)
			.NotNull()
			.GreaterThanOrEqualTo(0)
			.WithErrorCodeRequired();
	}
}

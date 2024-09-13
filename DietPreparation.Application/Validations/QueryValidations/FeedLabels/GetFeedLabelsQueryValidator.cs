using DietPreparation.Application.Queries.Requests.FeedLabels;
using DietPreparation.Application.Validations.CommonValidations;
using DietPreparation.Utilities.Validator;
using FluentValidation;

namespace DietPreparation.Application.Validations.QueryValidations.FeedLabels;

public class GetFeedLabelsQueryValidator : Validator<GetFeedLabelsQueryRequest>
{
	public GetFeedLabelsQueryValidator()
	{
		RuleFor(x => x.FilterBy)
			.NotNull()
			.WithErrorCodeRequired();

		RuleFor(x => x.OrderBy)
			.NotNull()
			.WithErrorCodeRequired();

		RuleFor(x => x.Pagination)
			.NotNull()
			.WithErrorCodeRequired();

		RuleFor(x => x.FilterBy!.LotYear)
			.NotEmpty()
			.When(x => !string.IsNullOrEmpty(x.FilterBy!.LotNumber))
			.WithErrorCodeRequired();

		RuleFor(s => s.OrderBy!)
			.SetValidator(new OrderByValidator());
	}
}
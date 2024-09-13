using DietPreparation.Application.Queries.Requests.FeedStuffs;
using DietPreparation.Application.Validations.CommonValidations;
using DietPreparation.Utilities.Validator;

namespace DietPreparation.Application.Validations.QueryValidations;

public class GetFeedStuffsQueryValidator : Validator<GetFeedStuffsQueryRequest>
{
	public GetFeedStuffsQueryValidator()
	{
		RuleFor(s => s.OrderBy!)
			.SetValidator(new OrderByValidator());
	}
}
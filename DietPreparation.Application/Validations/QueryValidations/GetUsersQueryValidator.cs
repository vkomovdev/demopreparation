using DietPreparation.Application.Queries.Requests.Users;
using DietPreparation.Application.Validations.CommonValidations;
using DietPreparation.Utilities.Validator;

namespace DietPreparation.Application.Validations.QueryValidations;

public class GetUsersQueryValidator : Validator<GetUsersQueryRequest>
{
	public GetUsersQueryValidator()
	{
		RuleFor(s => s.OrderBy!)
			.SetValidator(new OrderByValidator());
	}
}
using DietPreparation.Application.Queries.Requests.PWOs;
using DietPreparation.Utilities.Validator;
using FluentValidation;

namespace DietPreparation.Application.Validations.QueryValidations;

public class GetPwoDetailQueryValidator : Validator<GetPwoDetailQueryRequest>
{
	public GetPwoDetailQueryValidator()
	{
		RuleFor(s => s.Sequence)
			.GreaterThanOrEqualTo(0)
			.WithErrorCodeMustBeNonNegative();

		RuleFor(s => s.RequestId)
			.GreaterThanOrEqualTo(0)
			.WithErrorCodeMustBeNonNegative();
	}
}
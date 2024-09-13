using DietPreparation.Application.Queries.Requests;
using DietPreparation.Application.Validations.CommonValidations;
using DietPreparation.Utilities.Validator;
using FluentValidation;

namespace DietPreparation.Application.Validations.QueryValidations;

public class GetAuditLogsQueryValidator : Validator<GetAuditLogsQueryRequest>
{
	public GetAuditLogsQueryValidator()
	{
		RuleFor(s => s.OrderBy)
			.NotNull()
			.WithErrorCodeRequired();

		RuleFor(s => s.OrderBy!)
			.SetValidator(new OrderByValidator())
			.When(s => s.OrderBy != null);
	}
}


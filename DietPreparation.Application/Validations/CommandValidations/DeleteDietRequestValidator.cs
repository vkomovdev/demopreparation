using DietPreparation.Application.Commands.Requests.DietRequests;
using DietPreparation.Utilities.Validator;
using FluentValidation;

namespace DietPreparation.Application.Validations.CommandValidations;

public class DeleteDietRequestValidator : Validator<DeleteDietRequestRequest>
{
	public DeleteDietRequestValidator()
	{
		RuleFor(s => s.Id)
			.NotNull()
			.GreaterThan(0);
	}
}
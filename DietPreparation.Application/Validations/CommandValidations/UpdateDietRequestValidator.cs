using DietPreparation.Application.Commands.Requests.DietRequests;
using DietPreparation.Utilities.Validator;
using FluentValidation;

namespace DietPreparation.Application.Validations.CommandValidations;

public class UpdateDietRequestValidator : Validator<UpdateDietRequestRequest>
{
	public UpdateDietRequestValidator()
	{
		Include(new CreateDietRequestValidator());
		RuleFor(s => s.Id)
			.NotNull()
			.WithErrorCodeRequired();
	}
}
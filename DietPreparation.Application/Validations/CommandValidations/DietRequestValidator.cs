using DietPreparation.Utilities.Validator;
using DietPreparation.Models.DTO;

namespace DietPreparation.Application.Validations.CommandValidations;

public class DietRequestValidator : Validator<DietRequestDto>
{
	public DietRequestValidator()
	{
		RuleForEach(s => s.Premixes)
			.SetValidator(new DietRequestPremixValidator());

		RuleForEach(s => s.Drugs)
			.SetValidator(new DietRequestDrugValidator());
	}
}

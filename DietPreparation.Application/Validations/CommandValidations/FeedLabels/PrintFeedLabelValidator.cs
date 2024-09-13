using DietPreparation.Application.Commands.Requests.FeedLabels;
using DietPreparation.Common.Consts;
using DietPreparation.Common.Extensions;
using DietPreparation.Utilities.Validator;
using FluentValidation;

namespace DietPreparation.Application.Validations.CommandValidations.FeedLabels;

public class PrintFeedLabelValidator : Validator<PrintFeedLabelRequest>
{
	public PrintFeedLabelValidator()
	{
		RuleFor(s => s.Id)
			.NotNull()
			.GreaterThan(0)
			.WithErrorCodeRequired();

		RuleFor(s => s.Sequence)
			.NotNull()
			.GreaterThanOrEqualTo(0)
			.WithErrorCodeRequired();

		RuleFor(s => s.Comment!)
			.MaxTextFieldLength(FieldLengthes.MediumSmall)
			.WithErrorCodeValueTooLong();

		RuleFor(s => s.AdditionalComment!)
			.MaxTextFieldLength(FieldLengthes.MediumSmall)
			.WithErrorCodeValueTooLong();

		RuleFor(s => s.BagNumbers)
			.NotEmpty()
			.WithErrorCodeRequired()
			.Matches(Regexes.NumbersOrRangesPattern)
			.WithErrorCodeValueNotInRange();

		RuleFor(s => s.ManufacturedDate)
			.NotNull()
			.WithErrorCodeRequired()
			.Must((model, manufacturedDate) => manufacturedDate >= model.DateRequest.GetMax(DateTime.Now.Date))
			.WithErrorCodeValueNotInPeriod();

		RuleFor(s => s.ExpirationDate)
			.NotNull()
			.WithErrorCodeRequired()
			.Must((model, expirationDate) => expirationDate >= model.ManufacturedDate)
			.WithErrorCodeValueNotInPeriod();


		RuleFor(s => s.PrinterDirectory)
			.NotNull()
			.WithErrorCodeRequired();

		RuleFor(s => s.ZplExtension)
			.NotNull()
			.WithErrorCodeRequired();
	}
}
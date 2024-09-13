using DietPreparation.Application.Commands.Requests.FeedLabels;
using DietPreparation.Common.Consts;
using DietPreparation.Utilities.Validator;
using FluentValidation;

namespace DietPreparation.Application.Validations.CommandValidations.FeedLabels;

public class PrintFeedLabelAdditiveValidator : Validator<PrintFeedLabelAdditiveRequest>
{
	public PrintFeedLabelAdditiveValidator()
	{
		RuleFor(s => s.LotNumber)
			.NotNull()
			.WithErrorCodeRequired();

		RuleFor(s => s.Id)
			.NotNull()
			.WithErrorCodeRequired();

		RuleFor(s => s.Concentration)
			.NotNull()
			.WithErrorCodeRequired();

		RuleFor(s => s.ExpirationDate)
			.NotNull()
			.WithErrorCodeRequired()
			.GreaterThanOrEqualTo(DateTime.Now.Date.AddDays(1))
			.WithErrorCodeValueNotInPeriod();

		RuleFor(s => s.Comment!)
			.MaxTextFieldLength(FieldLengthes.MediumSmall)
			.WithErrorCodeRequired();

		RuleFor(s => s.AdditionalComment!)
			.MaxTextFieldLength(FieldLengthes.MediumSmall)
			.WithErrorCodeRequired();

		RuleFor(s => s.NumberOfCopies)
			.GreaterThan(0)
			.WithErrorCodeValueNotInPeriod();

		RuleFor(s => s.PrinterDirectory)
			.NotNull()
			.WithErrorCodeRequired();

		RuleFor(s => s.ZplExtension)
			.NotNull()
			.WithErrorCodeRequired();
	}
}
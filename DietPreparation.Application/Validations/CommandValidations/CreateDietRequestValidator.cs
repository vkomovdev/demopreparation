using DietPreparation.Application.Commands.Requests.DietRequests;
using DietPreparation.Common.Consts;
using DietPreparation.Common.Enums;
using DietPreparation.Common.Extensions;
using DietPreparation.Models.DTO;
using DietPreparation.Utilities.Validator;
using FluentValidation;

namespace DietPreparation.Application.Validations.CommandValidations;

public class CreateDietRequestValidator : Validator<CreateDietRequestRequest>
{
	public CreateDietRequestValidator()
	{
		RuleFor(s => s.RequestorId)
			.NotNull()
			.GreaterThan(0)
			.WithErrorCodeRequired();

		RuleFor(s => s.ReceiverId)
			.NotNull()
			.GreaterThan(0)
			.WithErrorCodeRequired();

		RuleFor(s => s.LocationId)
			.NotNull()
			.GreaterThan(0)
			.WithErrorCodeRequired();

		RuleFor(s => s.StudyNumber)
			.MaximumLength(FieldLengthes.ExtraSmall)
			.Matches(Regexes.StudyNumber)
			.When(s => !string.IsNullOrEmpty(s.StudyNumber))
			.WithErrorCodeFormatNotMatches();

		RuleFor(s => s.ProjectNumber)
			.MaximumLength(FieldLengthes.ExtraExtraSmall)
			.Matches(Regexes.ProjectNumber)
			.When(s => !string.IsNullOrEmpty(s.ProjectNumber))
			.WithErrorCodeFormatNotMatches();

		RuleFor(s => s.DateRequest)
			.NotNull()
			.WithErrorCodeRequired()
			.LessThanOrEqualTo(DateTime.Now.Date)
			.WithErrorCodeInvalidValue();

		RuleFor(s => s.DateNeeded)
			.NotNull()
			.WithErrorCodeRequired()
			.GreaterThanOrEqualTo(DateTime.Now.Date)
			.GreaterThanOrEqualTo(s => s.DateRequest)
			.WithErrorCodeInvalidValue();

		RuleFor(s => s.BasalDietId)
			.NotNull()
			.GreaterThan(0)
			.When(s => s.FeedType is FeedType.Basal)
			.WithErrorCodeRequired();

		RuleFor(s => s.FeedSupplierName)
			.NotEmpty()
			.MaximumLength(FieldLengthes.Middle)
			.When(s => s.FeedType is FeedType.External)
			.WithErrorCodeRequired();

		RuleFor(s => s.FeedSupplierLotNumber)
			.NotEmpty()
			.MaximumLength(FieldLengthes.Middle)
			.When(s => s.FeedType is FeedType.External)
			.WithErrorCodeRequired();

		RuleFor(s => s.RequestAmount)
			.NotNull()
			.GreaterThan(0)
			.WithErrorCodeMustBeNonNegative()
			.LessThanOrEqualTo(DefaultNumbers.AmountMaxValue)
			.WithErrorCodeInvalidValue();

		RuleFor(s => s)
			.Must(BeTotalAmountGreaterThanSamplesAmount)
			.When(HasSamples)
			.WithErrorCodeMustBeTotalAmountGreaterThanSamplesAmount();

		RuleFor(s => s)
			.Must(BeTotalAmountGreaterThanSumOfIncludedWeights)
			.When(HasDrugsOrPremixes)
			.WithErrorCodeMustBeTotalAmountGreaterThanSumOfIncludedWeights();

		RuleFor(s => s.UnitOfMeasure)
			.NotNull()
			.In(UnitOfMeasure.Gram, UnitOfMeasure.Kilogram, UnitOfMeasure.Pound)
			.WithErrorCodeInvalidValue();

		RuleFor(s => s.Form)
			.NotNull()
			.WithErrorCodeRequired();

		RuleFor(s => s.ToxicHazard)
			.NotNull()
			.WithErrorCodeRequired();

		RuleFor(s => s.HazardCode)
			.NotEmpty()
			.MaximumLength(FieldLengthes.ExtraExtraSmall)
			.When(s => s.ToxicHazard is HazardType.Known)
			.WithErrorCodeRequired();

		RuleFor(s => s.PackagingInstructions)
			.NotEmpty()
			.MaximumLength(FieldLengthes.Large)
			.WithErrorCodeRequired();

		RuleFor(s => s.MixingInstructions)
			.NotEmpty()
			.MaximumLength(FieldLengthes.Large)
			.WithErrorCodeRequired();

		RuleFor(s => s.GeneralComments)
			.MaximumLength(FieldLengthes.Large)
			.WithErrorCodeInvalidLength();
	}

	private static bool BeTotalAmountGreaterThanSumOfIncludedWeights(CreateDietRequestRequest request)
	{
		var drugAmounts = CalculateDrugsTotalAmountInGrams(request.Drugs, true);
		var premixAmounts = CalculatePremixesTotalAmountInGrams(request.Premixes, true);
		return request.AmountInGrams > (drugAmounts + premixAmounts);
	}

	private static bool BeTotalAmountGreaterThanSamplesAmount(CreateDietRequestRequest request)
	{
		var samplesAmount = CalculateSamplesTotalAmountInGrams(request.Samples);
		return request.AmountInGrams > samplesAmount;
	}

	private static decimal CalculateDrugsTotalAmountInGrams(IEnumerable<DietRequestDrugDto>? drugs, bool includedInWeight)
	{
		if (drugs is null)
		{
			return 0;
		}

		return drugs
			.Where(x => x.IncludedInWeight == includedInWeight)
			.Sum(x => x.AmountInGrams);
	}

	private static decimal CalculatePremixesTotalAmountInGrams(IEnumerable<DietRequestPremixDto>? premixes, bool includedInWeight)
	{
		if (premixes is null)
		{
			return 0;
		}

		return premixes
			.Where(x => x.IncludedInWeight == includedInWeight)
			.Sum(x => x.AmountInGrams);
	}

	private static decimal CalculateSamplesTotalAmountInGrams(IEnumerable<DietRequestSampleDto>? samples)
	{
		if (samples is null)
		{
			return 0;
		}

		return samples.Sum(x => x.AmountInGrams);
	}

	private static bool HasDrugsOrPremixes(CreateDietRequestRequest request)
	{
		return (request.Drugs is not null && request.Drugs.Any()) || (request.Premixes is not null && request.Premixes.Any());
	}

	private static bool HasSamples(CreateDietRequestRequest request)
	{
		return request.Samples is not null && request.Samples.Any();
	}
}
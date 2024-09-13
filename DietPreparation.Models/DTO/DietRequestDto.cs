using DietPreparation.Common.Enums;
using DietPreparation.Common.Extensions;

namespace DietPreparation.Models.DTO;

public record DietRequestDto
{
	public int Id { get; init; } = 0;
	public int? LotYear { get; init; }
	public int? LotId { get; init; }
	public string? Lot { get; init; }
	public int? LocationId { get; init; }
	public LocationDto? Location { get; set; }
	public bool DeliveryNotice { get; init; }
	public string? ProtocolNumber { get; init; } = string.Empty;
	public string? StudyNumber { get; init; } = string.Empty;
	public string? ProjectNumber { get; init; } = string.Empty;
	public DateTime? DateRequest { get; set; }
	public DateTime? DateNeeded { get; set; }
	public StudyType StudyType { get; init; }
	public RequestType RequestType { get; init; }
	public string? Name { get; init; } = string.Empty;
	public FeedType? FeedType { get; init; }
	public IntendedUse? IntendedUse { get; init; }
	public decimal? RequestAmount { get; init; }
	public UnitOfMeasure? UnitOfMeasure { get; init; }
	public Form? Form { get; init; }
	public bool ControlledSubstance { get; init; }
	public HazardType? ToxicHazard { get; init; }
	public string? HazardCode { get; init; } = string.Empty;
	public string? PackagingInstructions { get; init; } = string.Empty;
	public string? MixingInstructions { get; init; } = string.Empty;
	public bool IsDeleted { get; init; } = false;
	public bool IsLocked { get; set; } = false;
	public bool? PremixUsed { get; init; }
	public bool UsedAsTemplate { get; init; } = false;
	public int? BasalDietId { get; init; }
	public BasalDietDto? BasalDiet { get; set; }
	public string? FeedSupplierLotNumber { get; init; }
	public string? FeedSupplierName { get; init; }

	public bool HasDrugs { get; init; } = false;
	public IEnumerable<DietRequestDrugDto>? Drugs { get; set; }
	public bool HasSamples { get; init; } = false;
	public IEnumerable<DietRequestSampleDto>? Samples { get; set; }
	public bool HasPremixes { get; init; } = false;
	public IEnumerable<DietRequestPremixDto>? Premixes { get; set; }

	public string? GeneralComments { get; init; } = string.Empty;

	public int? RequestorId { get; init; }
	public CustomerDto? Requestor { get; set; }
	public int? RecieverId { get; init; }
	public CustomerDto? Receiver { get; set; }
	public string FirstName { get; init; } = string.Empty;
	public string LastName { get; init; } = string.Empty;
	public PwoDto? Pwo { get; set; }
	public int TotalItems { get; init; }

	public decimal? AmountInGrams => RequestAmount * (decimal?)UnitOfMeasure?.GetConversionRateToGram();

	public string? GenerateName()
	{
		switch (this.FeedType)
		{
			case Common.Enums.FeedType.Basal:
				return BasalDiet == null ? null : BasalDiet.Name;
			case Common.Enums.FeedType.External:
				return $"{FeedSupplierName}-{FeedSupplierLotNumber}";
		}
		return string.Empty;
	}

	public string? GetName()
	{
		if (!string.IsNullOrWhiteSpace(Name))
			return Name;

		return GenerateName();
	}
}

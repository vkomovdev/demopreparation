using DietPreparation.Common.Enums;

namespace DietPreparation.Models.DTO;

public record CreateUpdateDietRequestDto
{
	public int Id { get; init; } = 0;
	public int? RequestorId { get; init; }
	public int? RecieverId { get; init; }
	public int? LocationId { get; init; }
	public bool DeliveryNotice { get; init; }
	public string? StudyNumber { get; init; } = string.Empty;
	public string? ProjectNumber { get; init; } = string.Empty;
	public DateTime? DateRequest { get; init; }
	public DateTime? DateNeeded { get; init; }
	public StudyType StudyType { get; init; }
	public RequestType RequestType { get; init; }
	public FeedType? FeedType { get; init; }
	public int? BasalDietId { get; init; }
	public BasalDietDto? BasalDiet { get; init; }
	public string? FeedSupplierName { get; init; }
	public string? FeedSupplierLotNumber { get; init; }

	public string? IntendedUse { get; init; } = string.Empty;
	public decimal? RequestAmount { get; init; }
	public UnitOfMeasure? UnitOfMeasure { get; init; }
	public Form? Form { get; init; }
	public bool ControlledSubstance { get; init; }
	public string? ToxicHazard { get; init; } = string.Empty;
	public string? HazardCode { get; init; } = string.Empty;
	public string? PackagingInstructions { get; init; } = string.Empty;
	public string? MixingInstructions { get; init; } = string.Empty;
	public bool IsDeleted { get; init; }
	public bool IsLocked { get; init; } = false;
	public bool? PremixUsed { get; init; }
	public string? Protocol { get; init; }
	public bool UsedAsTemplate { get; init; } = false;

	public bool HasDrugs { get; init; } = false;
	public IEnumerable<DietRequestDrugDto>? Drugs { get; init; }
	public bool HasSamples { get; init; } = false;
	public IEnumerable<DietRequestSampleDto>? Samples { get; init; }
	public bool HasPremixes { get; init; } = false;
	public IEnumerable<DietRequestPremixDto>? Premixes { get; init; }

	public string GeneralComments { get; init; } = string.Empty;



	public CustomerDto? Requestor { get; init; }
	public CustomerDto? Reciever { get; init; }
	public string FirstName { get; init; } = string.Empty;
	public string LastName { get; init; } = string.Empty;

	//public string DeliverDescription { get; init; } = string.Empty;
	//public string DeliverBuilding { get; init; } = string.Empty;
	//public string DeliverFloor { get; init; } = string.Empty;
	//public string DeliverLab { get; init; } = string.Empty;
	//public int BussinessUnitNumber { get; init; }
	//public string DeliverFirstName { get; init; } = string.Empty;
	//public string DeliverLastName { get; init; } = string.Empty;
}
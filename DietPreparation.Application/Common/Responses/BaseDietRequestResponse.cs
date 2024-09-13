using DietPreparation.Common.Enums;
using DietPreparation.Models.DTO;

namespace DietPreparation.Application.Common.Responses;

public record BaseDietRequestResponse : BaseResponse
{
	public CustomerDto? Requester { get; set; }
	public CustomerDto? Receiver { get; set; }
	public LocationDto? Location { get; set; }
	public bool DeliveryNotice { get; set; }
	public DateTime? DateRequest { get; set; }
	public DateTime? DateNeeded { get; set; }

	public string? LotNumber { get; set; }
	public string? ProtocolNumber { get; set; }
	public string? StudyNumber { get; set; }
	public StudyType StudyType { get; set; }
	public string? ProjectNumber { get; set; }
	public IntendedUse? IntendedUse { get; set; }
	public RequestType? RequestType { get; set; }
	public FeedType? FeedType { get; set; }
	public BasalDietDto? BasalDiet { get; set; }
	public string? FeedSupplierName { get; set; }
	public string? FeedSupplierLotNumber { get; set; }

	public decimal? RequestAmount { get; set; }
	public UnitOfMeasure? UnitOfMeasure { get; set; }
	public Form? Form { get; set; }
	public bool ControlledSubstance { get; set; }
	public HazardType? ToxicHazard { get; set; }
	public string? HazardCode { get; set; }
	public string? PackagingInstructions { get; set; }
	public string? MixingInstructions { get; set; }

	public IEnumerable<DietRequestPremixDto>? Premixes { get; set; }
	public IEnumerable<DietRequestDrugDto>? Drugs { get; set; }
	public IEnumerable<DietRequestSampleDto>? Samples { get; set; }

	public string? GeneralComment { get; set; }
	public bool IsDeleted { get; set; }
	public bool IsLocked { get; set; }
}
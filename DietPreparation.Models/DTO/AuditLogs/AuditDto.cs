using DietPreparation.Common.Enums;

namespace DietPreparation.Models.DTO.AuditLogs;

public record AuditDto
{
	public int Id { get; set; }
	public AuditChangeType? ChangeType { get; init; }
	public string? ChangeReason { get; init; }
	public string? ChangeOperator { get; init; }
	public DateTime? ChangeTimestamp { get; init; }
	public string? LotYear { get; init; }
	public int? LotID { get; init; }
	public int? RequestorID { get; init; }
	public int? DeliverID { get; init; }
	public string? Location { get; init; }
	public bool? DeliveryNotice { get; init; }
	public string? Protocol { get; init; }
	public string? StudyNumber { get; init; }
	public string? ProjectNumber { get; init; }
	public string? DateRequested { get; init; }
	public string? DateNeeded { get; init; }
	public StudyType? StudyType { get; init; }
	public RequestType? RequestType { get; init; }
	public string? DietName { get; init; }
	public FeedType? BaseFeedType { get; init; }
	public string? BaseFeedName { get; init; }
	public string? CommFeedLotNum { get; init; }
	public bool? IntendedUseInternal { get; init; }
	public decimal? RequestAmount { get; init; }
	public UnitOfMeasure? RequestUOM { get; init; }
	public Form? Form { get; init; }
	public bool? ControlledSubstance { get; init; }
	public HazardType? ToxicHazard { get; init; }
	public string? HazardCode { get; init; }
	public string? PackingInstructions { get; init; }
	public string? MixingInstructions { get; init; }
	public bool? PremixIncluded { get; init; }
	public bool? DrugIncluded { get; init; }
	public bool? SampleIncluded { get; init; }

	public IEnumerable<AuditDrugDto>? Drugs { get; set; }
	public IEnumerable<AuditPremixDto>? Premixes { get; set; }
	public IEnumerable<AuditSampleDto>? Samples { get; set; }

	public string? RequesterName { get; set; }
	public string? ReceiverName { get; set; }
}

using DietPreparation.Common.Consts;
using DietPreparation.Common.Enums;
using DietPreparation.Web.Models.DietRequests.Rows;
using System.ComponentModel.DataAnnotations;

namespace DietPreparation.Web.Models.DietRequests;

public class ReadDietRequestViewModel
{
	public int? Id { get; set; }

	public string? RequesterName { get; set; }
	public string? ReceiverName { get; set; }
	public SectionLocation? Location { get; set; }
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
	public string? BasalDietName { get; set; }
	public string? FeedSupplierName { get; set; }
	public string? FeedSupplierLotNumber { get; set; }

	[DisplayFormat(DataFormatString = FormatStrings.DecimalFormat)]
	public decimal? RequestAmount { get; set; }
	public UnitOfMeasure? UnitOfMeasure { get; set; }
	public Form? Form { get; set; }
	public bool ControlledSubstance { get; set; }
	public HazardType? ToxicHazard { get; set; }
	public string? HazardCode { get; set; }
	public string? PackagingInstructions { get; set; }
	public string? MixingInstructions { get; set; }

	public IEnumerable<DietRequestPremixDetails>? Premixes { get; set; }
	public IEnumerable<DietRequestDrugDetails>? Drugs { get; set; }
	public IEnumerable<DietRequestSampleDetails>? Samples { get; set; }

	public string? GeneralComment { get; set; }
	public bool IsLocked { get; set; } = false;
}
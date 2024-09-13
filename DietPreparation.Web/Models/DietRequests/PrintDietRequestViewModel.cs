using DietPreparation.Common.Consts;
using DietPreparation.Common.Enums;
using DietPreparation.Web.Models.DietRequests.Rows;
using System.ComponentModel.DataAnnotations;

namespace DietPreparation.Web.Models.DietRequests;

public class PrintDietRequestViewModel
{
	public bool SendEmail { get; set; }
	public string? RequesterName { get; set; }
	public DateTime? DateRequest { get; set; }
	public DateTime? DateNeeded { get; set; }

	public string? LotNumber { get; set; }
	public string? ProtocolNumber { get; set; }
	public string? StudyNumber { get; set; }
	public string? ProjectNumber { get; set; }
	public StudyType? StudyType { get; set; }
	public RequestType? RequestType { get; set; }

	public string? ReceiverName { get; set; }
	public SectionLocation? Location { get; set; }

	public string? DietName { get; set; }
	[DisplayFormat(DataFormatString = FormatStrings.DecimalFormat)]
	public decimal? RequestAmount { get; set; }
	public UnitOfMeasure? UnitOfMeasure { get; set; }

	public FeedType? FeedType { get; set; }
	public Form? Form { get; set; }
	public HazardType? ToxicHazard { get; set; }
	public IntendedUse? IntendedUse { get; set; }
	public bool ControlledSubstance { get; set; }
	public string? HazardCode { get; set; }

	public string? MixingInstructions { get; set; }
	public string? PackagingInstructions { get; set; }

	public bool HasPremixes { get; set; }
	public bool HasDrugs { get; set; }
	public bool HasSamples { get; set; }

	public IEnumerable<DietRequestPremixDetails>? Premixes { get; set; }
	public IEnumerable<DietRequestDrugDetails>? Drugs { get; set; }
	public IEnumerable<DietRequestSampleDetails>? Samples { get; set; }
}
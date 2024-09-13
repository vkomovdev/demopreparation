using DietPreparation.Common.Consts;
using DietPreparation.Common.Enums;
using DietPreparation.Models.DTO;
using DietPreparation.Web.Models.DietRequests;
using DietPreparation.Web.Models.DietRequests.Rows;

namespace DietPreparation.Web.Models.PWOs;

public class PrintPwoBatchViewModel
{
	public IEnumerable<PwoDrugDto>? Drugs { get; set; }
	public IEnumerable<PwoPremixDrugDto>? PremixDrugs { get; set; }
	public IEnumerable<PwoIngredientModel>? Ingredients { get; set; }
	public IEnumerable<PwoPremixDto>? Premixes { get; set; }
	public IEnumerable<DietRequestSampleDetails>? Samples { get; set; }

	public bool HasSamples { get; set; }
	public decimal TotalIngredients => Ingredients?.Sum(x => Math.Round(x.Amount ?? 0, DefaultNumbers.DecimalDigitsCount)) ?? 0;

	public string? LotNumber { get; set; }
	public string? BatchNumber { get; set; }

	public string? RequesterName { get; set; }
	public string? PlannedBy { get; set; }
	public string? ProtocolNumber { get; set; }
	public string? StudyNumber { get; set; }
	public string? ProjectNumber { get; set; }
	public StudyType? StudyType { get; set; }
	public RequestType? RequestType { get; set; }

	public DateTime? DateRequest { get; set; }
	public DateTime? DateNeeded { get; set; }

	public string? DeliverTo { get; set; }
	public SectionLocation? Location { get; set; }

	public string? DietName { get; set; }
	public FeedType? FeedType { get; set; }
	public string? IntendedUse { get; set; }
	public Form? Form { get; set; }

	public decimal? TotalRequestedWeight { get; set; }
	public UnitOfMeasure? TotalRequestedUom { get; set; }

	public bool ControlledSubstance { get; set; }
	public HazardType? ToxicHazard { get; set; }
	public string? HazardCode { get; set; }
	public string? MixingInstructions { get; set; }
	public string? PackingInstructions { get; set; }

	public decimal? BatchWeight { get; set; }
	public string? BatchUom { get; set; }
}
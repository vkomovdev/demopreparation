using DietPreparation.Common.Consts;
using DietPreparation.Common.Enums;
using DietPreparation.Web.Models.DietRequests.Rows;
using DietPreparation.Web.Models.Metadata;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DietPreparation.Web.Models.DietRequests;

public class EditDietRequestViewModel
{
	#region Update only

	public int? Id { get; set; }
	public bool IsLocked { get; set; }

	#endregion

	public int? RequesterId { get; set; }
	public int? ReceiverId { get; set; }
	public int? LocationId { get; set; }
	public bool DeliveryNotice { get; set; } = false;
	public DateTime? DateRequest { get; set; } = DateTime.Now;
	public DateTime? DateNeeded { get; set; }

	public string? LotNumber { get; set; }
	public string? ProtocolNumber { get; set; }
	public string? StudyNumber { get; set; }
	public StudyType? StudyType { get; set; } = Common.Enums.StudyType.NonGxp;
	public string? ProjectNumber { get; set; }
	public IntendedUse? IntendedUse { get; set; }
	public RequestType? RequestType { get; set; } = Common.Enums.RequestType.CompleteDiet;
	public FeedType? FeedType { get; set; }
	public int? BasalDietId { get; set; }
	public string? FeedSupplierName { get; set; }
	public string? FeedSupplierLotNumber { get; set; }

	[DisplayFormat(DataFormatString = FormatStrings.DecimalFormat)]
	public decimal? RequestAmount { get; set; } = default;
	public UnitOfMeasure? UnitOfMeasure { get; set; } = Common.Enums.UnitOfMeasure.Gram;
	public Form? Form { get; set; }
	public bool ControlledSubstance { get; set; } = false;
	public HazardType? ToxicHazard { get; set; }
	public string? HazardCode { get; set; }
	public string? PackagingInstructions { get; set; }
	public string? MixingInstructions { get; set; }

	public IEnumerable<DietRequestPremix>? Premixes { get; set; }
	public IEnumerable<DietRequestDrug>? Drugs { get; set; }
	public IEnumerable<DietRequestSample>? Samples { get; set; }

	public string? GeneralComment { get; set; }
	public bool PrintAfterSave { get; set; }

	public string? ChangeReason { get; set; }

	[JsonIgnore]
	public bool HasPremixes { get; set; }
	[JsonIgnore]
	public bool HasDrugs { get; set; }
	[JsonIgnore]
	public bool HasSamples { get; set; }
	[JsonIgnore]
	public MetadataSection? Metadata { get; init; }
}
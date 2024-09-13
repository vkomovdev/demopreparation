using DietPreparation.Application.Commands.Responses.DietRequests;
using DietPreparation.Common.Enums;
using DietPreparation.Common.Extensions;
using DietPreparation.Models.DTO;
using MediatR;

namespace DietPreparation.Application.Commands.Requests.DietRequests;

public record CreateDietRequestRequest : IRequest<CreateDietRequestResponse>
{
	public int? RequestorId { get; set; }
	public int? ReceiverId { get; set; }
	public int? LocationId { get; set; }
	public bool DeliveryNotice { get; set; }
	public DateTime? DateRequest { get; set; }
	public DateTime? DateNeeded { get; set; }

	public string? StudyNumber { get; set; }
	public StudyType StudyType { get; set; }
	public string? ProjectNumber { get; set; }
	public IntendedUse? IntendedUse { get; set; }
	public RequestType? RequestType { get; set; }
	public FeedType? FeedType { get; set; }
	public int? BasalDietId { get; set; }
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

	public bool HasDrugs { get; init; }
	public bool HasPremixes { get; init; }
	public bool HasSamples { get; init; }
	public IEnumerable<DietRequestPremixDto>? Premixes { get; set; }
	public IEnumerable<DietRequestDrugDto>? Drugs { get; set; }
	public IEnumerable<DietRequestSampleDto>? Samples { get; set; }

	public string? GeneralComments { get; set; }

	public decimal AmountInGrams
	{
		get
		{
			if (!RequestAmount.HasValue || !UnitOfMeasure.HasValue)
			{
				return 0;
			}

			return RequestAmount.Value * (decimal)UnitOfMeasure.GetConversionRateToGram();
		}
	}
}
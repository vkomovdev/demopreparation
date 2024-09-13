using DietPreparation.Common.Consts;

namespace DietPreparation.Models.DAO.DietRequests;

public record MedicatedPremixDao
{
	public int REQUEST_ID { get; init; }
	public int? LOT_YEAR { get; init; }
	public int? LOT_ID { get; init; }
	public string? DIET_NAME { get; init; }
	public string ISDELETED { get; init; } = DefaultStrings.No;
	public bool? PremixUsed { get; init; }
}

namespace DietPreparation.Models.DAO.DietRequests;

public record DietRequestSearchDao
{
	public int? REQUEST_ID { get; init; }
	public string? LOT { get; init; }
	public string? REQUESTOR { get; init; }
	public string? RECEIVER { get; init; }
	public DateTime? DATE_REQUEST { get; init; }
	public DateTime? DATE_NEEDED { get; init; }
	public string? DIET_NAME { get; init; }
	public decimal? REQUEST_AMOUNT { get; init; }
	/// <summary>Unit of Measure</summary>
	public string? REQUEST_UOM { get; init; }

	public bool LOCK { get; init; }
	public string? USEDASTEMPLATE { get; init; }
	public string? ISDELETED { get; init; }
}
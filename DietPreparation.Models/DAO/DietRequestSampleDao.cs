namespace DietPreparation.Models.DAO;

public record DietRequestSampleDao
{
	public int RECORD_ID { get; init; }
	public int? REQUEST_ID { get; init; }
	public decimal? AMOUNT { get; init; }
	public string? AMOUNT_UOM { get; init; }
	public string? DISPOSITION { get; init; }
	public string? ANALYSIS_TYPE { get; init; }
	public string? COMMENT { get; init; }
}

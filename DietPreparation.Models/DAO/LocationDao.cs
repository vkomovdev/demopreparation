namespace DietPreparation.Models.DAO;

public record LocationDao
{
	public int LOCATION_ID { get; init; }
	public string DELIVER_DESCRIPTION { get; init; } = string.Empty;
	public string DELIVER_BUILDING { get; init; } = string.Empty;
	public string? DELIVER_FLOOR { get; init; } = string.Empty;
	public string? DELIVER_LAB { get; init; } = string.Empty;
	public int? BUSINESS_UNIT_NUMBER { get; init; }
	public bool LOCK { get; init; } = false;
}
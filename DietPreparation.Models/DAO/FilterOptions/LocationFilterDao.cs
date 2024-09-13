namespace DietPreparation.Models.DAO.FilterOptions;

public record LocationFilterDao
{
	public string? DELIVER_DESCRIPTION { get; init; } = string.Empty;
	public string? DELIVER_BUILDING { get; init; } = string.Empty;
	public string? DELIVER_FLOOR { get; init; } = string.Empty;
	public string? DELIVER_LAB { get; init; } = string.Empty;
	public int? BUSINESS_UNIT_NUMBER { get; init; }
}
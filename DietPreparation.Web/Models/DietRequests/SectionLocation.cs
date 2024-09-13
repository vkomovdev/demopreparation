namespace DietPreparation.Web.Models.DietRequests;

public class SectionLocation
{
	public int Id { get; init; }
	public string? Description { get; init; }
	public string? Building { get; init; }
	public string? Floor { get; init; }
	public string? Lab { get; init; }
	public int? BusinessUnit { get; init; }

	public string Name => $"{Description} - {Building} - {Floor} - {Lab}";
	public string FloorLab => $"{Floor} - {Lab}";
}
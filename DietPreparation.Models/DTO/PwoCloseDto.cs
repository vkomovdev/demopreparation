namespace DietPreparation.Models.DTO;
public record PwoCloseDto
{
	public int PwoId { get; init; }
	public string Mixer { get; init; } = string.Empty;
	public string TimeCompleted { get; init; } = string.Empty;
	public DateTime DateCompleted { get; init; }
	public string CompletedBy { get; init; } = string.Empty;
	public int BagCount { get; init; }
	public string Comment { get; init; } = string.Empty;
	public string Location { get; init; } = string.Empty;
}

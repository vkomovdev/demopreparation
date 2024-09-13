namespace DietPreparation.Models.DTO;

public record DietRequestBasalDietDto
{
	public int RecordId { get; init; }
	public int? RequestId { get; init; }
	public int? BasalDietId { get; init; }
	public BasalDietDto? BasalDiet { get; init; }
}
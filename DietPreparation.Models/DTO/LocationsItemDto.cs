namespace DietPreparation.Models.DTO;

public record LocationsItemDto : LocationDto
{
	public int TotalItems { get; init; }
}
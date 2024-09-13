namespace DietPreparation.Web.Models.DeliveryLocations;

public class DeliveryLocationViewModel
{
	public int? Id { get; init; }

	public string? Description { get; init; }

	public string? Building { get; init; }

	public string? Floor { get; init; }

	public string? Lab { get; init; }

	public int? BusinessUnit { get; init; }

	public bool? IsLocked { get; init; }
}

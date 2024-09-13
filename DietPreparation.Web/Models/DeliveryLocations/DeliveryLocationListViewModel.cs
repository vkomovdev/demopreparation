namespace DietPreparation.Web.Models.DeliveryLocations;

public class DeliveryLocationListViewModel
{
	public IEnumerable<DeliveryLocationViewModel>? Locations { get; init; }

	public int TotalItems { get; init; }
	public int Page { get; init; }
	public int PageSize { get; init; }
}


namespace DietPreparation.Web.Models.Customers;

public class CustomerListViewModel
{
	public required IEnumerable<CustomerListItemViewModel> Customers { get; set; }
	public int TotalItems { get; set; }
	public int Page { get; set; }
	public int PageSize { get; set; }
}
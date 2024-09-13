using DietPreparation.Common.Enums;

namespace DietPreparation.Web.Models.Customers;

public class CustomerListItemViewModel
{
	public string? EncodedCustomerId { get; init; }
	public string? FirstName { get; set; }
	public string? MiddleName { get; set; }
	public string? LastName { get; set; }
	public string? Email { get; set; }
	public string? CustomerType { get; set; }
	public string? Building { get; set; }
	public string? BusinessUnit { get; set; }
}
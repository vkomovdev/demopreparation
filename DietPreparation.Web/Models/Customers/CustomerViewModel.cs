using DietPreparation.Common.Enums;

namespace DietPreparation.Web.Models.Customers;

public class CustomerViewModel
{
	public string? Id { get; set; }
	public string? FirstName { get; set; }
	public string? MiddleName { get; set; }
	public string? LastName { get; set; }
	public string? Email { get; set; }
	public CustomerType? CustomerType { get; set; }
	public string? Building { get; set; }
	public string? BusinessUnit { get; set; }
	public bool? Lock { get; set; }

}
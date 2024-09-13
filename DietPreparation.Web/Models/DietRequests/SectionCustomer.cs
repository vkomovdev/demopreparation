using DietPreparation.Common.Enums;

namespace DietPreparation.Web.Models.DietRequests;

public class SectionCustomer
{
	public int? Id { get; set; }

	public string? FirstName { get; set; }

	public string? LastName { get; set; }

	public string? Name => $"{FirstName} {LastName}";

	public CustomerType? Type { get; set; }
}
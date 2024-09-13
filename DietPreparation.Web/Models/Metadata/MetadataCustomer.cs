using DietPreparation.Common.Enums;

namespace DietPreparation.Web.Models.Metadata;

public class MetadataCustomer
{
	public int? Id { get; init; }

	public string? Name { get; init; }

	public CustomerType? Type { get; init; }
}
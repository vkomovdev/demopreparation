namespace DietPreparation.Web.Models.Metadata;

public record MetadataIngredient
{
	public int? Id { get; init; }
	public string? Name { get; init; } = string.Empty;
}
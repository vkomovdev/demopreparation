namespace DietPreparation.Web.Models.Metadata;

public class MetadataSection
{
	public IEnumerable<MetadataDrug>? MetadataDrugs { get; set; }

	public IEnumerable<MetadataPremix>? MetadataPremixes { get; set; }

	public IEnumerable<MetadataBasalDiet>? MetadataBasalDiets { get; set; }

	public IEnumerable<MetadataCustomer>? MetadataCustomers { get; set; }

	public IEnumerable<MetadataLocation>? MetadataLocations { get; set; }
}

namespace DietPreparation.Models.DAO;

public record DrugsItemDao() : DrugDao
{
	public int TotalItems { get; set; }
}
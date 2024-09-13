namespace DietPreparation.Models.DAO;

public record LocationsItemDao() : LocationDao
{
	public int TotalItems { get; set; }
}
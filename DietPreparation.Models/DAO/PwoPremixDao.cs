namespace DietPreparation.Models.DAO;
public record PwoPremixDao
{
	public int PWO_ID { get; init; }
	public int REQUEST_ID { get; init; }
	public decimal AMOUNT { get; init; }
	public string AMOUNT_UOM { get; init; } = string.Empty;
	public int LOT_YEAR { get; init; }
	public int LOT_ID { get; init; }
	public string DIET_NAME { get; init; } = string.Empty;
}

namespace DietPreparation.Models.DAO;

public record CreateUpdateCustomerDao
{
	public int CUSTOMER_ID { get; init; }
	public string FIRST_NAME { get; init; } = string.Empty;
	public string MIDDLE_INITIAL { get; init; } = string.Empty;
	public string LAST_NAME { get; init; } = string.Empty;
	public string EMAIL { get; init; } = string.Empty;
	public string CUSTOMER_TYPE { get; init; } = string.Empty;
	public int BUILDING { get; init; }
	public int? UNIT { get; init; }
	public bool LOCK { get; init; }
}
namespace DietPreparation.Models.DAO;

public record CreateUpdateUserDao
{
	public int USERIDKEY { get; init; } = 0;
	public string USERID { get; init; } = string.Empty;
	public string FIRSTNAME { get; init; } = string.Empty;
	public string MIDDLENAME { get; init; } = string.Empty;
	public string LASTNAME { get; init; } = string.Empty;
	public string EMAILADDRESS { get; init; } = string.Empty;
	public int ACCESSKEY { get; init; } = 0;
}
namespace DietPreparation.Models.DAO;

public record UserDao
{
	public string UserID { get; init; } = string.Empty;
	public string FirstName { get; init; } = string.Empty;
	public string MiddleName { get; init; } = string.Empty;
	public string LastName { get; init; } = string.Empty;
	public string EmailAddress { get; init; } = string.Empty;
	public int accessKey { get; init; } = 0;
	public int UserIDKey { get; init; } = 0;
	public string NickName { get; init; } = string.Empty;
}
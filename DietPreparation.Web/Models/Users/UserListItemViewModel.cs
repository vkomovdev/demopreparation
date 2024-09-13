namespace DietPreparation.Web.Models.Users;

public class UserListItemViewModel
{
	public string? EncodedUserId { get; init; }

	public string? UserId { get; init; }

	public string? FirstName { get; init; }

	public string? MiddleName { get; init; }

	public string? LastName { get; init; }

	public string? Email { get; init; }

	public int? AccessTypeNumber { get; init; }

	public string? AccessTypeLevel { get; init; }
}
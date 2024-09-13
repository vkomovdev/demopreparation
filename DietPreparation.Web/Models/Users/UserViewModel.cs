using DietPreparation.Common.Enums;

namespace DietPreparation.Web.Models.Users;

public class UserViewModel
{
	public int KeyId { get; set; }

	public string? UserId { get; set; }

	public string? FirstName { get; set; }

	public string? MiddleName { get; set; }

	public string? LastName { get; set; }

	public string? Email { get; set; }

	public AccessType AccessType { get; set; } = AccessType.User;
}
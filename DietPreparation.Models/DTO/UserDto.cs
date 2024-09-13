using DietPreparation.Common.Enums;

namespace DietPreparation.Models.DTO;

public record UserDto
{
	public int KeyId { get; init; }
	public string? UserId { get; init; }
	public string? FirstName { get; init; }
	public string? MiddleName { get; init; }
	public string? LastName { get; init; }
	public string? Email { get; init; }
	public AccessType AccessType { get; init; }
}
using DietPreparation.Common.Enums;

namespace DietPreparation.Application.Commands.Requests.Users;

public record BaseUserRequest
{
	public string? UserId { get; init; }
	public string? FirstName { get; init; }
	public string? MiddleName { get; init; }
	public string? LastName { get; init; }
	public string? Email { get; init; }
	public AccessType AccessType { get; init; }
}
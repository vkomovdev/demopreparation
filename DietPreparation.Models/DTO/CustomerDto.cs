using DietPreparation.Common.Enums;

namespace DietPreparation.Models.DTO;

public record CustomerDto
{
	public int Id { get; init; }

	public string FirstName { get; init; } = string.Empty;

	public string LastName { get; init; } = string.Empty;

	public CustomerType Type { get; init; }
	public string MiddleName { get; init; } = string.Empty;
	public string Email { get; init; } = string.Empty;
	public string Building { get; init; } = string.Empty;
	public string? BusinessUnit { get; init; } = string.Empty;
	public bool? Lock { get; init; }
	public int TotalItems { get; set; }

	public string GetFullName() => $"{FirstName} {LastName}";
}

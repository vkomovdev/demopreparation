namespace DietPreparation.Models.DTO;

public record CustomerUpdateDto
{
	public int Id { get; init; } = 0;
	public string FirstName { get; init; } = string.Empty;
	public string MiddleName { get; init; } = string.Empty;
	public string LastName { get; init; } = string.Empty;
	public string Email { get; init; } = string.Empty;
	public string CustomerType { get; init; } = string.Empty;
	public int Building { get; init; }
	public int Unit { get; init; }
	public bool Lock { get; init; }
}
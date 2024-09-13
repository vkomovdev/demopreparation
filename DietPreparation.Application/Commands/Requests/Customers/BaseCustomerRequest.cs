namespace DietPreparation.Application.Commands.Requests.Customers;

public record BaseCustomerRequest
{
	public int? CustomerId { get; init; }
	public string? Name { get; init; }
}
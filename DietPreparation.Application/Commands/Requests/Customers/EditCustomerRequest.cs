using DietPreparation.Application.Commands.Responses.Customers;
using DietPreparation.Common.Enums;
using MediatR;

namespace DietPreparation.Application.Commands.Requests.Customers;

public record EditCustomerRequest : IRequest<EditCustomerResponse>
{
	public int Id { get; init; }
	public string? FirstName { get; set; }
	public string? MiddleName { get; set; }
	public string? LastName { get; set; }
	public string? Email { get; set; }
	public CustomerType? CustomerType { get; set; }
	public string? Building { get; set; }
	public string? BusinessUnit { get; set; }
}
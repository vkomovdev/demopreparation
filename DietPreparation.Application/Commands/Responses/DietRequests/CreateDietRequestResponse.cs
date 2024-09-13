using DietPreparation.Application.Common.Responses;

namespace DietPreparation.Application.Commands.Responses.DietRequests;

public record CreateDietRequestResponse : BaseDietRequestResponse
{
	public int Id { get; set; }
}
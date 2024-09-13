using DietPreparation.Application.Common.Responses;

namespace DietPreparation.Application.Commands.Responses.DietRequests;

public record UpdateDietRequestResponse : BaseDietRequestResponse
{
	public int Id { get; set; }
}
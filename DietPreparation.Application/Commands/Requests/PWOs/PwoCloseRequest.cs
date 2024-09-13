using DietPreparation.Application.Commands.Responses.PWOs;
using MediatR;

namespace DietPreparation.Application.Commands.Requests.PWOs;
public record PwoCloseRequest : IRequest<PwoCloseResponse>
{
	public int PwoId { get; set; }
	public string? Mixer { get; set; }
	public string? TimeCompleted { get; set; }
	public string? Location { get; set; }
	public DateTime DateCompleted { get; set; }
	public string? CompletedBy { get; set; }
	public int BagCount { get; set; }
	public string? Comment { get; set; }
}

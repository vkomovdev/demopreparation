using DietPreparation.Application.Common.Responses;

namespace DietPreparation.Application.Commands.Responses.FeedLabels;

public abstract record PrintZplBaseResponse : BaseResponse
{
	public IEnumerable<Zpl>? Zpls { get; set; }

	public record Zpl
	{
		public string? Content { get; init; }
		public string? FileName { get; init; }
	}
}
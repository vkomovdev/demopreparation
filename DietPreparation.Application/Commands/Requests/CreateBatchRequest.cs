using DietPreparation.Application.Commands.Responses;
using DietPreparation.Common.Enums;
using MediatR;

namespace DietPreparation.Application.Commands.Requests;

public record CreateBatchRequest : IRequest<CreateBatchResponse>
{
	public int RequestId { get; set; }
	public IEnumerable<int>? BatchSize { get; set; }
	public IEnumerable<int>? BatchNumbers { get; set; }
	public decimal MaxCapacity { get; set; }
	public int RequestAmount { get; set; }
	public FeedType FeedType { get; set; }
	public int FeedId { get; set; }
	public string? Operator { get; set; }//planner in db
	public UnitOfMeasure BatchUom { get; set; }
	public decimal BatchWeight { get; set; }
}

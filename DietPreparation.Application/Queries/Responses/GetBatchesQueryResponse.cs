using DietPreparation.Application.Common.Responses;
using DietPreparation.Common.Enums;

namespace DietPreparation.Application.Queries.Responses;
public record GetBatchesQueryResponse : BaseResponse, IExceptionResponse
{
	public int RequestId { get; set; }
	public string Lot { get; set; } = string.Empty;
	public string CustomerName { get; set; } = string.Empty;
	public string DietName { get; set; } = string.Empty;
	public IEnumerable<BatchItem>? Batches { get; set; }
}

public class BatchItem
{
	public UnitOfMeasure BatchUom { get; set; }
	public decimal BatchWeight { get; set; }
	public int Sequence { get; set; }
}
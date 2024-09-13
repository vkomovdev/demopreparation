using DietPreparation.Application.Common.Responses;
using DietPreparation.Common.Enums;

namespace DietPreparation.Application.Queries.Responses;

public record GetBatchQueryResponse : BaseResponse, IExceptionResponse
{
	public int RequestId { get; set; }
	public bool Lock { get; set; }
	public bool Premix { get; set; }
	public FeedType FeedType { get; set; }
	public int RecordId { get; set; }
	public UnitOfMeasure RequestUom { get; set; }
	public string Mode { get; set; } = "PWO_Initiate";
	public bool JobDone { get; set; }
	public bool IsAllPreMixesProcessed { get; set; }
	public decimal MaxCapacity { get; set; }
	public int OperatorId { get; set; }//Session("UserID")
	public string DietName { get; set; } = string.Empty;
	public string? CustomerName { get; set; }// FirstName MiddleInitial LastName
	public string Lot { get; set; } = string.Empty; //LOT_YEAR LOT_ID
	public int BatchSizeKey { get; set; }
	public int BatchSize { get; set; }
	public decimal RequestAmount { get; set; }
}

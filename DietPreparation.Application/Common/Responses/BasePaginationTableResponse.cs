namespace DietPreparation.Application.Common.Responses;

public record BasePaginationTableResponse : BaseResponse, IExceptionResponse
{
	public int TotalItems { get; set; }
	public int Page { get; set; }
	public int PageSize { get; set; }
}

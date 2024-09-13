using DietPreparation.Application.Queries.Responses;
using MediatR;

namespace DietPreparation.Application.Queries.Requests;
public class GetFilterYearQueryRequest: IRequest<GetFilterYearQueryResponse>
{
	public int Year { get; set; }
}

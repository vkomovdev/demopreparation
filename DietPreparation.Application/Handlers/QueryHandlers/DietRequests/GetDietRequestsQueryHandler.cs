using DietPreparation.Application.Queries.Requests.DietRequests;
using DietPreparation.Application.Queries.Responses.DietRequests;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Services.DietRequests.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.QueryHandlers.DietRequests;

internal class GetDietRequestsQueryHandler : IRequestHandler<GetDietRequestsQueryRequest, GetDietRequestsQueryResponse>
{
	private IDietRequestFilter _dietRequestFilter;
	private IMapper _mapper;

	public GetDietRequestsQueryHandler(IDietRequestFilter dietRequestFilter, IMapper mapper)
	{
		_dietRequestFilter = dietRequestFilter;
		_mapper = mapper;
	}

	public async Task<GetDietRequestsQueryResponse> Handle(GetDietRequestsQueryRequest request, CancellationToken cancellationToken)
	{
		try
		{
			var dietRequests = await _dietRequestFilter.FilterSortedAsync(request.FilterBy, request.OrderBy, request.Pagination);

			var response = _mapper.Map<GetDietRequestsQueryResponse>(request.Pagination);
			_mapper.Map(dietRequests, response);
			return response;
		}
		catch (Exception)
		{
			return _mapper.Map<GetDietRequestsQueryResponse>(new DietPreparationException(DietRequestErrorCode.ReadException));
		}
	}
}
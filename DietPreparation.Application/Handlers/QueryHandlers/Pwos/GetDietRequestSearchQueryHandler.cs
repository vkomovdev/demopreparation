using DietPreparation.Application.Queries.Requests.PWOs;
using DietPreparation.Application.Queries.Responses.PWOs;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Services.DietRequests.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.QueryHandlers.PWOs;

internal class GetDietRequestSearchQueryHandler : IRequestHandler<GetDietRequestSearchQueryRequest, GetDietRequestSearchQueryResponse>
{
	private readonly IDietRequestFilter _dietRequestSearcher;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public GetDietRequestSearchQueryHandler(IDietRequestFilter dietRequestSearcher, IMapper mapper, IDietPreparationLogger logger)
	{
		_dietRequestSearcher = dietRequestSearcher;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<GetDietRequestSearchQueryResponse> Handle(GetDietRequestSearchQueryRequest request, CancellationToken cancellationToken)
	{
		try
		{
			var dietRequests = await _dietRequestSearcher.FilterSortedAsync(request.FilterBy, request.OrderBy, request.Pagination)
				?? throw new DietPreparationException(CommonErrorCode.EntityNotFound);

			var response = _mapper.Map<GetDietRequestSearchQueryResponse>(request.Pagination);
			_mapper.Map(dietRequests, response);

			return response;
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<GetDietRequestSearchQueryResponse>(new DietPreparationException(PwoErrorCode.ReadException));
		}
	}
}

using DietPreparation.Application.Queries.Requests.DietRequests;
using DietPreparation.Application.Queries.Responses.DietRequests;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Models.DTO.TableOptions;
using DietPreparation.Services.DietRequests.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.QueryHandlers.DietRequests;

internal class GetNotClonedDietRequestsQueryHandler : IRequestHandler<GetNotClonedDietRequestsQueryRequest, GetNotClonedDietRequestsQueryResponse>
{
	private readonly IDietRequestFilter _dietRequestFilter;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public GetNotClonedDietRequestsQueryHandler(IDietRequestFilter dietRequestFilter, IMapper mapper, IDietPreparationLogger logger)
	{
		_dietRequestFilter = dietRequestFilter;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<GetNotClonedDietRequestsQueryResponse> Handle(GetNotClonedDietRequestsQueryRequest request, CancellationToken cancellationToken)
	{
		try
		{
			var result = await _dietRequestFilter.FilterAsync(new DietRequestTinyFilterDto { UsedAsTemplate = false });
			return _mapper.Map<GetNotClonedDietRequestsQueryResponse>(result);
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<GetNotClonedDietRequestsQueryResponse>(new DietPreparationException(DietRequestErrorCode.ReadException));
		}
	}
}

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

internal class GetClonedDietRequestsQueryHandler : IRequestHandler<GetClonedDietRequestsQueryRequest, GetClonedDietRequestsQueryResponse>
{
	private readonly IDietRequestFilter _dietRequestFilter;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public GetClonedDietRequestsQueryHandler(IDietRequestFilter dietRequestFilter, IMapper mapper, IDietPreparationLogger logger)
	{
		_dietRequestFilter = dietRequestFilter;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<GetClonedDietRequestsQueryResponse> Handle(GetClonedDietRequestsQueryRequest request, CancellationToken cancellationToken)
	{
		try
		{
			var result = await _dietRequestFilter.FilterAsync(new DietRequestTinyFilterDto { UsedAsTemplate = true });
			return _mapper.Map<GetClonedDietRequestsQueryResponse>(result);
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<GetClonedDietRequestsQueryResponse>(new DietPreparationException(DietRequestErrorCode.ReadException));
		}
	}
}
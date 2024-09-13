using DietPreparation.Application.Queries.Requests.PWOs;
using DietPreparation.Application.Queries.Responses.PWOs;
using DietPreparation.Common.Enums;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Models.DTO.FilterOptions;
using DietPreparation.Services.DietRequests.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.QueryHandlers.PWOs;

internal class GetDietRequestCreateQueryHandler : IRequestHandler<GetDietRequestCreateQueryRequest, GetDietRequestCreateQueryResponse>
{
	private readonly IDietRequestFilter _dietRequestSearcher;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public GetDietRequestCreateQueryHandler(IDietRequestFilter dietRequestSearcher, IMapper mapper, IDietPreparationLogger logger)
	{
		_dietRequestSearcher = dietRequestSearcher;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<GetDietRequestCreateQueryResponse> Handle(GetDietRequestCreateQueryRequest request, CancellationToken cancellationToken)
	{
		try
		{
			var dietRequests = await _dietRequestSearcher.FilterSortedAsync(new PwoTypeFilterDto { Type = PwoType.Initiate }, request.OrderBy, request.Pagination)
				?? throw new DietPreparationException(CommonErrorCode.EntityNotFound);

			var response = _mapper.Map<GetDietRequestCreateQueryResponse>(request.Pagination);
			_mapper.Map(dietRequests, response);

			return response;
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<GetDietRequestCreateQueryResponse>(new DietPreparationException(PwoErrorCode.ReadException));
		}
	}
}

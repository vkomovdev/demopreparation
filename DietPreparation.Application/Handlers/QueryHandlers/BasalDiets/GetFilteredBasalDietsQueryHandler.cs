using DietPreparation.Application.Queries.Requests.BasalDiets;
using DietPreparation.Application.Queries.Responses.BasalDiets;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Services.BasalDiets.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.QueryHandlers.BasalDiets;

internal class GetFilteredBasalDietsQueryHandler : IRequestHandler<GetFilteredBasalDietsQueryRequest, GetBasalDietsQueryResponse>
{
	private readonly IBasalDietFilter _basalDietFilter;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public GetFilteredBasalDietsQueryHandler(IBasalDietFilter basalDietFilter, IMapper mapper, IDietPreparationLogger logger)
	{
		_basalDietFilter = basalDietFilter;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<GetBasalDietsQueryResponse> Handle(GetFilteredBasalDietsQueryRequest request, CancellationToken cancellationToken)
	{
		try
		{
			var basalDietDtos = await _basalDietFilter.SortLimitedAsync(request.OrderBy, request.Pagination);

			var response = new GetBasalDietsQueryResponse();
			_mapper.Map(request.Pagination, response);
			_mapper.Map(basalDietDtos, response);
			return response;
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<GetBasalDietsQueryResponse>(new DietPreparationException(DietRequestErrorCode.ReadException));
		}
	}
}

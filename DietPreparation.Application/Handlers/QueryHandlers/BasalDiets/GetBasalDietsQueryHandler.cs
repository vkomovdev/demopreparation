using DietPreparation.Application.Queries.Requests.BasalDiets;
using DietPreparation.Application.Queries.Responses.BasalDiets;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Services.BasalDiets.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.QueryHandlers.BasalDiets;

internal class GetBasalDietsQueryHandler : IRequestHandler<GetBasalDietsQueryRequest, GetBasalDietsQueryResponse>
{
	private readonly IBasalDietReader _basalDietReader;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public GetBasalDietsQueryHandler(IBasalDietReader basalDietReader, IMapper mapper, IDietPreparationLogger logger)
	{
		_basalDietReader = basalDietReader;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<GetBasalDietsQueryResponse> Handle(GetBasalDietsQueryRequest request, CancellationToken cancellationToken)
	{
		try
		{
			var basalDietDtos = await _basalDietReader.ReadAllAsync();

			return _mapper.Map<GetBasalDietsQueryResponse>(basalDietDtos);
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<GetBasalDietsQueryResponse>(new DietPreparationException(DietRequestErrorCode.ReadException));
		}
	}
}
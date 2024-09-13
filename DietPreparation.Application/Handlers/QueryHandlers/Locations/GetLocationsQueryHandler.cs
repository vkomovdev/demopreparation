using DietPreparation.Application.Queries.Requests.Locations;
using DietPreparation.Application.Queries.Responses.Locations;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Services.Locations.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.QueryHandlers.Locations;

internal class GetLocationsQueryHandler : IRequestHandler<GetLocationsQueryRequest, GetLocationsQueryResponse>
{
	private readonly ILocationReader _locationReader;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public GetLocationsQueryHandler(ILocationReader locationReader, IMapper mapper, IDietPreparationLogger logger)
	{
		_locationReader = locationReader;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<GetLocationsQueryResponse> Handle(GetLocationsQueryRequest request, CancellationToken cancellationToken)
	{
		try
		{
			var locations = await _locationReader.ReadAllAsync();

			return _mapper.Map<GetLocationsQueryResponse>(locations);
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<GetLocationsQueryResponse>(new DietPreparationException(DietRequestErrorCode.ReadException));
		}
	}
}

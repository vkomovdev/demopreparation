using DietPreparation.Application.Queries.Requests.Locations;
using DietPreparation.Application.Queries.Responses.Locations;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Services.Locations.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.QueryHandlers.Locations;

internal class GetLocationQueryHandler : IRequestHandler<GetLocationQueryRequest, GetLocationQueryResponse>
{
	private readonly ILocationReader _locationReader;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public GetLocationQueryHandler(ILocationReader locationReader, IMapper mapper, IDietPreparationLogger logger)
	{
		_locationReader = locationReader;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<GetLocationQueryResponse> Handle(GetLocationQueryRequest request, CancellationToken cancellationToken)
	{
		try
		{
			var location = await _locationReader.ReadAsync(request.LocationId);

			if (location is null)
			{
				throw new DietPreparationException(CommonErrorCode.EntityNotFound);
			}

			return _mapper.Map<GetLocationQueryResponse>(location);
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<GetLocationQueryResponse>(new DietPreparationException(DrugErrorCode.ReadException));
		}
	}
}

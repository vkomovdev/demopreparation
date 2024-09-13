using DietPreparation.Application.Queries.Requests.Locations;
using DietPreparation.Application.Queries.Responses.Locations;
using DietPreparation.Services.Drugs.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.QueryHandlers.Locations;
public class GetFilteredLocationsQueryHandler : IRequestHandler<GetFilteredLocationsQueryRequest, GetFilteredLocationsQueryResponse>
{
	private readonly ILocationFilter _locationFilter;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public GetFilteredLocationsQueryHandler(ILocationFilter locationFilter, IMapper mapper, IDietPreparationLogger logger)
	{
		_locationFilter = locationFilter;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<GetFilteredLocationsQueryResponse> Handle(GetFilteredLocationsQueryRequest request, CancellationToken cancellationToken)
	{
		try
		{
			if (request.Pagination is null)
			{
				throw new DietPreparationException(CommonErrorCode.ArgumentNullException);
			}

			var locations = await _locationFilter.SortLimitedAsync(request.OrderBy, request.Pagination)
				?? throw new DietPreparationException(CommonErrorCode.EntityNotFound);

			var response = _mapper.Map<GetFilteredLocationsQueryResponse>(request.Pagination);

			_mapper.Map(locations, response);
			return response;
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<GetFilteredLocationsQueryResponse>(new DietPreparationException(CommonErrorCode.UnhandledException));
		}
	}
}

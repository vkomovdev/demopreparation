using DietPreparation.Application.Commands.Requests;
using DietPreparation.Application.Commands.Responses;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Models.DTO;
using DietPreparation.Models.DTO.FilterOptions;
using DietPreparation.Services.Drugs.Interfaces;
using DietPreparation.Services.Locations.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.CommandHandlers;

internal class CreateUpdateLocationCommandHandler : IRequestHandler<CreateUpdateLocationRequest, CreateUpdateLocationResponse>
{
	private readonly ILocationUpdater _locationUpdater;
	private readonly ILocationFilter _locationFilter;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public CreateUpdateLocationCommandHandler(ILocationUpdater locationUpdater, ILocationFilter locationFilter, IMapper mapper, IDietPreparationLogger logger)
	{
		_locationUpdater = locationUpdater;
		_locationFilter = locationFilter;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<CreateUpdateLocationResponse> Handle(CreateUpdateLocationRequest request, CancellationToken cancellationToken)
	{
		try
		{
			var updateEntity = _mapper.Map<LocationUpdateDto>(request);

			var filterDto = _mapper.Map<LocationFilterDto>(updateEntity);
			var duplicates = await _locationFilter.FilterAsync(filterDto);
			if (duplicates.Any(x => x.Id != updateEntity.Id))
			{
				return _mapper.Map<CreateUpdateLocationResponse>(new DietPreparationException(LocationErrorCode.DuplicateIsForbidden));
			}

			var locationUpdateDto = await _locationUpdater.UpdateAsync(updateEntity);

			return _mapper.Map<CreateUpdateLocationResponse>(locationUpdateDto);
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<CreateUpdateLocationResponse>(new DietPreparationException(DietRequestErrorCode.CreateException));
		}
	}
}

using DietPreparation.Models.DTO;
using DietPreparation.Repositories.Spaces.Interfaces;
using DietPreparation.Services.Locations.Interfaces;
using MapsterMapper;

namespace DietPreparation.Services.Drugs;

internal class LocationUpdater : ILocationUpdater
{
	private readonly ILocationRepository _locationRepository;
	private readonly IMapper _mapper;

	public LocationUpdater(ILocationRepository locationRepository, IMapper mapper)
	{
		_locationRepository = locationRepository;
		_mapper = mapper;
	}

	public async Task<LocationUpdateDto> UpdateAsync(LocationUpdateDto entity)
	{
		var id = await _locationRepository.UpdateAsync(_mapper.Map<LocationUpdateDao>(entity));

		entity.Id = id;

		return entity;
	}
}

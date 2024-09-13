using DietPreparation.Filter.Options;
using DietPreparation.Models.DAO.FilterOptions;
using DietPreparation.Models.DTO;
using DietPreparation.Models.DTO.FilterOptions;
using DietPreparation.Repositories.Spaces.Interfaces;
using DietPreparation.Services.Drugs.Interfaces;
using MapsterMapper;

namespace DietPreparation.Services.Drugs;

internal class LocationFilter : ILocationFilter
{
	private readonly ILocationRepository _locationRepository;
	private readonly IMapper _mapper;

	public LocationFilter(ILocationRepository locationRepository, IMapper mapper)
	{
		_locationRepository = locationRepository;
		_mapper = mapper;
	}

	public async ValueTask<IEnumerable<LocationDto>> FilterAsync(LocationFilterDto filter)
	{
		var filterDao = _mapper.Map<LocationFilterDao>(filter);
		var result = await _locationRepository.FilterAsync(filterDao);

		return _mapper.Map<IEnumerable<LocationDto>>(result);
	}

	public async ValueTask<IEnumerable<LocationsItemDto>> SortLimitedAsync(IOrderBy orderBy, IPagination pagination)
	{
		var orderByEntity = _mapper.Map<OrderByDao>(orderBy);
		var paginationEntity = _mapper.Map<PaginationDao>(pagination);

		var locations = await _locationRepository.GetPaginatedLocationsAsync(orderByEntity, paginationEntity);

		return _mapper.Map<IEnumerable<LocationsItemDto>>(locations);
	}
}
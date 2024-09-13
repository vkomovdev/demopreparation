using DietPreparation.Common.Enums;
using DietPreparation.Filter.Options;
using DietPreparation.Models.DAO.FilterOptions;
using DietPreparation.Models.DTO;
using DietPreparation.Models.DTO.DietRequests;
using DietPreparation.Models.DTO.FilterOptions;
using DietPreparation.Models.DTO.TableOptions;
using DietPreparation.Repositories.Spaces.Searches.Interfaces;
using MapsterMapper;

namespace DietPreparation.Services.DietRequests;
internal class DietRequestFilter : Interfaces.IDietRequestFilter
{
	private readonly ISearchesRepository _searchRepository;
	private readonly IMapper _mapper;

	public DietRequestFilter(ISearchesRepository searchRepository, IMapper mapper)
	{
		_searchRepository = searchRepository;
		_mapper = mapper;
	}

	public async ValueTask<IEnumerable<DietRequestDto>> FilterSortedAsync(PwoTypeFilterDto filter, IOrderBy orderBy, IPagination pagination)
	{
		var orderByDao = _mapper.Map<OrderByDao>(orderBy);
		var paginationDao = _mapper.Map<PaginationDao>(pagination);

		var dietRequests = filter.Type == PwoType.Initiate ?
			await _searchRepository.PwoInitiateAsync(orderByDao, paginationDao) :
			await _searchRepository.PwoCloseAsync(orderByDao, paginationDao);

		return dietRequests.Select(_mapper.Map<DietRequestDto>);
	}

	public async ValueTask<IEnumerable<DietRequestDto>> FilterSortedAsync(PwoFilterDto filter, IOrderBy orderBy, IPagination pagination)
	{
		var orderByDao = _mapper.Map<OrderByDao>(orderBy);
		var filterDao = _mapper.Map<PwoFilterDao>(filter);
		var paginationDao = _mapper.Map<PaginationDao>(pagination);

		var dietRequests = await _searchRepository.DietRequestsAsync(filterDao, orderByDao, paginationDao);
		return dietRequests.Select(_mapper.Map<DietRequestDto>);
	}

	public async ValueTask<IEnumerable<DietRequestDto>> FilterSortedAsync(FeedLabelFilterDto filter, IOrderBy orderBy, IPagination pagination)
	{
		var orderByDao = _mapper.Map<OrderByDao>(orderBy);
		var filterDao = _mapper.Map<FeedLabelFilterDao>(filter);
		var paginationDao = _mapper.Map<PaginationDao>(pagination);

		var dietRequests = await _searchRepository.DietRequestsAsync(filterDao, orderByDao, paginationDao);
		return dietRequests.Select(_mapper.Map<DietRequestDto>);
	}

	public async ValueTask<IEnumerable<DietRequestSearchDto>> FilterSortedAsync(DietRequestFilterDto filter, IOrderBy orderBy, IPagination pagination)
	{
		var filterDao = _mapper.Map<DietRequestFilterDao>(filter);
		var orderByDao = _mapper.Map<OrderByDao>(orderBy);
		var paginationDao = _mapper.Map<PaginationDao>(pagination);

		var dietRequests = await _searchRepository.DietRequestsAsync(filterDao, orderByDao, paginationDao);
		return dietRequests.Select(_mapper.Map<DietRequestSearchDto>);
	}

	public async ValueTask<IEnumerable<DietRequestTinyDto>> FilterAsync(DietRequestTinyFilterDto filter)
	{
		var filterDao = _mapper.Map<DietRequestTinyFilterDao>(filter);

		var dietRequests = await _searchRepository.DietRequestsAsync(filterDao);
		return dietRequests.Select(_mapper.Map<DietRequestTinyDto>);
	}
}
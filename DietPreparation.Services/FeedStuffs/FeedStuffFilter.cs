using DietPreparation.Filter.Options;
using DietPreparation.Models.DAO;
using DietPreparation.Models.DAO.FilterOptions;
using DietPreparation.Models.DTO;
using DietPreparation.Models.DTO.FilterOptions;
using DietPreparation.Repositories.Spaces.Interfaces;
using MapsterMapper;
using System.Drawing.Printing;

namespace DietPreparation.Services.FeedStuffs;

internal class FeedStuffFilter : Interfaces.IFeedStuffFilter
{
	private readonly IFeedStuffRepository _feedStuffRepository;
	private readonly IFeedStuffSearchRepository _feedStuffSearchRepository;
	private readonly IMapper _mapper;

	public FeedStuffFilter(IFeedStuffRepository feedStuffRepository, IFeedStuffSearchRepository feedStuffSearchRepository, IMapper mapper)
	{
		_feedStuffRepository = feedStuffRepository;
		_feedStuffSearchRepository = feedStuffSearchRepository;
		_mapper = mapper;
	}

	public async ValueTask<IEnumerable<FeedStuffDto>> SortAsync(IOrderBy orderBy)
	{
		var entityOrderBy = _mapper.Map<OrderByDao>(orderBy);

		var feedStuffs = await _feedStuffRepository.ReadAllAsync(entityOrderBy);
		return _mapper.Map<IEnumerable<FeedStuffDto>>(feedStuffs);
	}

	public async ValueTask<IEnumerable<FeedStuffPlanningDto>> FilterSortedAsync(FeedStuffPlanningFilterDto filter, IOrderBy orderBy, IPagination pagination)
	{
		var orderByDao = _mapper.Map<OrderByDao>(orderBy);
		var filterDao = _mapper.Map<FeedStuffFilterDao>(filter);
		var paginationDao = _mapper.Map<PaginationDao>(pagination);

		var feedStuffs = await _feedStuffSearchRepository.SearchAsync(filterDao, orderByDao, paginationDao);

		if (!feedStuffs.Any()) {
			return Enumerable.Empty<FeedStuffPlanningDto>();
		}

		var feedStuffsOnPage = feedStuffs.Skip((paginationDao.Page - 1) * paginationDao.PageSize)
			.Take(paginationDao.PageSize)
			.Select(x =>
			{
				x.TotalItems = feedStuffs.Count();
				return x;
			});

		return _mapper.Map<IEnumerable<FeedStuffPlanningDto>>(feedStuffsOnPage);
	}
}
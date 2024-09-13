using DietPreparation.Filter.Interfaces;
using DietPreparation.Filter.Options;
using MapsterMapper;

namespace DietPreparation.Filter.BaseServices;
public abstract class BaseSorteLimitedServise<T, U, Y, Z> : ISortLimited<T, U, Y>
	where T : class
	where U : IOrderBy
	where Y : IPagination
	where Z : ISortLimited<T, U, Y>
{
	private readonly Z _repository;
	private readonly IMapper _mapper;

	public BaseSorteLimitedServise(Z repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public virtual async ValueTask<IEnumerable<T>> SortLimitedAsync(U orderBy, Y pagination)
	{
		var orderByDao = _mapper.Map<U>(orderBy);
		var paginationDao = _mapper.Map<Y>(pagination);

		return (await _repository.SortLimitedAsync(orderByDao, pagination)).Select(_mapper.Map<T>);
	}
}

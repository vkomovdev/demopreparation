using DietPreparation.Filter.Interfaces;
using DietPreparation.Filter.Options;
using MapsterMapper;

namespace DietPreparation.Filter.BaseServices;
public abstract class BaseFilterSortedService<T, U, Y, Z, X> : IFilterSorted<T, U, Y, Z>
	where T : class
	where U : IFilterBy
	where Y : IOrderBy
	where Z : IPagination
	where X : IFilterSorted<T, U, Y, Z>
{
	private readonly X _repository;
	private readonly IMapper _mapper;

	public BaseFilterSortedService(X repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public virtual async ValueTask<IEnumerable<T>> FilterSortedAsync(U filter, Y orderBy, Z pagination)
	{
		var filterDao = _mapper.Map<U>(filter);
		var orderByDao = _mapper.Map<Y>(orderBy);
		var paginationDao = _mapper.Map<Z>(pagination);

		return (await _repository.FilterSortedAsync(filterDao, orderByDao, paginationDao)).Select(_mapper.Map<T>);
	}
}
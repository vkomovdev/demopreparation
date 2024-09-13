using DietPreparation.Filter.Interfaces;
using DietPreparation.Filter.Options;
using MapsterMapper;

namespace DietPreparation.Filter.BaseServices;
public abstract class BaseFilterLimitedService<T, U, Y, Z> : IFilterLimited<T, U, Y>
	where T : class
	where U : IFilterBy
	where Y : IPagination
	where Z : IFilterLimited<T, U, Y>
{
	private readonly Z _repository;
	private readonly IMapper _mapper;

	public BaseFilterLimitedService(Z repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public virtual async ValueTask<IEnumerable<T>> FilterLimitedAsync(U filter, Y pagination)
	{
		var filterDao = _mapper.Map<U>(filter);
		var paginationDao = _mapper.Map<Y>(pagination);

		return (await _repository.FilterLimitedAsync(filterDao, paginationDao)).Select(_mapper.Map<T>);
	}
}
using DietPreparation.Filter.Interfaces;
using DietPreparation.Filter.Options;
using MapsterMapper;

namespace DietPreparation.Filter.BaseServices;
public abstract class BaseFilterServise<T, U, Y> : IFilter<T, U>
	where T : class
	where U : IFilterBy
	where Y : IFilter<T, U>
{
	private readonly Y _repository;
	private readonly IMapper _mapper;

	public BaseFilterServise(Y repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public virtual async ValueTask<IEnumerable<T>> FilterAsync(U filter)
	{
		var filterDao = _mapper.Map<U>(filter);

		return (await _repository.FilterAsync(filterDao)).Select(_mapper.Map<T>);
	}
}
using DietPreparation.Filter.Interfaces;
using DietPreparation.Filter.Options;
using MapsterMapper;

namespace DietPreparation.Filter.BaseServices;
public abstract class BaseSortServise<T, U, Y> : ISort<T, U>
	where T : class
	where U : IOrderBy
	where Y : ISort<T, U>
{
	private readonly Y _repository;
	private readonly IMapper _mapper;

	public BaseSortServise(Y repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public virtual async ValueTask<IEnumerable<T>> SortAsync(U orderBy)
	{
		var orderByDao = _mapper.Map<U>(orderBy);

		return (await _repository.SortAsync(orderByDao)).Select(_mapper.Map<T>);
	}
}

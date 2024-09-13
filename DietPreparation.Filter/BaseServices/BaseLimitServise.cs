using DietPreparation.Filter.Interfaces;
using DietPreparation.Filter.Options;
using MapsterMapper;

namespace DietPreparation.Filter.BaseServices;
public abstract class BaseLimitServise<T, U, Y> : ILimit<T, U>
	where T : class
	where U : IPagination
	where Y : ILimit<T, U>
{
	private readonly Y _repository;
	private readonly IMapper _mapper;

	public BaseLimitServise(Y repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public virtual async ValueTask<IEnumerable<T>> LimitAsync(U pagination)
	{
		var paginationDao = _mapper.Map<U>(pagination);

		return (await _repository.LimitAsync(paginationDao)).Select(_mapper.Map<T>);
	}
}
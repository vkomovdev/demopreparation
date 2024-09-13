using DietPreparation.Filter.Options;

namespace DietPreparation.Filter.Interfaces;

public interface ILimit<T, U> where U : IPagination
{
	ValueTask<IEnumerable<T>> LimitAsync(U pagination);
}
using DietPreparation.Filter.Options;

namespace DietPreparation.Filter.Interfaces;

public interface ISort<T, U> where U : IOrderBy
{
	ValueTask<IEnumerable<T>> SortAsync(U orderBy);
}
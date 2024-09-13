using DietPreparation.Filter.Options;

namespace DietPreparation.Filter.Interfaces;

public interface IFilter<T, U> where U : IFilterBy
{
	ValueTask<IEnumerable<T>> FilterAsync(U filter);
}
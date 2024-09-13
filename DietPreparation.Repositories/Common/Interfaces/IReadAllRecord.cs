namespace DietPreparation.Repositories.Common.Interfaces;

public interface IReadAllRecord<T>
{
	ValueTask<IEnumerable<T>> ReadAllAsync();
}

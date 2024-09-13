namespace DietPreparation.Services.Common.Interfaces;

public interface IReadAll<T>
{
	Task<IEnumerable<T>> ReadAllAsync();
}

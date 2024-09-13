namespace DietPreparation.Common.Interfaces;

public interface ICommonCreate<T>
{
	Task<T> CreateAsync(T entity);
}
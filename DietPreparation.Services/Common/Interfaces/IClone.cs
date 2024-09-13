namespace DietPreparation.Services.Common.Interfaces;

public interface IClone<T, U>
{
	Task<U> CloneAsync(T entity);
}
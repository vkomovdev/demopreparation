namespace DietPreparation.Common.Interfaces;

public interface ICommonRead<T, U>
{
	Task<U> ReadAsync(T id);
}

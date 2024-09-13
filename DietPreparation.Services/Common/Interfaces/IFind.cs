namespace DietPreparation.Services.Common.Interfaces;

public interface IFind<T>
{
	ValueTask<IEnumerable<T>> FindAsync();
}

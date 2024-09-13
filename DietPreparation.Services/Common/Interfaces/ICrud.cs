namespace DietPreparation.Services.Common.Interfaces;

public interface ICrud<T, U, Y> :
	ICreate<T>,
	IRead<T, U>,
	IUpdate<T>,
	IDelete<T, Y>
{
}

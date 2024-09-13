namespace DietPreparation.Repositories.Common.Interfaces;

public interface ICrud<T, U> :
	IInsertRecord<T, U>,
	IReadRecord<T, U>,
	IReadAllRecord<T>,
	IUpdateRecord<T>,
	IDeleteRecord<T, U>
{
}

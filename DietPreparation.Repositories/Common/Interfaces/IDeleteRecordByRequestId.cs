namespace DietPreparation.Repositories.Common.Interfaces;

public interface IDeleteRecordByRequestId<U>
{
	Task<U> DeleteByRequestIdAsync(int requestId);
}
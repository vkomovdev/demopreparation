namespace DietPreparation.Repositories.Common.Interfaces;

public interface IReadRecordByRequestId<U>
{
	Task<U> ReadByRequestIdAsync(int requestId);
}

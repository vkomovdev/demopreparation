using DietPreparation.Models.DAO;
using DietPreparation.Repositories.Common.Interfaces;

namespace DietPreparation.Repositories.Spaces.Interfaces;

public interface IDietRequestExternalFeedRepository :
	IInsertRecord<DietRequestExternalFeedDao, int>,
	IDeleteRecordByRequestId<int>
{
	ValueTask<int> ReadRecordIdByRequestIdAsync(int requestId);
}

using DietPreparation.Models.DAO;
using DietPreparation.Repositories.Common.Interfaces;

namespace DietPreparation.Repositories.Spaces.Interfaces;

public interface IDietRequestInternalFeedRepository :
	IInsertRecord<DietRequestInternalFeedDao, int>
{
	ValueTask<int> ReadRecordIdByRequestIdAsync(int requestId);
}

using DietPreparation.Models.DAO;
using DietPreparation.Repositories.Common.Interfaces;

namespace DietPreparation.Repositories.Spaces.Interfaces;

public interface IDietRequestBasalDietRepository :
	IInsertRecord<DietRequestBasalDietDao, int>,
	IReadRecordByRequestId<DietRequestBasalDietDao>,
	IDeleteRecordByRequestId<int>
{
	ValueTask<int> ReadRecordIdByRequestIdAsync(int requestId);
}

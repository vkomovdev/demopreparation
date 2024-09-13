using DietPreparation.Models.DAO;
using DietPreparation.Repositories.Common.Interfaces;

namespace DietPreparation.Repositories.Spaces.Interfaces;

public interface IDietRequestSampleRepository :
	IInsertRecord<DietRequestSampleDao, int>,
	IReadRecordByRequestId<IEnumerable<DietRequestSampleDao>>,
	IDeleteRecordByRequestId<int>
{
}

using DietPreparation.Models.DAO;
using DietPreparation.Repositories.Common.Interfaces;

namespace DietPreparation.Repositories.Spaces.Interfaces;

public interface IDietRequestDrugRepository :
	IInsertRecord<DietRequestDrugDao, int>,
	IReadRecordByRequestId<IEnumerable<DietRequestDrugSelectDao>>,
	IDeleteRecordByRequestId<int>
{
}

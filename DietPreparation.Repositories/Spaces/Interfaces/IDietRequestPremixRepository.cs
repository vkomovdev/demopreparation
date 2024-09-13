using DietPreparation.Models.DAO;
using DietPreparation.Repositories.Common.Interfaces;

namespace DietPreparation.Repositories.Spaces.Interfaces;

public interface IDietRequestPremixRepository :
	IInsertRecord<DietRequestPremixDao, int>,
	IReadRecordByRequestId<IEnumerable<DietRequestPremixSelectDao>>,
	IDeleteRecordByRequestId<int>
{
}

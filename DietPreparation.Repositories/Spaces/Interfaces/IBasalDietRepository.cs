using DietPreparation.Models.DAO;
using DietPreparation.Repositories.Common.Interfaces;

namespace DietPreparation.Repositories.Spaces.Interfaces;

public interface IBasalDietRepository :
	IReadAllRecord<BasalDietDao>,
	IReadRecord<string, BasalDietDao>,
	IUpsertRecord<BasalDietDao, BasalDietDao>
{

	ValueTask<IEnumerable<BasalDietDao>> BasalDietsAsync(string sColumn, string sSlope);
}

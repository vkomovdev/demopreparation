using DietPreparation.Models.DAO;
using DietPreparation.Models.DAO.FilterOptions;
using DietPreparation.Models.DTO;
using DietPreparation.Repositories.Common.Interfaces;

namespace DietPreparation.Repositories.Spaces.Interfaces;

public interface IDrugsRepository : IReadAllRecord<DrugDao>, IReadRecord<int, DrugDao>
{
	Task AuditDrugUpdate(string iAuditLogNumber,
					string sDrug_Name,
					 string sDrugNeeded,
					 string sDrugNeededUOM,
					 string sDrugWeightYN,
					 string sMfgLot);

	ValueTask<IEnumerable<DrugDao>> GetDrugsAsync(string sColumn, string sSlope, string sDrug_ID);

	ValueTask<string?> DrugUpdate(DrugUpdateDto model);

	ValueTask<IEnumerable<IngredientDao>> GetIngredientsAsync();

	ValueTask<IEnumerable<DrugsItemDao>> GetPaginatedDrugAsync(OrderByDao orderByDao, PaginationDao paginationDao);
}

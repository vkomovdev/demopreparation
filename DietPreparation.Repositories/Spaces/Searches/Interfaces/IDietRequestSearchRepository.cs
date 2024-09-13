using DietPreparation.Filter.Options;
using DietPreparation.Models.DAO;
using DietPreparation.Models.DAO.FilterOptions;
using DietPreparation.Models.DTO.TableOptions;

namespace DietPreparation.Repositories.Spaces.Interfaces;

public interface IDietRequestSearchRepository : ISearchRepository<DietRequestDao>
{
	ValueTask<IEnumerable<DietRequestDao>> SearchAsync(IDietRequestFilter filterDao, IOrderByDao orderByDao, IPagination paginationDao);
	ValueTask<IEnumerable<DietRequestTinyDao>> SearchAsync(IDietRequestTinyFilter filterDao);
}
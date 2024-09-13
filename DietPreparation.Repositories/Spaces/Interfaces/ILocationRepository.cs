using DietPreparation.Models.DAO;
using DietPreparation.Models.DAO.FilterOptions;
using DietPreparation.Models.DTO;
using DietPreparation.Repositories.Common.Interfaces;

namespace DietPreparation.Repositories.Spaces.Interfaces;

public interface ILocationRepository : IReadAllRecord<LocationDao>, IReadRecord<int, LocationDao>
{
	ValueTask<IEnumerable<LocationDao>> GetLocationsAsync(string sColumn, string sSlope, string sLocation_ID);
	ValueTask<int> UpdateAsync(LocationUpdateDao model);
	ValueTask<int> InsertAsync(LocationDao model);
	ValueTask<IEnumerable<LocationsItemDao>> GetPaginatedLocationsAsync(OrderByDao orderByDao, PaginationDao paginationDao);
	Task<IEnumerable<LocationDao>> FilterAsync(LocationFilterDao filter);
}

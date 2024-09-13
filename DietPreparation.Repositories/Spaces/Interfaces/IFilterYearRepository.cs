using DietPreparation.Models.DAO;
using DietPreparation.Repositories.Common.Interfaces;

namespace DietPreparation.Repositories.Spaces.Interfaces;
public interface IFilterYearRepository: IUpdateRecord<int>
{
	Task<int> ReadAsync();
}

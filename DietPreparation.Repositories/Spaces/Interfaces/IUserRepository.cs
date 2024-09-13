using DietPreparation.Models.DAO;
using DietPreparation.Models.DAO.FilterOptions;
using DietPreparation.Repositories.Common.Interfaces;

namespace DietPreparation.Repositories.Spaces.Interfaces;

public interface IUserRepository : IReadRecord<string, UserDao?>, IReadAllRecord<UserDao>, IUpdateRecord<CreateUpdateUserDao>
{
	ValueTask<IEnumerable<UserDao>> ReadAllAsync(OrderByDao orderBy);
	ValueTask<UserDao?> FindAsync(string userName);
}
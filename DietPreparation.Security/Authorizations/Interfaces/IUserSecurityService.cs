using DietPreparation.Security.Models;

namespace DietPreparation.Security.Authorizations.Interfaces
{
	public interface IUserSecurityService
	{
		Task<UserSecurityInfo> GetUserSecurityInfo(string userName);
		Task<bool> ExistUser(string userName);
	}
}

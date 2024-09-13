using DietPreparation.Common.Extensions;
using DietPreparation.Data.UnitOfWork;
using DietPreparation.Models.DAO;
using DietPreparation.Models.DAO.FilterOptions;
using DietPreparation.Repositories.Spaces.Interfaces;

namespace DietPreparation.Repositories.Spaces;

internal class UserRepository : IUserRepository
{
	private const string UserIU = "DPS_USER_IU";
	private const string UserSelect = "DPS_USER_SELECT";

	private readonly IUnitOfWork _unitOfWork;

	public UserRepository(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<CreateUpdateUserDao> UpdateAsync(CreateUpdateUserDao model)
	{
		await GetUserIU(model);
		return model;
	}

	public async Task<UserDao?> ReadAsync(string userId)
	{
		return (await GetUserSelect(userId, null)).FirstOrDefault();
	}

	public async ValueTask<IEnumerable<UserDao>> ReadAllAsync()
	{
		return await GetUserSelect(null, null);
	}

	public async ValueTask<IEnumerable<UserDao>> ReadAllAsync(OrderByDao orderBy)
	{
		return await GetUserSelect(null, orderBy.ORDER_BY);
	}

	private async Task GetUserIU(CreateUpdateUserDao model)
	{
		var cmd = $"{UserIU} {model.USERIDKEY}, {model.USERID.ToSqlValue()}, {model.FIRSTNAME.ToSqlValue()}, {model.MIDDLENAME.ToSqlValue()}, {model.LASTNAME.ToSqlValue()}, {model.EMAILADDRESS.ToSqlValue()}, {model.ACCESSKEY}";
		await _unitOfWork.ExecuteAsync(cmd);
	}

	private async ValueTask<IEnumerable<UserDao>> GetUserSelect(string? userId, string? orderBy)
	{
		var cmd = $"{UserSelect} {userId.ToSqlValue()}, {orderBy.ToSqlValue()}";
		return await _unitOfWork.QueryAsync<UserDao>(cmd);
	}

	public async ValueTask<UserDao?> FindAsync(string userName)
	{
		string sql = $"SELECT USERIDKEY, EmailAddress FROM DP_Logon_UserID_List WHERE USERID = '{userName}'";

		var result = await _unitOfWork.QueryAsync<UserDao>(sql);

		return result.Any() ? result.First() : null;
	}
}
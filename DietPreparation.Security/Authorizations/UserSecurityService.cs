using DietPreparation.Security.Authorizations.Interfaces;
using DietPreparation.Security.Models;
using DietPreparation.Security.Options;
using DietPreparation.Services.Users.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using MapsterMapper;

namespace DietPreparation.Security.Authorizations
{
	public class UserSecurityService : IUserSecurityService
	{
		private readonly IUserReader _userReader;
		private readonly IMapper _mapper;
		private readonly AuthorizationOptions _authorizationOptions;

		public UserSecurityService(IUserReader userReader, IMapper mapper, ApplicationOptions applicationOptions)
		{
			_mapper = mapper;
			_userReader = userReader;
			_authorizationOptions = applicationOptions.Authorization;
		}

		public async Task<UserSecurityInfo> GetUserSecurityInfo(string userName)
		{
			var userDto = _authorizationOptions.MockUser is not null
				? _authorizationOptions.MockUser
				: await _userReader.ReadAsync(userName);

			return userDto is not null
				? _mapper.Map<UserSecurityInfo>(userDto)
				: throw new DietPreparationException(CommonErrorCode.EntityNotFound);
		}

		public async Task<bool> ExistUser(string userName)
		{
			var user = await _userReader.FindAsync(userName);

			return user is not null;
		}
	}
}

using DietPreparation.Common.Extensions;
using DietPreparation.Security.Authentications.Interfaces;
using DietPreparation.Security.Authorizations.Interfaces;
using DietPreparation.Security.Models;
using DietPreparation.Security.Options;
using DietPreparation.Utilities.ExceptionHandler;

namespace DietPreparation.Security.Authorizations
{
	internal class AuthorizationService : IAuthorizationService
	{
		private readonly IAuthContextAccessor _authContextAccessor;
		private readonly IUserSecurityService _userSecurityService;
		private readonly AuthorizationOptions _authorizationOptions;

		public AuthorizationService(IAuthContextAccessor authContextAccessor,
			IUserSecurityService userSecurityService,
			ApplicationOptions applicationOptions)
		{
			_authContextAccessor = authContextAccessor;
			_userSecurityService = userSecurityService;
			_authorizationOptions = applicationOptions.Authorization;
		}

		public async Task ValidateAuthorization(IAuthorizationDescriptor descriptor)
		{
			if (!_authorizationOptions.IsUsed && _authorizationOptions.MockUser is null)
			{
				return;
			}

			if (!_authContextAccessor.IsAuthenticated)
			{
				throw new UnauthorizedException("Unauthenticated user cannot access authorized data");
			}

			if (!await IsAuthorized(descriptor))
			{
				throw new UnauthorizedException("Attempt of unauthorized access");
			}
		}

		public async Task<bool> IsAuthorized(IAuthorizationDescriptor descriptor)
		{
			var userName = _authContextAccessor.UserName[1..].Split('\\')[^1].ToUpper();

			var result = await IsAuthorized(userName, descriptor);

			return result;
		}

		public async Task<bool> IsAuthorized(string userName, IAuthorizationDescriptor descriptor)
		{
			var userInfo = await _userSecurityService.GetUserSecurityInfo(userName);

			return IsAnyAuthorized(userInfo.Permissions, descriptor.PermissionKeys);
		}

		private bool IsAnyAuthorized(IEnumerable<PermissionInfo> availableRoles, IEnumerable<string> requiredRoles)
		{
			var intersection = availableRoles.IntersectByNonDistinct(requiredRoles, x => x.Name);

			return intersection.Any();
		}
	}
}

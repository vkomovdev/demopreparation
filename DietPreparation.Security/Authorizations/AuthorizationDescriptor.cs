using DietPreparation.Security.Authorizations.Interfaces;


namespace DietPreparation.Security.Authorizations
{
	internal class AuthorizationDescriptor : IAuthorizationDescriptor
	{
		public AuthorizationDescriptor(params string[] permissionKeys)
		{
			PermissionKeys = permissionKeys;
		}

		public IReadOnlyCollection<string> PermissionKeys { get; }
	}
}
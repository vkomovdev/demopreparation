namespace DietPreparation.Security.Authorizations.Interfaces
{
	public interface IAuthorizationDescriptor
	{
		IReadOnlyCollection<string> PermissionKeys { get; }
	}
}

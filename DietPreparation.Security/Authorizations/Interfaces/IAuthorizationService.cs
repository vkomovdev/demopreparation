namespace DietPreparation.Security.Authorizations.Interfaces
{
	internal interface IAuthorizationService
	{
		Task ValidateAuthorization(IAuthorizationDescriptor descriptor);

		Task<bool> IsAuthorized(IAuthorizationDescriptor descriptor);

		Task<bool> IsAuthorized(string userName, IAuthorizationDescriptor descriptor);
	}
}

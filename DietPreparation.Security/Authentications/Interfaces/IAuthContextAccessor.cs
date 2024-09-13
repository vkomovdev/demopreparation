namespace DietPreparation.Security.Authentications.Interfaces
{
	public interface IAuthContextAccessor
	{
		string? UserName { get; }

		bool IsAuthenticated { get; }
	}
}

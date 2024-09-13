using DietPreparation.Security.Authentications.Interfaces;
using Microsoft.AspNetCore.Http;

namespace DietPreparation.Security.Authentications;
internal class AuthContextAccessor: IAuthContextAccessor
{
	private readonly IHttpContextAccessor _httpContextAccessor;

	public AuthContextAccessor(IHttpContextAccessor httpContextAccessor)
	{
		_httpContextAccessor = httpContextAccessor;
	}

	public string? UserName => _httpContextAccessor.HttpContext?.User.Identity?.Name;

	public bool IsAuthenticated => _httpContextAccessor.HttpContext?.User.Identity?.IsAuthenticated ?? false;
}

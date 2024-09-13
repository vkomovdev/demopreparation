using DietPreparation.Security.Authorizations.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace DietPreparation.Security.Authorizations
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
	public class AuthorizeAttribute : Attribute, IAsyncAuthorizationFilter
	{
		private readonly IAuthorizationDescriptor _authorizationDescriptor;

		public AuthorizeAttribute(params string[] permissionKeys)
		{
			_authorizationDescriptor = new AuthorizationDescriptor(permissionKeys);
		}

		public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
		{
			try
			{
				var authorizationService = context.HttpContext.RequestServices.GetRequiredService<IAuthorizationService>();
				await authorizationService.ValidateAuthorization(_authorizationDescriptor);
			}
			catch (Exception)
			{
				context.Result = new RedirectToActionResult("Error", "Error", new { statusCode = 401 });
				return;
			}
			
		}
	}
}

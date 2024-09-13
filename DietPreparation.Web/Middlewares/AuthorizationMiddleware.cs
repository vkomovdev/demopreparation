using DietPreparation.Common.Extensions;
using DietPreparation.Security.Authorizations.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Web.Options;
using System.Security.Claims;

public class AuthorizationMiddleware
{
	private static readonly string NonProdExceptionalRequest = "/health";
	private static readonly string ErrorMessage = "Attempt of unauthorized access";

	private readonly RequestDelegate _next;
	private readonly IHostEnvironment _hostEnvironment;
	private readonly AuthorizationOptions _authorizationOptions;

	public AuthorizationMiddleware(
		RequestDelegate next,
		IHostEnvironment hostEnvironment,
		ApplicationOptions applicationOptions)
	{
		_next = next;
		_hostEnvironment = hostEnvironment;
		_authorizationOptions = applicationOptions.Authorization;
	}

	public async Task InvokeAsync(HttpContext context, IUserSecurityService userSecurityService)
	{
		if (!_authorizationOptions.IsUsed)
		{
			await _next(context);
			return;
		}

		try
		{
			if (context.Request.Path.StartsWithSegments(NonProdExceptionalRequest))
			{
				if (_hostEnvironment.IsNonProduction())
				{
					await _next(context);
					return;
				}

				throw new UnauthorizedException(ErrorMessage);
			}

			var userName = string.Empty;

			if (_authorizationOptions.MockUser is null)
			{
				userName = context.User.FindFirst(ClaimTypes.Name)?.Value
					?? context.User?.Identity?.Name
					?? throw new UnauthorizedException(ErrorMessage);

				userName = userName[1..].Split('\\')[^1].ToUpper();

				var isUserExist = await userSecurityService.ExistUser(userName);

				if (!isUserExist)
				{
					throw new UnauthorizedException(ErrorMessage);
				}

				await _next(context);
				return;
			}

			var mockUser = _authorizationOptions.MockUser;
		}
		catch (Exception)
		{
			context.Request.Path = $"/Error/{context.Response.StatusCode}";
			await _next(context);
		}

		await _next(context);
	}
}

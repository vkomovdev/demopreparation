namespace DietPreparation.Web.Configurations;

public static class AuthorizationExtensions
{
	public static void AddPolicy(this IServiceCollection services)
	{
		services.AddAuthorization(options =>
		{
			// By default, all incoming requests will be authorized according to the default policy.
			options.FallbackPolicy = options.DefaultPolicy;
			//TODO define policy if it needs
			//options.AddPolicy("RequireAdminRole", policy =>
			//	policy.RequireRole("Admin"));

			//options.AddPolicy("RequireAnyRole", policy =>
			//	policy.RequireRole("Admin", "Manager", "User"));
		});
	}
}

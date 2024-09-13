namespace DietPreparation.Web.Configurations;

internal static class ApplicationExtensions
{
	public static void CustomUse(this WebApplication app)
	{
		app.Use(async (context, next) =>
		{
			await next();

			if (context.Response.StatusCode == 404)
			{
				context.Request.Path = $"/Error/{context.Response.StatusCode}";
				await next();
			}
		});
	}
}
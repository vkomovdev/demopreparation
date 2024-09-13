using DietPreparation.Common.Configurations;
using DietPreparation.Common.Consts;
using DietPreparation.Common.Extensions;
using DietPreparation.Utilities.Logger;
using DietPreparation.Web.Configurations;
using DietPreparation.Web.Utilities;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Negotiate;
using System.Globalization;

CultureInfo.DefaultThreadCurrentCulture = CurrentCulture.Culture;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services
	.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
	.AddNegotiate();

builder.Services.AddPolicy();

builder.WebHost.UseConfiguration(new ConfigurationBuilder()
	.AddCommandLine(args)
	.Build());

builder.WebHost.UseContentRoot(Directory.GetCurrentDirectory());
builder.WebHost.ConfigureAppConfiguration();
builder.WebHost.UseStaticWebAssets();

builder.Services.AddSingleton<ViewRenderer>();
builder.Services.AddControllersWithViews();

builder.Services.AddCustomOptions(builder.Configuration);

builder.Services.AddModules();
builder.Services.RegisterDietPreparationLoggingProvider<Program>(builder.Configuration);
builder.Services.InstallServices(builder.Configuration, AppDomain.CurrentDomain.GetAssemblies());

builder.Services.MapperRegister(typeof(Program).Assembly);
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

WebApplication app = builder.Build();

if (app.Environment.IsNonProduction())
{
	app.UseHsts();
}

app.CustomUse();
app.UseStatusCodePagesWithReExecute("/Error/{0}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseMiddleware<AuthorizationMiddleware>();

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "CloseDetails",
		pattern: "pwo/close-details/{requestId:int}/{sequence:int}",
		defaults: new { controller = "pwo", action = "close-details" }
	);

	endpoints.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
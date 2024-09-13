using DietPreparation.ServicesApi.Configurations;
using DietPreparation.Utilities.Logger;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseConfiguration(new ConfigurationBuilder().AddCommandLine(args).Build());
builder.WebHost.UseContentRoot(Directory.GetCurrentDirectory());
builder.WebHost.ConfigureAppConfiguration();

builder.Services.AddControllers();

builder.Services.AddCustomOptions(builder.Configuration);
builder.Services.AddCustomSwagger(builder.Configuration.GetSection("BuildVersion").Value);

builder.Services.AddModules();
builder.Services.RegisterDietPreparationLoggingProvider<Program>(builder.Configuration);
builder.Services.InstallServices(builder.Configuration, AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddHttpClient();
builder.Services.AddCustomCors(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseRouting();
app.UseCors(builder.Configuration.GetSection("CorsPolicyOptions:PolicyName").Value);

app.UseAuthorization();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();

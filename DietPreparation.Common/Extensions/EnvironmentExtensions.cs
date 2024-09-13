using DietPreparation.Common.Consts;
using Microsoft.Extensions.Hosting;

namespace DietPreparation.Common.Extensions;

public static class EnvironmentExtensions
{
	public static bool IsNonProduction(this IHostEnvironment hostEnvironment) =>
		hostEnvironment.EnvironmentName == DietPreparationEnvironments.Local ||
		hostEnvironment.EnvironmentName == DietPreparationEnvironments.Development ||
		hostEnvironment.EnvironmentName == DietPreparationEnvironments.Testing ||
		hostEnvironment.EnvironmentName == DietPreparationEnvironments.DEV ||
		hostEnvironment.EnvironmentName == DietPreparationEnvironments.STG ||
		hostEnvironment.EnvironmentName == DietPreparationEnvironments.QA ||
		hostEnvironment.EnvironmentName == DietPreparationEnvironments.UAT ||
		hostEnvironment.EnvironmentName == DietPreparationEnvironments.ZoetrisDevelopment ||
		hostEnvironment.EnvironmentName == DietPreparationEnvironments.ZoetrisTesting;
}

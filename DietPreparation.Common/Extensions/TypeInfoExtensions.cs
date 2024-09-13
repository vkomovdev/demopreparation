using System.Reflection;

namespace DietPreparation.Common.Extensions;

public static class TypeInfoExtensions
{
	public static bool IsAssignableToType<T>(TypeInfo typeInfo) =>
		typeof(T).IsAssignableFrom(typeInfo) &&
		!typeInfo.IsInterface &&
		!typeInfo.IsAbstract;
}

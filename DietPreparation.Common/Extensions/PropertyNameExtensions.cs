using System.Linq.Expressions;

namespace DietPreparation.Common.Extensions;

public static class PropertyNameExtensions
{
	public static string GetFullName<T, TProperty>(this T _, Expression<Func<T, TProperty>> property)
	{
		return $"{typeof(T).Name}.{((MemberExpression)property.Body).Member.Name}";
	}

	public static string GetName<T, TProperty>(this T _, Expression<Func<T, TProperty>> property)
	{
		return ((MemberExpression)property.Body).Member.Name;
	}
}
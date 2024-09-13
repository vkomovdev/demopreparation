namespace DietPreparation.Common.Extensions;

public static class EnumerableExtensions
{
	public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
	{
		foreach (T item in enumeration)
		{
			action(item);
		}
	}

	public static IEnumerable<T> IntersectByNonDistinct<T, U>(this IEnumerable<T> first, IEnumerable<U> second, Func<T, U> keySelector)
	{
		if (first == null) throw new ArgumentNullException(nameof(first));
		if (second == null) throw new ArgumentNullException(nameof(second));
		if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

		return first
			.GroupJoin(second, keySelector, key => key, (element, group) => new { Element = element, Group = group })
			.Where(pair => pair.Group.Any())
			.Select(pair => pair.Element);
	}
}

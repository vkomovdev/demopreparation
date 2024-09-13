namespace DietPreparation.Common.Extensions;

public static class ListExtensions
{
	public static IList<T> AddRange<T>(this IList<T> items, IEnumerable<T> itemsToAdd)
	{
		if (itemsToAdd is not null)
		{
			itemsToAdd.ForEach(items.Add);
		}

		return items;
	}
}

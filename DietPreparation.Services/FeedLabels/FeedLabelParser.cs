using DietPreparation.Services.FeedLabels.Interfaces;

namespace DietPreparation.Services.FeedLabels;

internal class FeedLabelParser : IFeedLabelParser
{
	public IEnumerable<int> ParsePageNumbers(string? input)
	{
		if (input is null)
		{
			yield break;
		}

		foreach (var item in input.Split(','))
		{
			if (int.TryParse(item, out var num))
			{
				yield return num;
				continue;
			}

			var subs = item.Split('-');

			if (subs.Length <= 1 ||
				!int.TryParse(subs[0], out var start) ||
				!int.TryParse(subs[1], out var end) ||
				end < start)
			{
				continue;
			}

			foreach (var i in Enumerable.Range(start, end - start + 1))
			{
				yield return i;
			}
		}
	}
}
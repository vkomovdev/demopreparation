using DietPreparation.Services.FeedLabels;

namespace DietPreparation.Tests.Services;

[TestFixture]
public class FeedLabelParserTests
{
	private static readonly object[] PageNumbersTestCases =
	{
		new object[] { "1,3,5-12,4", new List<int> { 1, 3, 5, 6, 7, 8, 9, 10, 11, 12, 4 } },
		new object[] { "1-3,2-5", new List<int> { 1, 2, 3, 2, 3, 4, 5 } },
		new object[] { "1,2,3,0", new List<int> { 1, 2, 3, 0 } },
		new object[] { "1", new List<int> { 1 } },
		new object[] { string.Empty, new List<int> { } },
		new object?[] { null, new List<int> { } }
	};

	[Test]
	[TestCaseSource(nameof(PageNumbersTestCases))]
	public void Parse_PageNumbersString_ReturnsExpectedPageNumbersEnumerable(string? input, List<int> expected)
	{
		// Arrange
		var feedLabelParser = new FeedLabelParser();

		// Assert
		var result = feedLabelParser.ParsePageNumbers(input);

		// Assert
		Assert.That(result.SequenceEqual(expected), Is.True);
	}
}
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Services.FeedLabels.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;

namespace DietPreparation.Services.FeedLabels;

internal class FeedLabelPrinter : IFeedLabelPrinter
{
	private readonly IDietPreparationLogger _logger;

	public FeedLabelPrinter(IDietPreparationLogger logger)
	{
		_logger = logger;
	}

	public async Task PrintAsync(string? content, string? fileName, string? printerDirectory)
	{
		if (string.IsNullOrWhiteSpace(content) || string.IsNullOrWhiteSpace(fileName) || string.IsNullOrWhiteSpace(printerDirectory))
		{
			throw new DietPreparationException(CommonErrorCode.ArgumentNullException);
		}

		var fullPath = Path.Combine(printerDirectory, fileName);

		try
		{
			Directory.CreateDirectory(printerDirectory);
			await using var stream = new StreamWriter(fullPath);
			await stream.WriteLineAsync(content);
		}
		catch (UnauthorizedAccessException ex)
		{
			_logger.Error($"Insufficient permissions to access the print directory: '{printerDirectory}' or print file: '{fileName}'", ex);
			throw new DietPreparationException(FeedLabelErrorCode.PrintAccessDenied, ex);
		}
		catch (IOException ex)
		{
			_logger.Error($"An error occurred while writing to the print file: '{fullPath}'", ex);
			throw new DietPreparationException(FeedLabelErrorCode.PrintIOException, ex);
		}
	}
}
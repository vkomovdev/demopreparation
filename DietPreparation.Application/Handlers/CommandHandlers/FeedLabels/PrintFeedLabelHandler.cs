using DietPreparation.Application.Commands.Requests.FeedLabels;
using DietPreparation.Application.Commands.Responses.FeedLabels;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Models.DTO.FeedLabels;
using DietPreparation.Services.FeedLabels.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.CommandHandlers.FeedLabels;

internal class PrintFeedLabelHandler : IRequestHandler<PrintFeedLabelRequest, PrintFeedLabelResponse>
{
	private readonly IFeedLabelParser _feedLabelParser;
	private readonly IFeedLabelReader _feedLabelReader;
	private readonly IFeedLabelBuilder _feedLabelBuilder;
	private readonly IFeedLabelPrinter _feedLabelPrinter;
	private readonly IFeedLabelCreator _feedLabelCreator;
	private readonly IDietPreparationLogger _logger;
	private readonly IMapper _mapper;

	public PrintFeedLabelHandler(
		IFeedLabelParser feedLabelParser,
		IFeedLabelReader feedLabelReader, 
		IFeedLabelBuilder feedLabelBuilder, 
		IFeedLabelPrinter feedLabelPrinter,
		IFeedLabelCreator feedLabelCreator,
		IDietPreparationLogger logger,
		IMapper mapper)
	{
		_feedLabelParser = feedLabelParser;
		_feedLabelReader = feedLabelReader;
		_feedLabelBuilder = feedLabelBuilder;
		_feedLabelPrinter = feedLabelPrinter;
		_feedLabelCreator = feedLabelCreator;
		_logger = logger;
		_mapper = mapper;
	}

	public async Task<PrintFeedLabelResponse> Handle(PrintFeedLabelRequest request, CancellationToken cancellationToken)
	{
		try
		{
			var dto = await _feedLabelReader.ReadAsync(request.Id, request.Sequence);
			var bagNumbers = _feedLabelParser.ParsePageNumbers(request.BagNumbers).ToArray();

			if (!bagNumbers.Any() || bagNumbers.Any(number => number < 1))
			{
				return _mapper.Map<PrintFeedLabelResponse>(new DietPreparationException(FeedLabelErrorCode.ParseBagNumbersException));
			}

			if (request is { NeedPrintBagNumbers: false } && bagNumbers is { Length: 1 })
			{
				bagNumbers = Enumerable.Range(1, bagNumbers.First()).ToArray();
			}

			var printDto = new PrintFeedLabelDto();
			_mapper.Map(dto, printDto);
			_mapper.Map(request, printDto);

			var zpls = bagNumbers.Select(bagNumber => new PrintZplBaseResponse.Zpl()
			{
				Content = _feedLabelBuilder.GenerateZpl(printDto, bagNumber),
				FileName = $"{printDto.LotNumber}-{bagNumber}.{request.ZplExtension}"
			});

			if (request is { NeedOnlyDownload: false, NeedPrintBagNumbers: false } && bagNumbers is { Length: 1 })
			{
				printDto.Quantity = bagNumbers.First();
				await _feedLabelCreator.CreateAsync(printDto);
			}

			if (request is { NeedOnlyDownload: true } or { NeedPrintLabels: false })
			{
				return _mapper.Map<PrintFeedLabelResponse>(zpls);
			}

			foreach (var zpl in zpls)
			{
				await _feedLabelPrinter.PrintAsync(zpl.Content, zpl.FileName, request.PrinterDirectory);
			}

			return _mapper.Map<PrintFeedLabelResponse>(zpls);
		}
		catch (DietPreparationException exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<PrintFeedLabelResponse>(exception);
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<PrintFeedLabelResponse>(new DietPreparationException(FeedLabelErrorCode.PrintException));
		}
	}
}
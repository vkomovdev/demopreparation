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

internal class PrintFeedLabelAdditiveHandler : IRequestHandler<PrintFeedLabelAdditiveRequest, PrintFeedLabelAdditiveResponse>
{
	private readonly IFeedLabelBuilder _feedLabelBuilder;
	private readonly IFeedLabelPrinter _feedLabelPrinter;
	private readonly IDietPreparationLogger _logger;
	private readonly IMapper _mapper;
	
	public PrintFeedLabelAdditiveHandler(
		IFeedLabelBuilder feedLabelBuilder,
		IFeedLabelPrinter feedLabelPrinter,
		IDietPreparationLogger logger,
		IMapper mapper)
	{
		_feedLabelBuilder = feedLabelBuilder;
		_feedLabelPrinter = feedLabelPrinter;
		_logger = logger;
		_mapper = mapper;
	}

	public async Task<PrintFeedLabelAdditiveResponse> Handle(PrintFeedLabelAdditiveRequest request, CancellationToken cancellationToken)
	{
		try
		{
			var printDto = _mapper.Map<PrintFeedLabelAdditiveDto>(request);
			var bagNumbers = Enumerable.Range(1, request.NumberOfCopies).ToArray();
			var generatedZpl = _feedLabelBuilder.GenerateZpl(printDto);

			var zpls = bagNumbers.Select(bagNumber => new PrintZplBaseResponse.Zpl()
			{
				Content = generatedZpl,
				FileName = $"{printDto.LotNumber}-{bagNumber}.{request.ZplExtension}"
			});

			if (request is { NeedOnlyDownload: true })
			{
				return _mapper.Map<PrintFeedLabelAdditiveResponse>(zpls);
			}

			foreach (var zpl in zpls)
			{
				await _feedLabelPrinter.PrintAsync(zpl.Content, zpl.FileName, request.PrinterDirectory);
			}

			return _mapper.Map<PrintFeedLabelAdditiveResponse>(zpls);
		}
		catch (DietPreparationException exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<PrintFeedLabelAdditiveResponse>(exception);
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<PrintFeedLabelAdditiveResponse>(new DietPreparationException(FeedLabelErrorCode.PrintException));
		}
	}
}
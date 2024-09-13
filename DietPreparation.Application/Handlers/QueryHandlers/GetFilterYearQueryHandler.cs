using DietPreparation.Application.Queries.Requests;
using DietPreparation.Application.Queries.Responses;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Services.FilterYear;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.QueryHandlers;

internal class GetFilterYearQueryHandler : IRequestHandler<GetFilterYearQueryRequest, GetFilterYearQueryResponse>
{
	private readonly IFilterYearReader _filterYearReader;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public GetFilterYearQueryHandler(IFilterYearReader filterYearReader, IMapper mapper, IDietPreparationLogger logger)
	{
		_filterYearReader = filterYearReader;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<GetFilterYearQueryResponse> Handle(GetFilterYearQueryRequest request, CancellationToken cancellationToken)
	{
		try
		{
			var model = await _filterYearReader.ReadAsync();
			return _mapper.Map<GetFilterYearQueryResponse>(model);
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<GetFilterYearQueryResponse>(new DietPreparationException(CommonErrorCode.EntityNotFound));
		}
	}
}

using DietPreparation.Application.Queries.Requests.Drugs;
using DietPreparation.Application.Queries.Responses.Drugs;
using DietPreparation.Services.Drugs.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.QueryHandlers.Drugs;

public class GetFilteredDrugsQueryHandler : IRequestHandler<GetFilteredDrugsQueryRequest, GetFilteredDrugsQueryResponse>
{
	private readonly IDrugFilter _drugFilter;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public GetFilteredDrugsQueryHandler(IDrugFilter drugFilter, IMapper mapper, IDietPreparationLogger logger)
	{
		_drugFilter = drugFilter;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<GetFilteredDrugsQueryResponse> Handle(GetFilteredDrugsQueryRequest request, CancellationToken cancellationToken)
	{
		try
		{
			if (request.Pagination is null)
			{
				throw new DietPreparationException(CommonErrorCode.ArgumentNullException);
			}

			var drugs = await _drugFilter.SortLimitedAsync(request.OrderBy, request.Pagination)
				?? throw new DietPreparationException(CommonErrorCode.EntityNotFound);

			var response = _mapper.Map<GetFilteredDrugsQueryResponse>(request.Pagination);

			_mapper.Map(drugs, response);
			return response;
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<GetFilteredDrugsQueryResponse>(new DietPreparationException(CommonErrorCode.UnhandledException));
		}
	}
}
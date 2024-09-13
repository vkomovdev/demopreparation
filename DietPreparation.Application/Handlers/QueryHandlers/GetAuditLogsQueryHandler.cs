using DietPreparation.Application.Queries.Requests;
using DietPreparation.Application.Queries.Responses;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Services.AuditLogs;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.QueryHandlers;

internal class GetAuditLogsQueryHandler : IRequestHandler<GetAuditLogsQueryRequest, GetAuditLogsQueryResponse>
{
	private readonly IAuditFilter _auditFilter;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public GetAuditLogsQueryHandler(IAuditFilter auditFilter, IMapper mapper, IDietPreparationLogger logger)
	{
		_auditFilter = auditFilter;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<GetAuditLogsQueryResponse> Handle(GetAuditLogsQueryRequest request, CancellationToken cancellationToken)
	{
		try
		{
			var result = await _auditFilter.FilterSortedAsync(request.FilterBy, request.OrderBy, request.Pagination);
			var response = _mapper.Map<GetAuditLogsQueryResponse>(request.Pagination);
			_mapper.Map(result, response);
			return response;
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<GetAuditLogsQueryResponse>(new DietPreparationException(AuditErrorCode.ReadException));
		}
	}
}

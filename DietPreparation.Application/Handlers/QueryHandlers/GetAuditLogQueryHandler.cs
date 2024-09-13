using DietPreparation.Application.Queries.Requests;
using DietPreparation.Application.Queries.Responses;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Services.AuditLogs;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.QueryHandlers;

internal class GetAuditLogQueryHandler : IRequestHandler<GetAuditLogQueryRequest, GetAuditLogQueryResponse>
{
	private readonly IAuditReader _auditReader;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public GetAuditLogQueryHandler(IAuditReader auditReader, IMapper mapper, IDietPreparationLogger logger)
	{
		_auditReader = auditReader;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<GetAuditLogQueryResponse> Handle(GetAuditLogQueryRequest request, CancellationToken cancellationToken)
	{
		try
		{
			var result = await _auditReader.ReadAsync(request.Id);
			return _mapper.Map<GetAuditLogQueryResponse>(result);
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<GetAuditLogQueryResponse>(new DietPreparationException(AuditErrorCode.ReadException));
		}
	}
}

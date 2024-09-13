using DietPreparation.Application.Queries.Responses;
using DietPreparation.Models.DTO.AuditLogs;
using DietPreparation.Utilities.ExceptionHandler;
using Mapster;

namespace DietPreparation.Application.MappingConfigurations;

internal class AuditMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<IEnumerable<AuditItemDto>, GetAuditLogsQueryResponse>()
			.Map(dest => dest.AuditLogs, src => src)
			.Map(dest => dest.TotalItems, src => (src != null && src.Count() > 0) ? src.First().TotalItems : 0);

		config.NewConfig<DietPreparationException, GetAuditLogsQueryResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<AuditDto, GetAuditLogQueryResponse>()
			.Map(dest => dest.AuditLog, src => src);

		config.NewConfig<DietPreparationException, GetAuditLogQueryResponse>()
			.Map(dest => dest.Exception, src => src);
	}
}
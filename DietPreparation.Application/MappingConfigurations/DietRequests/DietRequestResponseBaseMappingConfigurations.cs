using DietPreparation.Application.Commands.Responses.DietRequests;
using DietPreparation.Application.Common.Responses;
using DietPreparation.Application.Queries.Responses.DietRequests;
using DietPreparation.Models.DTO;
using Mapster;

namespace DietPreparation.Application.MappingConfigurations.DietRequests;

internal class DietRequestResponseBaseMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<DietRequestDto, BaseDietRequestResponse>()
			.Include<DietRequestDto, CloneDietRequestResponse>()
			.Include<DietRequestDto, GetDietRequestQueryResponse>()
			.Include<DietRequestDto, CreateDietRequestResponse>()
			.Include<DietRequestDto, UpdateDietRequestResponse>()
			.Map(dest => dest.Requester, src => src.Requestor)
			.Map(dest => dest.Receiver, src => src.Receiver)
			.Map(dest => dest.Location, src => src.Location)
			.Map(dest => dest.DeliveryNotice, src => src.DeliveryNotice)
			.Map(dest => dest.DateRequest, src => src.DateRequest)
			.Map(dest => dest.DateNeeded, src => src.DateNeeded)
			.Map(dest => dest.LotNumber, src => $"{src.LotYear}-{src.LotId}")
			.Map(dest => dest.ProtocolNumber, src => src.ProtocolNumber)
			.Map(dest => dest.StudyNumber, src => src.StudyNumber)
			.Map(dest => dest.StudyType, src => src.StudyType)
			.Map(dest => dest.ProjectNumber, src => src.ProjectNumber)
			.Map(dest => dest.IntendedUse, src => src.IntendedUse)
			.Map(dest => dest.RequestType, src => src.RequestType)
			.Map(dest => dest.FeedType, src => src.FeedType)
			.Map(dest => dest.BasalDiet, src => src.BasalDiet)
			.Map(dest => dest.FeedSupplierName, src => src.FeedSupplierName)
			.Map(dest => dest.FeedSupplierLotNumber, src => src.FeedSupplierLotNumber)
			.Map(dest => dest.RequestAmount, src => src.RequestAmount)
			.Map(dest => dest.UnitOfMeasure, src => src.UnitOfMeasure)
			.Map(dest => dest.Form, src => src.Form)
			.Map(dest => dest.ControlledSubstance, src => src.ControlledSubstance)
			.Map(dest => dest.ToxicHazard, src => src.ToxicHazard)
			.Map(dest => dest.HazardCode, src => src.HazardCode)
			.Map(dest => dest.PackagingInstructions, src => src.PackagingInstructions)
			.Map(dest => dest.MixingInstructions, src => src.MixingInstructions)
			.Map(dest => dest.Premixes, src => src.Premixes)
			.Map(dest => dest.Drugs, src => src.Drugs)
			.Map(dest => dest.Samples, src => src.Samples)
			.Map(dest => dest.GeneralComment, src => src.GeneralComments)
			.Map(dest => dest.IsDeleted, src => src.IsDeleted)
			.Map(dest => dest.IsLocked, src => src.IsLocked);
	}
}
using DietPreparation.Application.Commands.Requests.DietRequests;
using DietPreparation.Models.DTO;
using Mapster;

namespace DietPreparation.Application.MappingConfigurations.DietRequests;

internal class PopulateDietRequestMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<CreateDietRequestRequest, DietRequestDto>()
			.Map(dest => dest.RequestorId, src => src.RequestorId)
			.Map(dest => dest.RecieverId, src => src.ReceiverId)
			.Map(dest => dest.LocationId, src => src.LocationId)
			.Map(dest => dest.DeliveryNotice, src => src.DeliveryNotice)
			.Map(dest => dest.DateRequest, src => src.DateRequest)
			.Map(dest => dest.DateNeeded, src => src.DateNeeded)
			.Map(dest => dest.StudyNumber, src => src.StudyNumber)
			.Map(dest => dest.StudyType, src => src.StudyType)
			.Map(dest => dest.ProjectNumber, src => src.ProjectNumber)
			.Map(dest => dest.IntendedUse, src => src.IntendedUse)
			.Map(dest => dest.RequestType, src => src.RequestType)
			.Map(dest => dest.FeedType, src => src.FeedType)
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
			.Map(dest => dest.GeneralComments, src => src.GeneralComments)
			.Map(dest => dest.HasDrugs, src => src.HasDrugs)
			.Map(dest => dest.HasPremixes, src => src.HasPremixes)
			.Map(dest => dest.HasSamples, src => src.HasSamples);
	}
}
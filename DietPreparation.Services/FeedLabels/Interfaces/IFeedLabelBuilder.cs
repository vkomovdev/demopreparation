using DietPreparation.Models.DTO.FeedLabels;

namespace DietPreparation.Services.FeedLabels.Interfaces;

public interface IFeedLabelBuilder
{
	string GenerateZpl(PrintFeedLabelDto dto, int bagNumber);
	string GenerateZpl(PrintFeedLabelAdditiveDto dto);
}
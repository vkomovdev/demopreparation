using DietPreparation.Models.DTO.FeedLabels;

namespace DietPreparation.Services.FeedLabels.Interfaces;

public interface IFeedLabelReader
{
	Task<FeedLabelDto> ReadAsync(int requestId, int sequence);
}
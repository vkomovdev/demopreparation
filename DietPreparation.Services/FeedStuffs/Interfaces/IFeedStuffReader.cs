using DietPreparation.Models.DTO;
using DietPreparation.Services.Common.Interfaces;

namespace DietPreparation.Services.FeedStuffs.Interfaces;

public interface IFeedStuffReader : IRead<string, FeedStuffDto?>, IReadAll<FeedStuffDto>
{
}
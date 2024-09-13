using DietPreparation.Filter.Interfaces;
using DietPreparation.Filter.Options;
using DietPreparation.Models.DTO;
using DietPreparation.Models.DTO.FilterOptions;

namespace DietPreparation.Services.FeedStuffs.Interfaces;

public interface IFeedStuffFilter :
	ISort<FeedStuffDto, IOrderBy>,
	IFilterSorted<FeedStuffPlanningDto, FeedStuffPlanningFilterDto, IOrderBy, IPagination>
{
}
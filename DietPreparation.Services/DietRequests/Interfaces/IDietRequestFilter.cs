using DietPreparation.Filter.Interfaces;
using DietPreparation.Filter.Options;
using DietPreparation.Models.DTO;
using DietPreparation.Models.DTO.DietRequests;
using DietPreparation.Models.DTO.FilterOptions;
using DietPreparation.Models.DTO.TableOptions;

namespace DietPreparation.Services.DietRequests.Interfaces;

public interface IDietRequestFilter :
	IFilterSorted<DietRequestDto, FeedLabelFilterDto, IOrderBy, IPagination>,
	IFilterSorted<DietRequestDto, PwoFilterDto, IOrderBy, IPagination>,
	IFilterSorted<DietRequestDto, PwoTypeFilterDto, IOrderBy, IPagination>,
	IFilterSorted<DietRequestSearchDto, DietRequestFilterDto, IOrderBy, IPagination>,
	IFilter<DietRequestTinyDto, DietRequestTinyFilterDto>
{
}
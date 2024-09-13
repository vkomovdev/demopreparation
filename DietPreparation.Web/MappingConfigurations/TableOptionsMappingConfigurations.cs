using DietPreparation.Common.Consts;
using DietPreparation.Common.Extensions;
using DietPreparation.Models.DTO;
using DietPreparation.Models.DTO.AuditLogs;
using DietPreparation.Models.DTO.DietRequests;
using DietPreparation.Models.DTO.FilterOptions;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Web.Models;
using DietPreparation.Web.Models.AuditLogs;
using DietPreparation.Web.Models.BasalDiets.List;
using DietPreparation.Web.Models.Customers;
using DietPreparation.Web.Models.DeliveryLocations;
using DietPreparation.Web.Models.DietRequests;
using DietPreparation.Web.Models.Drugs;
using DietPreparation.Web.Models.FeedLabels;
using DietPreparation.Web.Models.FeedStuffs;
using DietPreparation.Web.Models.PWOs;
using DietPreparation.Web.Models.TableOptions;
using DietPreparation.Web.Models.Users;
using Mapster;

namespace DietPreparation.Web.MappingConfigurations;

internal class TableOptionsMappingConfigurations : IRegister
{
	private static readonly IDictionary<string, string> OrderByDictionary = new Dictionary<string, string>();

	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<OrderByViewModel, OrderByDto>()
			.Map(dest => dest.Column, src => TranslateColumn(src.Column!))
			.Map(dest => dest.Slope, src => (src.Slope ?? DefaultStrings.Asc).ToUpper());

		config.NewConfig<FeedStuffFilteredTable, FeedStuffPlanningFilterDto>()
			.Map(dest => dest.DateStart, src => src.DateStart)
			.Map(dest => dest.DateEnd, src => src.DateEnd)
			.Map(dest => dest.IngredientId, src => src.IngredientId);

		config.NewConfig<PaginationViewModel, PaginationDto>()
			.Map(dest => dest.Page, src => src.Page)
			.Map(dest => dest.PageSize, src => src.PageSize)
			.Map(dest => dest.TotalItems, src => src.TotalItems);
	}

	static TableOptionsMappingConfigurations()
	{
		RegisterUserDictionary(OrderByDictionary);
		RegisterFeedStuffDictionary(OrderByDictionary);
		RegisterPwoSearchDictionary(OrderByDictionary);
		RegisterDietRequestListDictionary(OrderByDictionary);
		RegisterFeedLabelsDictionary(OrderByDictionary);
		RegisterDrugRequestDictionary(OrderByDictionary);
		RegisterFeedStuffPlanningDictionary(OrderByDictionary);
		RegisterCustomerDictionary(OrderByDictionary);
		RegisterBasalDietsDictionary(OrderByDictionary);
		RegisterLocationsDictionary(OrderByDictionary);
		RegisterAuditLogsDictionary(OrderByDictionary);
	}

	private static string TranslateColumn(string key)
	{
		if (string.IsNullOrEmpty(key))
			return string.Empty;
		return OrderByDictionary.TryGetValue(key, out var value) ? value
			: throw new DietPreparationException(CommonErrorCode.NotImplementedOrderByException, key);
	}

	private static void RegisterUserDictionary(IDictionary<string, string> dictionary)
	{
		var viewModel = new UserViewModel();
		var dto = new UserDto();

		dictionary.Add(viewModel.GetFullName(x => x.UserId), dto.GetFullName(x => x.UserId));
		dictionary.Add(viewModel.GetFullName(x => x.FirstName), dto.GetFullName(x => x.FirstName));
		dictionary.Add(viewModel.GetFullName(x => x.MiddleName), dto.GetFullName(x => x.MiddleName));
		dictionary.Add(viewModel.GetFullName(x => x.LastName), dto.GetFullName(x => x.LastName));
		dictionary.Add(viewModel.GetFullName(x => x.Email), dto.GetFullName(x => x.Email));
		dictionary.Add(viewModel.GetFullName(x => x.AccessType), dto.GetFullName(x => x.AccessType));
	}

	private static void RegisterFeedStuffDictionary(IDictionary<string, string> dictionary)
	{
		var viewModel = new FeedStuffViewModel();
		var dto = new FeedStuffDto();

		dictionary.Add(viewModel.GetFullName(x => x.Name), dto.GetFullName(x => x.Name));
		dictionary.Add(viewModel.GetFullName(x => x.Id), dto.GetFullName(x => x.Id));
	}

	private static void RegisterFeedStuffPlanningDictionary(IDictionary<string, string> dictionary)
	{
		var viewModel = new FeedStuffPlanningRowItem();
		var dto = new FeedStuffPlanningDto();

		dictionary.Add(viewModel.GetFullName(x => x.Name), dto.GetFullName(x => x.Name));
		dictionary.Add(viewModel.GetFullName(x => x.Amount), dto.GetFullName(x => x.Amount));
		dictionary.Add(viewModel.GetFullName(x => x.UnitOfMeasure), dto.GetFullName(x => x.UnitOfMeasure));
	}

	private static void RegisterPwoSearchDictionary(IDictionary<string, string> dictionary)
	{
		var viewModel = new PwoSearchRowItem();
		var dto = new DietRequestDto();

		dictionary.Add(viewModel.GetFullName(x => x.Lot), dto.GetFullName(x => x.Lot));
		dictionary.Add(viewModel.GetFullName(x => x.Requestor), dto.GetFullName(x => x.Requestor));
		dictionary.Add(viewModel.GetFullName(x => x.DateRequest), dto.GetFullName(x => x.DateRequest));
		dictionary.Add(viewModel.GetFullName(x => x.DietName), dto.GetFullName(x => x.Name));
		dictionary.Add(viewModel.GetFullName(x => x.RequestAmount), dto.GetFullName(x => x.RequestAmount));
		dictionary.Add(viewModel.GetFullName(x => x.UnitOfMeasure), dto.GetFullName(x => x.UnitOfMeasure));
	}

	private static void RegisterDietRequestListDictionary(IDictionary<string, string> dictionary)
	{
		var viewModel = new DietRequestSearchItem();
		var dto = new DietRequestSearchDto();

		dictionary.Add(viewModel.GetFullName(x => x.Id), dto.GetFullName(x => x.Id));
		dictionary.Add(viewModel.GetFullName(x => x.Lot), dto.GetFullName(x => x.Lot));
		dictionary.Add(viewModel.GetFullName(x => x.Requestor), dto.GetFullName(x => x.Requestor));
		dictionary.Add(viewModel.GetFullName(x => x.Receiver), dto.GetFullName(x => x.Receiver));
		dictionary.Add(viewModel.GetFullName(x => x.DateRequest), dto.GetFullName(x => x.DateRequest));
		dictionary.Add(viewModel.GetFullName(x => x.DateNeeded), dto.GetFullName(x => x.DateNeeded));
		dictionary.Add(viewModel.GetFullName(x => x.Name), dto.GetFullName(x => x.Name));
		dictionary.Add(viewModel.GetFullName(x => x.RequestAmount), dto.GetFullName(x => x.RequestAmount));
		dictionary.Add(viewModel.GetFullName(x => x.UnitOfMeasure), dto.GetFullName(x => x.UnitOfMeasure));
	}

	private static void RegisterFeedLabelsDictionary(IDictionary<string, string> dictionary)
	{
		var viewModel = new FeedLabelListItemViewModel();
		var dto = new DietRequestDto();

		dictionary.Add(viewModel.GetFullName(x => x.Lot), dto.GetFullName(x => x.Lot));
		dictionary.Add(viewModel.GetFullName(x => x.Requestor), dto.GetFullName(x => x.Requestor));
		dictionary.Add(viewModel.GetFullName(x => x.DateRequest), dto.GetFullName(x => x.DateRequest));
		dictionary.Add(viewModel.GetFullName(x => x.DietName), dto.GetFullName(x => x.Name));
		dictionary.Add(viewModel.GetFullName(x => x.RequestAmount), dto.GetFullName(x => x.RequestAmount));
		dictionary.Add(viewModel.GetFullName(x => x.UnitOfMeasure), dto.GetFullName(x => x.UnitOfMeasure));
	}

	private static void RegisterDrugRequestDictionary(IDictionary<string, string> dictionary)
	{
		var viewModel = new DrugViewModel();
		var dto = new DrugsItemDto();

		dictionary.Add(viewModel.GetFullName(x => x.Id), dto.GetFullName(x => x.Id));
		dictionary.Add(viewModel.GetFullName(x => x.Name), dto.GetFullName(x => x.Name));
		dictionary.Add(viewModel.GetFullName(x => x.ActiveIngredientConcentration), dto.GetFullName(x => x.ActiveIngredientConcentration));
		dictionary.Add(viewModel.GetFullName(x => x.UnitOfMeasure), dto.GetFullName(x => x.ConcentrationUnitOfMeasure));
		dictionary.Add(viewModel.GetFullName(x => x.CreateDate), dto.GetFullName(x => x.CreateDate));
		dictionary.Add(viewModel.GetFullName(x => x.CreateName), dto.GetFullName(x => x.CreateName));
		dictionary.Add(viewModel.GetFullName(x => x.IsLocked), dto.GetFullName(x => x.IsLocked));
		dictionary.Add(viewModel.GetFullName(x => x.IsActive), dto.GetFullName(x => x.IsActive));
	}

	private static void RegisterCustomerDictionary(IDictionary<string, string> dictionary)
	{
		var viewModel = new CustomerViewModel();
		var dto = new CustomerDto();

		dictionary.Add(viewModel.GetFullName(x => x.Id), dto.GetFullName(x => x.Id));
		dictionary.Add(viewModel.GetFullName(x => x.FirstName), dto.GetFullName(x => x.FirstName));
		dictionary.Add(viewModel.GetFullName(x => x.MiddleName), dto.GetFullName(x => x.MiddleName));
		dictionary.Add(viewModel.GetFullName(x => x.LastName), dto.GetFullName(x => x.LastName));
		dictionary.Add(viewModel.GetFullName(x => x.Email), dto.GetFullName(x => x.Email));
		dictionary.Add(viewModel.GetFullName(x => x.CustomerType), dto.GetFullName(x => x.Type));
		dictionary.Add(viewModel.GetFullName(x => x.Building), dto.GetFullName(x => x.Building));
		dictionary.Add(viewModel.GetFullName(x => x.BusinessUnit), dto.GetFullName(x => x.BusinessUnit));
	}

	private static void RegisterBasalDietsDictionary(IDictionary<string, string> dictionary)
	{
		var viewModel = new BasalDietListItemViewModel();
		var dto = new BasalDietDto();

		dictionary.Add(viewModel.GetFullName(x => x.Id), dto.GetFullName(x => x.Id));
		dictionary.Add(viewModel.GetFullName(x => x.Code), dto.GetFullName(x => x.Code));
		dictionary.Add(viewModel.GetFullName(x => x.Name), dto.GetFullName(x => x.Name));
	}

	private static void RegisterLocationsDictionary(IDictionary<string, string> dictionary)
	{
		var viewModel = new DeliveryLocationViewModel();
		var dto = new LocationDto();

		dictionary.Add(viewModel.GetFullName(x => x.Id), dto.GetFullName(x => x.Id));
		dictionary.Add(viewModel.GetFullName(x => x.Description), dto.GetFullName(x => x.Description));
		dictionary.Add(viewModel.GetFullName(x => x.Building), dto.GetFullName(x => x.Building));
		dictionary.Add(viewModel.GetFullName(x => x.Floor), dto.GetFullName(x => x.Floor));
		dictionary.Add(viewModel.GetFullName(x => x.Lab), dto.GetFullName(x => x.Lab));
		dictionary.Add(viewModel.GetFullName(x => x.BusinessUnit), dto.GetFullName(x => x.BusinessUnit));
		dictionary.Add(viewModel.GetFullName(x => x.IsLocked), dto.GetFullName(x => x.IsLocked));
	}

	private static void RegisterAuditLogsDictionary(IDictionary<string, string> dictionary)
	{
		var viewModel = new AuditLogViewModel();
		var dto = new AuditItemDto();

		dictionary.Add(viewModel.GetFullName(x => x.Id), dto.GetFullName(x => x.Id));
		dictionary.Add(viewModel.GetFullName(x => x.ChangeType), dto.GetFullName(x => x.ChangeType));
		dictionary.Add(viewModel.GetFullName(x => x.ChangeTimestamp), dto.GetFullName(x => x.ChangeTimestamp));
		dictionary.Add(viewModel.GetFullName(x => x.LotYear), dto.GetFullName(x => x.LotYear));
		dictionary.Add(viewModel.GetFullName(x => x.LotId), dto.GetFullName(x => x.LotId));
		dictionary.Add(viewModel.GetFullName(x => x.DietName), dto.GetFullName(x => x.DietName));
	}
}
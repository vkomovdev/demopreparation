using DietPreparation.Common.Consts;
using DietPreparation.Common.Extensions;
using DietPreparation.Models.DAO;
using DietPreparation.Models.DAO.AuditLogs;
using DietPreparation.Models.DAO.FilterOptions;
using DietPreparation.Models.DTO;
using DietPreparation.Models.DTO.AuditLogs;
using DietPreparation.Models.DTO.BasalDiets;
using DietPreparation.Models.DTO.DietRequests;
using DietPreparation.Models.DTO.FilterOptions;
using DietPreparation.Models.DTO.TableOptions;
using DietPreparation.Utilities.ExceptionHandler;
using Mapster;

namespace DietPreparation.Services.MappingConfigurations;

internal class TableOptionsMappingConfigurations : IRegister
{
	private static readonly IDictionary<string, IEnumerable<string>> OrderByDictionary = new Dictionary<string, IEnumerable<string>>();

	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<OrderByDto, OrderByDao>()
			.Map(dest => dest.ORDER_BY, src => MapOrderBy(src.Column!, src.Slope!));

		config.NewConfig<BaseDietRequestFilterDto, BaseDietRequestFilterDao>()
			.Map(dest => dest.LotYear, src => src.LotYear)
			.Map(dest => dest.LotNumber, src => src.LotNumber)
			.Map(dest => dest.LotId, src => src.LotId)
			.Map(dest => dest.Requestor, src => src.Requestor)
			.Map(dest => dest.DietName, src => src.DietName);

		config.NewConfig<FeedStuffPlanningFilterDto, FeedStuffFilterDao>()
			.Map(dest => dest.DateStart, src => src.DateStart)
			.Map(dest => dest.DateEnd, src => src.DateEnd)
			.Map(dest => dest.IngredientId, src => src.IngredientId);

		config.NewConfig<PaginationDto, PaginationDao>()
			.Map(dest => dest.Page, src => src.Page)
			.Map(dest => dest.PageSize, src => src.PageSize)
			.Map(dest => dest.TotalItems, src => src.TotalItems);

		config.NewConfig<DietRequestFilterDto, DietRequestFilterDao>()
			.Map(dest => dest.Options, src => src.Filter);

		config.NewConfig<DietRequestTinyFilterDto, DietRequestTinyFilterDao>()
			.Map(dest => dest.PreMixUsed, src => src.PremixUsed)
			.Map(dest => dest.UsedAsTemplate, src => src.UsedAsTemplate.HasValue
				? (src.UsedAsTemplate.Value ? DefaultStrings.Yes : DefaultStrings.No)
				: null)
			.Map(dest => dest.REQUEST_TYPE, src => src.RequestType != null ? src.RequestType.GetDatabaseValue() : null);

		config.NewConfig<PwoFilterDto, PwoFilterDao>()
			.Map(dest => dest.Filter, src => src.Filter);

		config.NewConfig<FeedLabelFilterDto, FeedLabelFilterDao>()
			.Map(dest => dest.Type, src => src.Type);

		config.NewConfig<BasalDietIngredientFilterDto, BasalDietIngredientFilterDao>()
			.Map(dest => dest.BasalDietId, src => src.BasalDietId);

		config.NewConfig<BasalDietFilterDto, BasalDietFilterDao>()
			.Map(dest => dest.Code, src => src.Code)
			.Map(dest => dest.Name, src => src.Name);

		config.NewConfig<AuditFilterDto, AuditFilterDao>();
	}

	static TableOptionsMappingConfigurations()
	{
		RegisterUserDictionary(OrderByDictionary);
		RegisterFeedStuffDictionary(OrderByDictionary);
		RegisterDietRequestDictionary(OrderByDictionary);
		RegisterDietRequestLiteDictionary(OrderByDictionary);
		RegisterDrugRequestDictionary(OrderByDictionary);
		RegisterFeedStuffPlanningDictionary(OrderByDictionary);
		RegisterCustomerDictionary(OrderByDictionary);
		RegisterBasalDietsDictionary(OrderByDictionary);
		RegisterLocationsDictionary(OrderByDictionary);
		RegisterAuditLogsDictionary(OrderByDictionary);
	}

	private static string MapOrderBy(string column, string slope)
	{
		if (string.IsNullOrEmpty(column))
			return string.Empty;

		var translatedColumn = OrderByDictionary.TryGetValue(column, out var value) ? value
			: throw new DietPreparationException(CommonErrorCode.NotImplementedOrderByException, column);

		return string.Join(", ", translatedColumn.Select(item => item + $" {slope}"));
	}

	private static void RegisterUserDictionary(IDictionary<string, IEnumerable<string>> dictionary)
	{
		var dto = new UserDto();
		var dao = new UserDao();

		dictionary.Add(dto.GetFullName(x => x.UserId), new[] { dao.GetName(x => x.UserID) });
		dictionary.Add(dto.GetFullName(x => x.FirstName), new[] { dao.GetName(x => x.FirstName) });
		dictionary.Add(dto.GetFullName(x => x.MiddleName), new[] { dao.GetName(x => x.MiddleName) });
		dictionary.Add(dto.GetFullName(x => x.LastName), new[] { dao.GetName(x => x.LastName) });
		dictionary.Add(dto.GetFullName(x => x.Email), new[] { dao.GetName(x => x.EmailAddress) });
		dictionary.Add(dto.GetFullName(x => x.AccessType), new[] { dao.GetName(x => x.accessKey) });
	}

	private static void RegisterFeedStuffDictionary(IDictionary<string, IEnumerable<string>> dictionary)
	{
		var dto = new FeedStuffDto();
		var dao = new FeedStuffDao();

		dictionary.Add(dto.GetFullName(x => x.Name), new[] { dao.GetName(x => x.INGREDIENT_NAME) });
	}

	private static void RegisterFeedStuffPlanningDictionary(IDictionary<string, IEnumerable<string>> dictionary)
	{
		var dto = new FeedStuffPlanningDto();
		var dao = new FeedStuffReportDao();

		dictionary.Add(dto.GetFullName(x => x.Id), new[] { dao.GetName(x => x.Ingredient_ID) });
		dictionary.Add(dto.GetFullName(x => x.Name), new[] { dao.GetName(x => x.Ingredient_Name) });
		dictionary.Add(dto.GetFullName(x => x.Amount), new[] { dao.GetName(x => x.Amount) });
		dictionary.Add(dto.GetFullName(x => x.UnitOfMeasure), new[] { dao.GetName(x => x.Amount_UoM) });
	}

	private static void RegisterDietRequestDictionary(IDictionary<string, IEnumerable<string>> dictionary)
	{
		var dto = new DietRequestDto();
		var dao = new DietRequestDao();

		dictionary.Add(dto.GetFullName(x => x.Lot), new[] { dao.GetName(x => x.LOT_YEAR), dao.GetName(x => x.LOT_ID) });
		dictionary.Add(dto.GetFullName(x => x.Requestor), new[] { dao.GetName(x => x.REQUESTOR) });
		dictionary.Add(dto.GetFullName(x => x.DateRequest), new[] { dao.GetName(x => x.DATE_REQUEST) });
		dictionary.Add(dto.GetFullName(x => x.Name), new[] { dao.GetName(x => x.DIET_NAME) });
		dictionary.Add(dto.GetFullName(x => x.RequestAmount), new[] { dao.GetName(x => x.REQUEST_AMOUNT) });
		dictionary.Add(dto.GetFullName(x => x.UnitOfMeasure), new[] { dao.GetName(x => x.REQUEST_UOM) });
	}

	private static void RegisterDietRequestLiteDictionary(IDictionary<string, IEnumerable<string>> dictionary)
	{
		var dto = new DietRequestSearchDto();
		var dao = new DietRequestDao();

		dictionary.Add(dto.GetFullName(x => x.Lot), new[] { dao.GetName(x => x.LOT) });
		dictionary.Add(dto.GetFullName(x => x.Requestor), new[] { dao.GetName(x => x.REQUESTOR) });
		dictionary.Add(dto.GetFullName(x => x.Receiver), new[] { dao.GetName(x => x.RECEIVER) });
		dictionary.Add(dto.GetFullName(x => x.DateRequest), new[] { dao.GetName(x => x.DATE_REQUEST) });
		dictionary.Add(dto.GetFullName(x => x.DateNeeded), new[] { dao.GetName(x => x.DATE_NEEDED) });
		dictionary.Add(dto.GetFullName(x => x.Name), new[] { dao.GetName(x => x.DIET_NAME) });
		dictionary.Add(dto.GetFullName(x => x.RequestAmount), new[] { dao.GetName(x => x.REQUEST_AMOUNT) });
		dictionary.Add(dto.GetFullName(x => x.UnitOfMeasure), new[] { dao.GetName(x => x.REQUEST_UOM) });
	}

	private static void RegisterDrugRequestDictionary(IDictionary<string, IEnumerable<string>> dictionary)
	{
		var dto = new DrugsItemDto();
		var dao = new DrugsItemDao();

		dictionary.Add(dto.GetFullName(x => x.Id), new[] { dao.GetName(x => x.DRUG_ID) });
		dictionary.Add(dto.GetFullName(x => x.Name), new[] { dao.GetName(x => x.DRUG_NAME) });
		dictionary.Add(dto.GetFullName(x => x.ActiveIngredientConcentration), new[] { dao.GetName(x => x.ACTIVE_INGREDIENT_CONC) });
		dictionary.Add(dto.GetFullName(x => x.ConcentrationUnitOfMeasure), new[] { dao.GetName(x => x.ACTIVE_UOM) });
		dictionary.Add(dto.GetFullName(x => x.CreateDate), new[] { dao.GetName(x => x.CREATE_DATE) });
		dictionary.Add(dto.GetFullName(x => x.CreateName), new[] { dao.GetName(x => x.CREATE_NAME) });
		dictionary.Add(dto.GetFullName(x => x.IsLocked), new[] { dao.GetName(x => x.LOCK) });
	}

	private static void RegisterCustomerDictionary(IDictionary<string, IEnumerable<string>> dictionary)
	{
		var dto = new CustomerDto();
		var dao = new CustomerDao();

		dictionary.Add(dto.GetFullName(x => x.Id), new[] { dao.GetName(x => x.CUSTOMER_ID) });
		dictionary.Add(dto.GetFullName(x => x.FirstName), new[] { dao.GetName(x => x.FIRST_NAME) });
		dictionary.Add(dto.GetFullName(x => x.MiddleName), new[] { dao.GetName(x => x.MIDDLE_INITIAL) });
		dictionary.Add(dto.GetFullName(x => x.LastName), new[] { dao.GetName(x => x.LAST_NAME) });
		dictionary.Add(dto.GetFullName(x => x.Email), new[] { dao.GetName(x => x.EMAIL) });
		dictionary.Add(dto.GetFullName(x => x.Type), new[] { dao.GetName(x => x.CUSTOMER_TYPE) });
		dictionary.Add(dto.GetFullName(x => x.Building), new[] { dao.GetName(x => x.BUILDING) });
		dictionary.Add(dto.GetFullName(x => x.BusinessUnit), new[] { dao.GetName(x => x.UNIT) });
	}

	private static void RegisterBasalDietsDictionary(IDictionary<string, IEnumerable<string>> dictionary)
	{
		var dto = new BasalDietDto();
		var dao = new BasalDietDao();

		dictionary.Add(dto.GetFullName(x => x.Id), new[] { dao.GetName(x => x.BASAL_DIET_ID) });
		dictionary.Add(dto.GetFullName(x => x.Code), new[] { dao.GetName(x => x.BASAL_DIET_CODE) });
		dictionary.Add(dto.GetFullName(x => x.Name), new[] { dao.GetName(x => x.BASAL_DIET_NAME) });
	}

	private static void RegisterLocationsDictionary(IDictionary<string, IEnumerable<string>> dictionary)
	{
		var dto = new LocationDto();
		var dao = new LocationDao();

		dictionary.Add(dto.GetFullName(x => x.Id), new[] { dao.GetName(x => x.LOCATION_ID) });
		dictionary.Add(dto.GetFullName(x => x.Description), new[] { dao.GetName(x => x.DELIVER_DESCRIPTION) });
		dictionary.Add(dto.GetFullName(x => x.Building), new[] { dao.GetName(x => x.DELIVER_BUILDING) });
		dictionary.Add(dto.GetFullName(x => x.Floor), new[] { dao.GetName(x => x.DELIVER_FLOOR) });
		dictionary.Add(dto.GetFullName(x => x.Lab), new[] { dao.GetName(x => x.DELIVER_LAB) });
		dictionary.Add(dto.GetFullName(x => x.BusinessUnit), new[] { dao.GetName(x => x.BUSINESS_UNIT_NUMBER) });
		dictionary.Add(dto.GetFullName(x => x.IsLocked), new[] { dao.GetName(x => x.LOCK) });
	}

	private static void RegisterAuditLogsDictionary(IDictionary<string, IEnumerable<string>> dictionary)
	{
		var dto = new AuditItemDto();
		var dao = new AuditItemDao();

		dictionary.Add(dto.GetFullName(x => x.Id), new[] { dao.GetName(x => x.AuditLogNumber) });
		dictionary.Add(dto.GetFullName(x => x.ChangeType), new[] { dao.GetName(x => x.CHANGE_TYPE) });
		dictionary.Add(dto.GetFullName(x => x.ChangeTimestamp), new[] { dao.GetName(x => x.CHANGE_TIMESTAMP) });
		dictionary.Add(dto.GetFullName(x => x.LotYear), new[] { dao.GetName(x => x.LOT_YEAR) });
		dictionary.Add(dto.GetFullName(x => x.LotId), new[] { dao.GetName(x => x.LOT_ID) });
		dictionary.Add(dto.GetFullName(x => x.DietName), new[] { dao.GetName(x => x.DIET_NAME) });
	}
}
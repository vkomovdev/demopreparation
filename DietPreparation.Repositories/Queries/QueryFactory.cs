namespace DietPreparation.Repositories.Queries;
public class QueryFactory : QueryFactoryBase
{
	public async Task<string> BuildReadCustomersQuery() => await BuildQuery("ReadCustomers");

	public async Task<string> BuildReadLocationsQuery() => await BuildQuery("ReadLocations");

	public async Task<string> BuildReadDrugsQuery() => await BuildQuery("ReadDrugs");

	public async Task<string> BuildReadPremixesQuery() => await BuildQuery("ReadDietRequestPreMix");

	public async Task<string> BuildReadBasalDietQuery() => await BuildQuery("ReadBasalDiet");

	public async Task<string> BuildGetPaginatedDrugListQuery() => await BuildQuery("SelectPaginatedDrugList");

	public async Task<string> BuildGetPaginatedLocationListQuery() => await BuildQuery("SelectPaginatedLocationList");

	public async Task<string> BuildGetFilteredLocationListQuery() => await BuildQuery("FilterLocationList");

	public async Task<string> BuildCustomerSelectQuery() => await BuildQuery("ReadCustomerSelect");

	public async Task<string> BuildAuditSelectQuery() => await BuildQuery("ReadAuditSelect");
}
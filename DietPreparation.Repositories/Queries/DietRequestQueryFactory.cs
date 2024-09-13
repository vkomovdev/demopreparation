namespace DietPreparation.Repositories.Queries;

public class DietRequestQueryFactory : QueryFactoryBase
{
	public async Task<string> BuildReadDietRequestQuery() => await BuildQuery("ReadDietRequest");
	public async Task<string> BuildPwoSearchQuery() => await BuildQuery("PwoSearch");
	public async Task<string> BuildSearchForPwoInitiateQuery() => await BuildQuery("SearchForPwoInitiate");
	public async Task<string> BuildSearchDietRequestsQuery() => await BuildQuery("SearchDietRequests");
	public async Task<string> BuildSearchForPwoCloseQuery() => await BuildQuery("SearchForPwoClose");
	public async Task<string> BuildSearchForFeedLabelQuery() => await BuildQuery("SearchForFeedLabel");
	public async Task<string> BuildSearchForDietRequestQuery() => await BuildQuery("SearchForDietRequest");
	public async Task<string> BuildSearchForDietRequestsTinyQuery() => await BuildQuery("SearchForDietRequestsTiny");
	public async Task<string> BuildSearchForBasalDietsQuery() => await BuildQuery("SearchForBasalDiets");
	public async Task<string> BuildFilterBasalDietsQuery() => await BuildQuery("FilterBasalDiets");
}
using DietPreparation.Models.DAO;
using DietPreparation.Models.DAO.FilterOptions;
using DietPreparation.Repositories.Common.Interfaces;

namespace DietPreparation.Repositories.Spaces.Interfaces;

public interface IFeedStuffRepository : IReadRecord<string, FeedStuffDao?>, IReadAllRecord<FeedStuffDao>, IUpsertRecord<CreateUpdateFeedStuffDao, CreateUpdateFeedStuffDao>
{
	Task LabelPrintConfirmAsync(string iPWO_ID, string bit);

	ValueTask<IEnumerable<FeedStuffDao>> ReadAllAsync(OrderByDao orderBy);
}

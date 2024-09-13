using DietPreparation.Common.Extensions;
using DietPreparation.Data.UnitOfWork;
using DietPreparation.Models.DAO;
using DietPreparation.Repositories.Spaces.Interfaces;

namespace DietPreparation.Repositories.Spaces;

internal class FeedLabelRepository : IFeedLabelRepository
{
	private const string CreateFeedLabelStoredProcedure = "DPS_FEED_LABEL_IU";

	private readonly IUnitOfWork _unitOfWork;

	public FeedLabelRepository(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<PrintFeedLabelDao> UpdateAsync(PrintFeedLabelDao dao)
	{
		var cmd = $"{CreateFeedLabelStoredProcedure} {dao.PWO_ID}, {dao.EXPIRES.ToSqlValue()}, {dao.COMMENT1.ToSqlValue()}, {dao.COMMENT2.ToSqlValue()}, {dao.QUANTITY}";
		await _unitOfWork.ExecuteAsync(cmd);
		return dao;
	}
}
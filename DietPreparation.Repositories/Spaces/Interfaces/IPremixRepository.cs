using DietPreparation.Models.DAO;
using DietPreparation.Repositories.Common.Interfaces;

namespace DietPreparation.Repositories.Spaces.Interfaces;
public interface IPremixRepository : IReadAllRecord<PwoPremixDao>
{
	Task AuditPreMixUpdate(string iAuditLogNumber,
								string sPreMix,
								string sPreMixAmount,
								string sPreMixUOM,
								string sPreMixWeightYN);
	Task UpdatePreMixUsed(string sRequest);
	Task UpdatePreMixActive(string sRequest);
	ValueTask<IEnumerable<PremixDao>> ReadPremixes(int requestId);
	ValueTask<bool> IsPremixLockedAsync(int premixId);
}

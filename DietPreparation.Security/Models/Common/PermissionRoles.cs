using DietPreparation.Common.Enums;
using DietPreparation.Common.Extensions;

namespace DietPreparation.Security.Models.Common;
internal static class PermissionRoles
{
	public static Dictionary<string, string[]> Roles = new Dictionary<string, string[]>()
	{
		{ AccessType.Admin.GetDisplayName(),new string[] {
			Permissions.Basic.View,
			Permissions.Libraries.View,

			Permissions.DietRequests.View,
			Permissions.DietRequests.Create,
			Permissions.DietRequests.Update,
			Permissions.DietRequests.Repeat,
			Permissions.DietRequests.Delete,
			Permissions.DietRequests.Print,
			Permissions.DietRequests.Activate,

			Permissions.ProcessWorkOrders.View,
			Permissions.ProcessWorkOrders.Create,
			Permissions.ProcessWorkOrders.PrePrint,

			Permissions.Batches.View,
			Permissions.Batches.Close,
			Permissions.Batches.Print,

			Permissions.FeedLabels.View,
			Permissions.FeedLabels.Print,

			Permissions.DrugLabels.View,
			Permissions.DrugLabels.Print,

			Permissions.FeedStuffPlanning.View,

			Permissions.Users.View,
			Permissions.Users.Create,
			Permissions.Users.Update,

			Permissions.Customers.View,
			Permissions.Customers.Create,
			Permissions.Customers.Update,

			Permissions.Locations.View,
			Permissions.Locations.Create,
			Permissions.Locations.Update,

			Permissions.Drugs.View,
			Permissions.Drugs.Create,
			Permissions.Drugs.Update,
			Permissions.Drugs.Activate,

			Permissions.BasalDiets.View,
			Permissions.BasalDiets.Create,
			Permissions.BasalDiets.Update,
			Permissions.BasalDiets.Activate,
			Permissions.BasalDiets.Print,

			Permissions.FeedStuffs.View,
			Permissions.FeedStuffs.Create,
			Permissions.FeedStuffs.Update,

			Permissions.Administration.View,
			Permissions.Administration.AuditLogView,
			Permissions.Administration.AuditLogView,
			Permissions.Administration.YearFiltering

		}
		},
		{ AccessType.OrderOnly.GetDisplayName(),new string[] {
			Permissions.Basic.View,
			Permissions.Libraries.View,
			Permissions.DietRequests.View,
			Permissions.DietRequests.Create,
			Permissions.DietRequests.Update,
			Permissions.DietRequests.Repeat,
			Permissions.DietRequests.Print,

			Permissions.ProcessWorkOrders.View,

			Permissions.Batches.View,
			Permissions.Batches.Print,

			Permissions.FeedLabels.View,
			Permissions.FeedLabels.Print,

			Permissions.DrugLabels.View,
			Permissions.DrugLabels.Print,

			Permissions.Users.View,

			Permissions.Customers.View,

			Permissions.Locations.View,

			Permissions.Drugs.View,

			Permissions.BasalDiets.View,
			Permissions.BasalDiets.Print,

			Permissions.FeedStuffs.View
		}
		},
		{ AccessType.User.GetDisplayName(),new string[] {
			Permissions.Basic.View,
			Permissions.Libraries.View,
			Permissions.DietRequests.View,
			Permissions.DietRequests.Create,
			Permissions.DietRequests.Update,
			Permissions.DietRequests.Repeat,
			Permissions.DietRequests.Delete,
			Permissions.DietRequests.Print,

			Permissions.ProcessWorkOrders.View,
			Permissions.ProcessWorkOrders.Create,
			Permissions.ProcessWorkOrders.PrePrint,

			Permissions.Batches.View,
			Permissions.Batches.Close,
			Permissions.Batches.Print,

			Permissions.FeedLabels.View,
			Permissions.FeedLabels.Print,

			Permissions.DrugLabels.View,
			Permissions.DrugLabels.Print,

			Permissions.Users.View,

			Permissions.Customers.View,

			Permissions.Locations.View,

			Permissions.Drugs.View,

			Permissions.BasalDiets.View,
			Permissions.BasalDiets.Print,

			Permissions.FeedStuffs.View} },
		{ AccessType.Disabled.GetDisplayName(),new string[] {
			Permissions.Basic.View,
		}
		}
	};
}

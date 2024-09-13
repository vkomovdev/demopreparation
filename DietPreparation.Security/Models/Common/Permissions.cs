namespace DietPreparation.Security.Models.Common;

public static class Permissions
{
	private const string CommonPrefix = "Permission.";

	public static class DietRequests
	{
		private const string DietRequestsPrefix = $"{CommonPrefix}{nameof(DietRequests)}.";

		public const string View = $"{DietRequestsPrefix}{nameof(View)}";
		public const string Create = $"{DietRequestsPrefix}{nameof(Create)}";
		public const string Update = $"{DietRequestsPrefix}{nameof(Update)}";
		public const string Repeat = $"{DietRequestsPrefix}{nameof(Repeat)}";
		public const string Delete = $"{DietRequestsPrefix}{nameof(Delete)}";
		public const string Print = $"{DietRequestsPrefix}{nameof(Print)}";
		public const string Activate = $"{DietRequestsPrefix}{nameof(Activate)}";

	}

	public static class ProcessWorkOrders
	{
		private const string PWOsPrefix = $"{CommonPrefix}{nameof(ProcessWorkOrders)}.";

		public const string View = $"{PWOsPrefix}{nameof(View)}";
		public const string Create = $"{PWOsPrefix}{nameof(Create)}";
		public const string PrePrint = $"{PWOsPrefix}{nameof(PrePrint)}";
	}

	public static class Batches
	{
		private const string BatchesPrefix = $"{CommonPrefix}{nameof(Batches)}.";

		public const string View = $"{BatchesPrefix}{nameof(View)}";
		public const string Close = $"{BatchesPrefix}{nameof(Close)}";
		public const string Print = $"{BatchesPrefix}{nameof(Print)}";
	}

	public static class FeedLabels
	{
		private const string FeedLabelsPrefix = $"{CommonPrefix}{nameof(FeedLabels)}.";

		public const string View = $"{FeedLabelsPrefix}{nameof(View)}";
		public const string Print = $"{FeedLabelsPrefix}{nameof(Print)}";
	}

	public static class DrugLabels
	{
		private const string DrugLabelsPrefix = $"{CommonPrefix}{nameof(DrugLabels)}.";

		public const string View = $"{DrugLabelsPrefix}{nameof(View)}";
		public const string Print = $"{DrugLabelsPrefix}{nameof(Print)}";
	}

	public static class FeedStuffPlanning
	{
		private const string FeedStuffPlanningPrefix = $"{CommonPrefix}{nameof(FeedStuffPlanning)}.";

		public const string View = $"{FeedStuffPlanningPrefix}{nameof(View)}";
	}

	public static class Users
	{
		private const string UsersPrefix = $"{CommonPrefix}{nameof(Users)}.";

		public const string View = $"{UsersPrefix}{nameof(View)}";
		public const string Create = $"{UsersPrefix}{nameof(Create)}";
		public const string Update = $"{UsersPrefix}{nameof(Update)}";
	}

	public static class Customers
	{
		private const string CustomersPrefix = $"{CommonPrefix}{nameof(Customers)}.";

		public const string View = $"{CustomersPrefix}{nameof(View)}";
		public const string Create = $"{CustomersPrefix}{nameof(Create)}";
		public const string Update = $"{CustomersPrefix}{nameof(Update)}";
	}

	public static class Locations
	{
		private const string LocationsPrefix = $"{CommonPrefix}{nameof(Locations)}.";

		public const string View = $"{LocationsPrefix}{nameof(View)}";
		public const string Create = $"{LocationsPrefix}{nameof(Create)}";
		public const string Update = $"{LocationsPrefix}{nameof(Update)}";
	}

	public static class Drugs
	{
		private const string DrugsPrefix = $"{CommonPrefix}{nameof(Drugs)}.";

		public const string View = $"{DrugsPrefix}{nameof(View)}";
		public const string Create = $"{DrugsPrefix}{nameof(Create)}";
		public const string Update = $"{DrugsPrefix}{nameof(Update)}";
		public const string Activate = $"{DrugsPrefix}{nameof(Activate)}";
	}

	public static class BasalDiets
	{
		private const string BasalDietsPrefix = $"{CommonPrefix}{nameof(BasalDiets)}.";

		public const string View = $"{BasalDietsPrefix}{nameof(View)}";
		public const string Create = $"{BasalDietsPrefix}{nameof(Create)}";
		public const string Update = $"{BasalDietsPrefix}{nameof(Update)}";
		public const string Activate = $"{BasalDietsPrefix}{nameof(Activate)}";
		public const string Print = $"{BasalDietsPrefix}{nameof(Print)}";
	}

	public static class FeedStuffs
	{
		private const string FeedStuffsPrefix = $"{CommonPrefix}{nameof(FeedStuffs)}.";

		public const string View = $"{FeedStuffsPrefix}{nameof(View)}";
		public const string Create = $"{FeedStuffsPrefix}{nameof(Create)}";
		public const string Update = $"{FeedStuffsPrefix}{nameof(Update)}";
	}

	public static class Administration
	{
		private const string AdminPrefix = $"{CommonPrefix}{nameof(Administration)}.";

		public const string View = $"{AdminPrefix}{nameof(View)}";
		public const string AuditLogView = $"{AdminPrefix}{nameof(AuditLogView)}";
		public const string AuditLogDetail = $"{AdminPrefix}{nameof(AuditLogDetail)}";
		public const string YearFiltering = $"{AdminPrefix}{nameof(YearFiltering)}";
	}

	public static class Libraries
	{
		private const string BasicPrefix = $"{CommonPrefix}{nameof(Libraries)}.";

		public const string View = $"{BasicPrefix}{nameof(View)}";
	}

	public static class Basic
	{
		private const string BasicPrefix = $"{CommonPrefix}{nameof(Basic)}.";

		public const string View = $"{BasicPrefix}{nameof(View)}";
	}
}

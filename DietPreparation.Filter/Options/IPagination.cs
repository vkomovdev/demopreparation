namespace DietPreparation.Filter.Options;
public interface IPagination
{
	public int Page { get; set; }
	public int PageSize { get; set; }
	public int TotalItems { get; set; }
}

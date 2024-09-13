namespace DietPreparation.Filter.Options;
public interface IPaginable<T> where T : IPagination
{
	public T Pagination { get; set; }
}

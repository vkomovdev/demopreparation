namespace DietPreparation.Filter.Options;
public interface IOrderable<T> where T : IOrderBy
{
	public T OrderBy { get; set; }
}

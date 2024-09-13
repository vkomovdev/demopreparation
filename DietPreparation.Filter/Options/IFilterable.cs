namespace DietPreparation.Filter.Options;
public interface IFilterable<T> where T : IFilterBy
{
	public T FilterBy { get; set; }
}

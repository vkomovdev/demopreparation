namespace DietPreparation.Filter.Options;
public interface IOrderBy
{
	public string? Column { get; set; }
	public string? Slope { get; set; }
}
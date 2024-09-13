namespace DietPreparation.Common.Attributes;
public class DatabaseValueAttribute : Attribute
{
	public DatabaseValueAttribute(string value)
	{
		Value = value;
	}

	public string Value { get; }
}

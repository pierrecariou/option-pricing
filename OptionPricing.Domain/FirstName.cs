namespace OptionPricing.Domain;

public class FirstName
{
	public string Value {get; private set;}

	public FirstName(string Value)
	{
		if (String.IsNullOrEmpty(Value))
			throw new Exception("First name must be set");
		this.Value = Value;
	}
}

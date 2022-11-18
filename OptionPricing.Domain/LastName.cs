namespace OptionPricing.Domain;

public class LastName
{
	public string Value {get; private set;}

	public LastName(string Value)
	{
		if (String.IsNullOrEmpty(Value))
			throw new Exception("Last name must be set");
		this.Value = Value;
	}
}

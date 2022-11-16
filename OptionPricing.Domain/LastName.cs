namespace OptionPricing.Domain;

public class LastName
{
	public string Value {get; private set;}

	public LastName(string lastName)
	{
		if (String.IsNullOrEmpty(lastName))
			throw new Exception("Last name must be set");
		Value = lastName;
	}
}

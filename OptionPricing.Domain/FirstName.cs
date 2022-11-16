namespace OptionPricing.Domain;

public class FirstName
{
	public string Value {get; private set;}

	public FirstName(string firstName)
	{
		if (String.IsNullOrEmpty(firstName))
			throw new Exception("First name must be set");
		Value = firstName;
	}
}

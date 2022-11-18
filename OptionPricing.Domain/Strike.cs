// File              : Strike.cs
// Author            : Pierre Cariou <pierrecariou@outlook.fr>
// Date              : 08.11.2022
// Last Modified Date: 08.11.2022
// Last Modified By  : Pierre Cariou <pierrecariou@outlook.fr>

namespace OptionPricing.Domain;

public class Strike
{
	public float Value { get; private set; }

	public Strike(float Value)
	{
		//Console.WriteLine("Hello  " + Value);
		if (Value <= 0)
			throw new Exception("Strike can't negative or equal to 0");
		this.Value = Value;
	}
}

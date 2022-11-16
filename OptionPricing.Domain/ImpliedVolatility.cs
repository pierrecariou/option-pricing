// File              : ImpliedVolatility.cs
// Author            : Pierre Cariou <pierrecariou@outlook.fr>
// Date              : 08.11.2022
// Last Modified Date: 08.11.2022
// Last Modified By  : Pierre Cariou <pierrecariou@outlook.fr>

namespace OptionPricing.Domain;

public class ImpliedVolatility
{
	public float Value { get; private set; }

	public ImpliedVolatility(float impliedVolatility)
	{
		if (impliedVolatility < 0)
			throw new Exception("Implied volatility can't be negative");
		Value = impliedVolatility;
	}
}

// File              : RiskFreeRate.cs
// Author            : Pierre Cariou <pierrecariou@outlook.fr>
// Date              : 08.11.2022
// Last Modified Date: 08.11.2022
// Last Modified By  : Pierre Cariou <pierrecariou@outlook.fr>

namespace OptionPricing.Domain;

public class RiskFreeRate
{
	public float Value { get; private set; }

	public RiskFreeRate(float Value)
	{
		if (Value < 0)
			throw new Exception("Risk free rate can't be negative");
		this.Value = this.Value;
	}
}

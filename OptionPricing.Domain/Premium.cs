// File              : Premium.cs
// Author            : Pierre Cariou <pierrecariou@outlook.fr>
// Date              : 08.11.2022
// Last Modified Date: 08.11.2022
// Last Modified By  : Pierre Cariou <pierrecariou@outlook.fr>

namespace OptionPricing.Domain;

public class Premium
{
	public float Value {get; private set;}

	public Premium(float premium)
	{
		if (premium > 10000)
			throw new Exception("premium is not valid");
		Value = premium;
	}
}

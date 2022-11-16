// File              : Maturity.cs
// Author            : Pierre Cariou <pierrecariou@outlook.fr>
// Date              : 08.11.2022
// Last Modified Date: 08.11.2022
// Last Modified By  : Pierre Cariou <pierrecariou@outlook.fr>

namespace OptionPricing.Domain;

public class Maturity
{
	public DateTime Value {get; private set;}

	public Maturity(DateTime maturity) {
		if (maturity <= DateTime.Today)
			throw new Exception("Maturity should be later than today");
		Value = maturity;
	}

}

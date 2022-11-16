// File              : PricingDate.cs
// Author            : Pierre Cariou <pierrecariou@outlook.fr>
// Date              : 08.11.2022
// Last Modified Date: 08.11.2022
// Last Modified By  : Pierre Cariou <pierrecariou@outlook.fr>

namespace OptionPricing.Domain;

public class PricingDate
{
	public DateTime Value {get; private set;}

	public PricingDate(DateTime dateTime)
	{
		if (dateTime > DateTime.Today)
			throw new Exception("pricing date is not valid");
		Value = dateTime;
	}
}

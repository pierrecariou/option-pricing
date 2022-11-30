// File              : HJMPricingService.cs
// Author            : Pierre Cariou <pierrecariou@outlook.fr>
// Date              : 14.11.2022
// Last Modified Date: 14.11.2022
// Last Modified By  : Pierre Cariou <pierrecariou@outlook.fr>

namespace OptionPricing.Domain.Service;

public class HJM : IPricingService
{
	public double Price(Pricing price)
	{
		return 100;
	}
}

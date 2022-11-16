// File              : IPricingService.cs
// Author            : Pierre Cariou <pierrecariou@outlook.fr>
// Date              : 14.11.2022
// Last Modified Date: 14.11.2022
// Last Modified By  : Pierre Cariou <pierrecariou@outlook.fr>

namespace OptionPricing.Domain.Service;

public interface IPricingService
{
	double Price(Pricing price);
}

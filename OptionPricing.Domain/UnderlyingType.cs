// File              : UnderlyingType.cs
// Author            : Pierre Cariou <pierrecariou@outlook.fr>
// Date              : 08.11.2022
// Last Modified Date: 08.11.2022
// Last Modified By  : Pierre Cariou <pierrecariou@outlook.fr>

namespace OptionPricing.Domain;

public enum UnderlyingType {
	Unknown,
	Equity,
	Rate,
	Commodity
}

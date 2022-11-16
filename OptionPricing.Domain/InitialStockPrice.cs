// File              : InitialStockPrice.cs
// Author            : Pierre Cariou <pierrecariou@outlook.fr>
// Date              : 07.11.2022
// Last Modified Date: 07.11.2022
// Last Modified By  : Pierre Cariou <pierrecariou@outlook.fr>

namespace OptionPricing.Domain;

public class InitialStockPrice
{
	public float Value { get; private set; }

	public InitialStockPrice(float initialStockPrice)
	{
		if (initialStockPrice < 0)
			throw new Exception("Initial stock price can't be negative");
		Value = initialStockPrice;
	}
}

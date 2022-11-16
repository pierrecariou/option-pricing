// File              : Option.cs
// Author            : Pierre Cariou <pierrecariou@outlook.fr>
// Date              : 08.11.2022
// Last Modified Date: 08.11.2022
// Last Modified By  : Pierre Cariou <pierrecariou@outlook.fr>

namespace OptionPricing.Domain;

public class Option
{
	public Strike Strike {get; private set;}
	public Maturity Maturity {get; private set;}
	public Trader Trader {get; private set;}
	public Underlying Underlying {get; private set;}

	public Option(Strike strike, Maturity maturity, 
			Trader trader, Underlying underlying)
	{
		if (strike == null)
			throw new Exception("strike must be initialized");
		if (maturity == null)
			throw new Exception("maturity must be initialized");
		if (trader == null)
			throw new Exception("trader must be initialized");
		if (underlying == null)
			throw new Exception("underlying must be initialized");
		Strike = strike;
		Maturity = maturity;
		Trader = trader;
		Underlying = underlying;
	}
}

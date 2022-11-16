// File              : Underlying.cs
// Author            : Pierre Cariou <pierrecariou@outlook.fr>
// Date              : 08.11.2022
// Last Modified Date: 08.11.2022
// Last Modified By  : Pierre Cariou <pierrecariou@outlook.fr>

namespace OptionPricing.Domain;

public class Underlying
{
	public	InitialStockPrice InitialStockPrice {get; private set;}
	public	ImpliedVolatility ImpliedVolatility {get; private set;}
	public	RiskFreeRate RiskFreeRate {get; private set;}
	public	UnderlyingType UnderlyingType {get; private set;}

	public Underlying(InitialStockPrice initialStockPrice, ImpliedVolatility impliedVolatility,
			RiskFreeRate riskFreeRate, UnderlyingType underlyingType)
	{
		if (initialStockPrice == null)
			throw new Exception("initial stock price must be initialized");
		if (impliedVolatility == null)
			throw new Exception("implied volatility must be initialized");
		if (riskFreeRate == null)
			throw new Exception("risk free rate must be initialized");
		if (underlyingType == UnderlyingType.Unknown)
			throw new Exception("Underlying type must be set");
		InitialStockPrice = initialStockPrice;
		ImpliedVolatility = impliedVolatility;
		RiskFreeRate = riskFreeRate;
		UnderlyingType = underlyingType;
	}
}

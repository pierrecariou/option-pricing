// File              : OptionRepository.cs
// Author            : Pierre Cariou <pierrecariou@outlook.fr>
// Date              : 09.11.2022
// Last Modified Date: 09.11.2022
// Last Modified By  : Pierre Cariou <pierrecariou@outlook.fr>

namespace OptionPricing.Repository;

using OptionPricing.DAO;
using OptionPricing.Domain;

public interface IOptionRepository
{
	int InsertPricing(Pricing pricing);
	Pricing GetPricingById(int pricingId);
}

public class OptionRepository : IOptionRepository
{
	private readonly IPricingDAO _optionDAO;

	public OptionRepository(IPricingDAO optionDAO)
	{
		_optionDAO = optionDAO;
	}

	public int InsertPricing(Pricing pricing)
	{
		var pricingDTO = new PricingDTO();
		pricingDTO.name = pricing.Option.Trader.Desk.DeskName.Value;
		pricingDTO.lastName = pricing.Option.Trader.LastName.Value;
		pricingDTO.firstName = pricing.Option.Trader.LastName.Value;		
		pricingDTO.initialStockPrice = pricing.Option.Underlying.InitialStockPrice.Value;
		pricingDTO.impliedVolatility = pricing.Option.Underlying.ImpliedVolatility.Value;
		pricingDTO.riskFreeRate = pricing.Option.Underlying.RiskFreeRate.Value;
		pricingDTO.underlyingType = pricing.Option.Underlying.UnderlyingType.ToString();
		pricingDTO.premium = pricing.Premium.Value;
		pricingDTO.model = pricing.Model.ToString();
		pricingDTO.strike = pricing.Option.Strike.Value;
		pricingDTO.maturity = pricing.Option.Maturity.Value;
	
		return _optionDAO.create(pricingDTO);
	}

	public Pricing GetPricingById(int pricingId)
	{
		var pricingDTO = _optionDAO.read(pricingId);

		PricingDate pricingDate = new PricingDate(pricingDTO.dateTime);
		Premium premium = new Premium(pricingDTO.premium);
		Model model = (Model)Enum.Parse(typeof(Model), pricingDTO.model);
		
		DeskName deskName = new DeskName(pricingDTO.name);
		Desk desk = new Desk(deskName);

        Strike 	strike = new Strike(pricingDTO.strike);
		Maturity maturity = new Maturity(pricingDTO.maturity);
		LastName lastName = new LastName(pricingDTO.lastName);
		FirstName firstName = new FirstName(pricingDTO.lastName);
		Trader trader = new Trader(firstName, lastName, desk);

		InitialStockPrice initialStockPrice = new InitialStockPrice(pricingDTO.initialStockPrice);
		ImpliedVolatility impliedVolatility = new ImpliedVolatility(pricingDTO.impliedVolatility);
		RiskFreeRate riskFreeRate = new RiskFreeRate(pricingDTO.riskFreeRate);
		UnderlyingType underlyingType = (UnderlyingType)Enum.Parse(typeof(UnderlyingType), pricingDTO.underlyingType);
		
		Underlying underlying = new Underlying(initialStockPrice, impliedVolatility, riskFreeRate, underlyingType);
		Option option = new Option(strike, maturity, trader, underlying);

		Pricing pricing = new Pricing(pricingDate, premium, option, model);

		return pricing;
	}

}

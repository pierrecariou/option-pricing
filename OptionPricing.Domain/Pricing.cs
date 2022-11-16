// File              : Pricing.cs
// Author            : Pierre Cariou <pierrecariou@outlook.fr>
// Date              : 08.11.2022
// Last Modified Date: 08.11.2022
// Last Modified By  : Pierre Cariou <pierrecariou@outlook.fr>

namespace OptionPricing.Domain;

public class Pricing
{
	public PricingDate PricingDate {get; private set;}
	public Premium Premium {get; set;}
	public Option Option {get; private set;}
	public Model Model {get; private set;}

	public Pricing(PricingDate pricingDate, Option option, Model model)
	{
		if (pricingDate == null)	
			throw new Exception("pricing date must be initialized");
		if (option == null)
			throw new Exception("option must be initialized");
		if (model == Model.Unknown)
			throw new Exception("model must be initialized");
		PricingDate = pricingDate;
		Option = option;
		Model = model;
	}
}

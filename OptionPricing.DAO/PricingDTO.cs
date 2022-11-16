// File              : PricingDTO.cs
// Author            : Pierre Cariou <pierrecariou@outlook.fr>
// Date              : 07.11.2022
// Last Modified Date: 07.11.2022
// Last Modified By  : Pierre Cariou <pierrecariou@outlook.fr>

namespace OptionPricing.DAO;

public class PricingDTO
{
	public DateTime dateTime { get; set; }
	public float premium { get; set; }
	public string model {get; set;}
	public float strike { get; set; }
	public DateTime maturity { get; set; }
	public string lastName { get; set; }
	public string firstName { get; set; }
	public string name { get; set; }
	public float initialStockPrice { get; set; }
	public float impliedVolatility { get; set; }
	public float riskFreeRate { get; set; }
	public string underlyingType { get; set; }
}

// File              : OptionPricingSerializer.cs
// Author            : Pierre Cariou <pierrecariou@outlook.fr>
// Date              : 14.11.2022
// Last Modified Date: 14.11.2022
// Last Modified By  : Pierre Cariou <pierrecariou@outlook.fr>

using System.Text.Json;
//using Newtonsoft.Json;

namespace OptionPricing.Infrastructure;

public interface IOptionPricingSerializer
{
	string Serialize<T>(T myObj);
	T Deserialize<T>(string myString);
}

public class OptionPricingSerializer : IOptionPricingSerializer
{
	public string Serialize<T>(T myObj)
	{
		return JsonSerializer.Serialize<T>(myObj);
//		return JsonConvert.SerializeObject(myObj);
	}

	public T Deserialize<T>(string myString)
	{
		return JsonSerializer.Deserialize<T>(myString);
    //	return JsonConvert.DeserializeObject<T>(myString);
	}
}

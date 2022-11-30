// File              : PricingService.cs
// Author            : Pierre Cariou <pierrecariou@outlook.fr>
// Date              : 14.11.2022
// Last Modified Date: 14.11.2022
// Last Modified By  : Pierre Cariou <pierrecariou@outlook.fr>

using OptionPricing.Repository;
using OptionPricing.Infrastructure;
using OptionPricing.Domain;
using OptionPricing.Domain.Service;

namespace OptionPricing.Service;

public interface IOptionService
{
   string PriceAndPersist(string jsonString, OptionPricingRegistration optionPricingRegistration);
}

public class PricingService : IOptionService
{
    private readonly IOptionRepository _pricingRepository;
    private readonly IOptionPricingSerializer _optionPricingSerialiser;

    public PricingService(IOptionRepository pricingRepo, IOptionPricingSerializer mySerialiser)
    {
        _pricingRepository = pricingRepo;
        _optionPricingSerialiser = mySerialiser;
    }

    public string PriceAndPersist(string jsonString, OptionPricingRegistration optionPricingRegistration)
    {
        Pricing pricing = _optionPricingSerialiser.Deserialize<Pricing>(jsonString);

        // Pricer 
        var pricer = optionPricingRegistration.Resolve<IPricingService>(pricing.Model);
        double price = pricer.Price(pricing);
        pricing.Premium = new Premium((float)price);

        _pricingRepository.InsertPricing(pricing);

        jsonString = _optionPricingSerialiser.Serialize<Pricing>(pricing);

        return jsonString;
    }
}

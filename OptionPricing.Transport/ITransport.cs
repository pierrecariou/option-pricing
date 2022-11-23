using OptionPricing.Domain;

namespace OptionPricing.Transport;

public interface ITransport
{
    Pricing Connect(string host, int port, Pricing pricing);
}

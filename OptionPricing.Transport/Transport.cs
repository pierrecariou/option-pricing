using OptionPricing.Infrastructure;
using OptionPricing.Domain;
using NetMQ;
using NetMQ.Sockets;

namespace OptionPricing.Transport;

public class OptionPricingTransport : ITransport
{
    private readonly IOptionPricingSerializer _optionPricingSerialiser;

    public OptionPricingTransport(IOptionPricingSerializer mySerialiser)
    {
        _optionPricingSerialiser = mySerialiser;
    }

    public Pricing Connect(string host, int port, Pricing pricing)
    {
        using (var requestSocket = new RequestSocket($">tcp://{host}:{port}"))
        {
            var request = _optionPricingSerialiser.Serialize(pricing);

            requestSocket.SendFrame(request);
            var message = requestSocket.ReceiveFrameString();
            pricing = _optionPricingSerialiser.Deserialize<Pricing>(message);
        }
        return pricing;
    }
}

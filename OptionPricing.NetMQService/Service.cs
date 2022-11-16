// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
//
using NetMQ;
using NetMQ.Sockets;
using OptionPricing.DAO;
using OptionPricing.Infrastructure;
using OptionPricing.Repository;
using OptionPricing.Domain.Service;
using OptionPricing.Domain;
using OptionPricing.Service;

var registration = new OptionPricingRegistration();

registration.Register<IPricingDAO, PricingDAO>();
registration.Register<IOptionPricingSerializer, OptionPricingSerializer>();
registration.Register<IOptionRepository, OptionRepository>();

registration.Register<IPricingService, BlackScholes_PricingService>(Model.BlackScholes);
registration.Register<IPricingService, HJM_PricingService>(Model.HJM);

registration.Register<IOptionService, PricingService>();

var optionService = registration.Resolve<IOptionService>();

using(var responseSocket = new ResponseSocket("@tcp://*:5555") )
{
	while (true) {
		var message = responseSocket.ReceiveFrameString();
		Console.WriteLine($"Message Received : {message}");
		var response = optionService.PriceAndPersist(message, registration);

		responseSocket.SendFrame(response);
	}
}

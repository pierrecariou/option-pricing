﻿// See https://aka.ms/new-console-template for more information

using NetMQ;
using NetMQ.Sockets;
using OptionPricing.Infrastructure;
using OptionPricing.Domain;

var Serializer = new OptionPricingSerializer();

using(var requestSocket = new RequestSocket(">tcp://localhost:5555"))
{
    DeskName deskName = new DeskName("DeltaOne");
    Desk desk = new Desk(deskName);
    FirstName firstName = new FirstName("Pierre");
    LastName lastName = new LastName("Cariou");
    Trader trader = new Trader(firstName, lastName, desk);

    InitialStockPrice initialStockPrice = new InitialStockPrice(250f);
    ImpliedVolatility implied_volatility = new ImpliedVolatility(0.4f);
    Maturity maturity = new Maturity(new DateTime(2024, 1, 1) );
    Strike strike = new Strike(255f);
    PricingDate pricingDate = new PricingDate(DateTime.MinValue );
    RiskFreeRate riskFreeRate = new RiskFreeRate(0.02f);

    Premium premium = new Premium(0.29f);
    UnderlyingType underlyingType = UnderlyingType.Commodity;
    Model model = Model.Heston;
    Underlying underlying = new Underlying(initialStockPrice, implied_volatility, riskFreeRate, underlyingType);

    //OptionType optionType = new OptionType("Call");
    Option option = new Option(strike, maturity, trader, underlying);
    Pricing pricing = new Pricing(pricingDate, premium, option, model);

    string request = Serializer.Serialize(pricing);

    Console.WriteLine($"Client sending : {request}");
    requestSocket.SendFrame(request);
    var message = requestSocket.ReceiveFrameString();
    Console.WriteLine($"Message received : {message}");
    Console.ReadLine();
}

namespace OptionPricing.Repository.Test;

using OptionPricing.Repository;
using OptionPricing.Domain;
using OptionPricing.DAO;
using NSubstitute;

public class OptionRepositoryTests
{
    [Fact]
    public void ShouldInsertPricing()
    {
        // 1 - Arrange
        var optionDAO = Substitute.For<IPricingDAO>();
        var optionRepository = new OptionRepository(optionDAO);
        var expectedDTO = CreateDTO();

        optionDAO.create(Arg.Any<PricingDTO>()).Returns(1);

        // 2 - Act
        int ret = optionRepository.InsertPricing(CreatePricing());

        // 3 - Assert
        optionDAO.Received(1).create(expectedDTO);
        Assert.Equal(1, ret);
    }

    public void ShouldGetPricingById()
    {

        // 1 - Arrange
        var optionDAO = Substitute.For<IPricingDAO>();
        var optionRepository = new OptionRepository(optionDAO);
        var expectedPricing = CreatePricing();

        optionDAO.read(Arg.Any<int>()).Returns(CreateDTO());

        // 2 - Act
        var actualPricing = optionRepository.GetPricingById(1);

        // 3 - Assert

        AssertEqualityPricingObjects(expectedPricing, actualPricing);
    }

    private Pricing CreatePricing()
    {
        DeskName deskName = new DeskName("DeltaOne");
        Desk desk = new Desk(deskName);
        FirstName firstName = new FirstName("Pierre");
        LastName lastName = new LastName("Cariou");
        Trader trader = new Trader(firstName, lastName, desk);

        InitialStockPrice initialStockPrice = new InitialStockPrice(250f);
        ImpliedVolatility implied_volatility = new ImpliedVolatility(0.4f);
        Maturity maturity = new Maturity(DateTime.Today);
        Strike strike = new Strike(255);
        PricingDate pricingDate = new PricingDate(DateTime.Today);
        RiskFreeRate riskFreeRate = new RiskFreeRate(0.02f);

        Premium premium = new Premium(1.2f);

        UnderlyingType underlyingType = UnderlyingType.Commodity;
        Model model = Model.BlackScholes;
        Underlying underlying = new Underlying(initialStockPrice, implied_volatility, riskFreeRate, underlyingType);

        Option option = new Option(strike, maturity, trader, underlying);
        Pricing pricing = new Pricing(pricingDate, option, model);
        pricing.Premium = premium;
        return pricing;
    }

    private PricingDTO CreateDTO()
    {
       PricingDTO DTO = new PricingDTO();

        DTO.dateTime = DateTime.Today;
        DTO.premium = 1.2f;
        DTO.model = "BlackSholes";
        DTO.strike = 255;
        DTO.maturity = DateTime.Today;
        DTO.lastName = "Cariou";
        DTO.firstName = "Pierre";
        DTO.name = "DeltaOne";
        DTO.initialStockPrice = 250f;
        DTO.impliedVolatility = 0.4f;
        DTO.riskFreeRate = 0.02f;
        DTO.underlyingType = "Commodity"; 

        return DTO;
    }

    private void AssertEqualityPricingObjects(Pricing expectedPricing, Pricing actual)
    {
        Assert.Equal(expectedPricing.Option.Trader.Desk.DeskName.Value, actual.Option.Trader.Desk.DeskName.Value);
        // ...

    }
}

namespace OptionPricing.Repository.Test;

using NSubstitute;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var optionDAO = Substitute.For<IPricingDAO>();
        var optionRepository = new PricingRepository(optionDAO);

        optionDAO.create(Arg.Any<PricingDTO>()).Returns();
    }
}

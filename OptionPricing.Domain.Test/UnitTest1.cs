// File              : UnitTest1.cs
// Author            : Pierre Cariou <pierrecariou@outlook.fr>
// Date              : 08.11.2022
// Last Modified Date: 08.11.2022
// Last Modified By  : Pierre Cariou <pierrecariou@outlook.fr>

namespace OptionPricing.Domain.Test;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {   
        InitialStockPrice initialStockPrice = new InitialStockPrice(0.2f);
        ImpliedVolatility implied_volatility = new ImpliedVolatility(0.3f);
        RiskFreeRate riskFreeRate = new RiskFreeRate(0.4f);
        UnderlyingType underlyingType = UnderlyingType.Equity;
        //Console.WriteLine(underlyingType.ToString());

        Underlying underlying = new Underlying(initialStockPrice, implied_volatility, riskFreeRate, underlyingType);

        Assert.Equal(initialStockPrice.Value, underlying.InitialStockPrice.Value);
        Assert.Equal(implied_volatility.Value, underlying.ImpliedVolatility.Value);
        Assert.Equal(riskFreeRate.Value, underlying.RiskFreeRate.Value);
        Assert.Equal(underlyingType, underlying.UnderlyingType);
    }

    [Fact]
    public void Test2()
    {

    }
}

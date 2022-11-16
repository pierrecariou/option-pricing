// File              : UnitTest1.cs
// Author            : Pierre Cariou <pierrecariou@outlook.fr>
// Date              : 08.11.2022
// Last Modified Date: 08.11.2022
// Last Modified By  : Pierre Cariou <pierrecariou@outlook.fr>

namespace OptionPricing.DAO.Test;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        PricingDTO DTO = new PricingDTO();

        DTO.dateTime = new DateTime(2022, 09, 9);
        DTO.premium = 2.2f;
        DTO.model = "BlackSholes";
        DTO.strike = 105.0f;
        DTO.maturity = new DateTime(2022, 09, 01);
        DTO.lastName = "Totoro";
        DTO.firstName = "Pierro";
        DTO.name = "DELTA2";
        DTO.initialStockPrice = 400f;
        DTO.impliedVolatility = 0.31f;
        DTO.riskFreeRate = 0.02f;
        DTO.underlyingType = "call";

        PricingDAO DAO = new PricingDAO();


        int pricingId = DAO.create(DTO);

        PricingDTO DTORetreive = DAO.read(pricingId);

        // compare
        Assert.Equal(DTO.dateTime, DTORetreive.dateTime);
        Assert.Equal(DTO.premium, DTORetreive.premium);
        Assert.Equal(DTO.model, DTORetreive.model);
        Assert.Equal(DTO.maturity, DTORetreive.maturity);
        Assert.Equal(DTO.lastName, DTORetreive.lastName);
        Assert.Equal(DTO.firstName, DTORetreive.firstName);
        Assert.Equal(DTO.name, DTORetreive.name);
        Assert.Equal(DTO.initialStockPrice, DTORetreive.initialStockPrice);
        Assert.Equal(DTO.impliedVolatility, DTORetreive.impliedVolatility);
        Assert.Equal(DTO.riskFreeRate, DTORetreive.riskFreeRate);
        Assert.Equal(DTO.underlyingType, DTORetreive.underlyingType);
        
    }
}

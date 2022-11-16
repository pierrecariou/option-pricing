namespace OptionPricing.Domain.Service
{
	public class BlackScholes_PricingService : IPricingService
	{
		public double Price(Pricing price)
		{

			double S = price.option.underlying.initialStockPrice.Value;
			double r = price.option.underlying.riskFreeRate.Value;
			double X = price.option.strike.Value;
			double v = price.option.underlying.impliedVolatility.Value;
			TimeSpan Tspan = price.option.maturity.Value - price.pricingDate.Value;
			double T = Tspan.TotalDays;
			string CallPutFlag = price.option.underlying.underlyingType.ToString();


			double d1 = 0.0;
			double d2 = 0.0;
			double dBlackScholes = 0.0;

			d1 = (Math.Log(S / X) + (r + v * v / 2.0) * T) / (v * Math.Sqrt(T));
			d2 = d1 - v * Math.Sqrt(T);

			if (CallPutFlag.ToUpper() == "CALL")
			{				
				dBlackScholes = S * CND(d1) - X * Math.Exp(-r * T) * CND(d2);
			}
			else if (CallPutFlag.ToUpper() == "PUT") 
			{
				dBlackScholes = X * Math.Exp(-r * T) * CND(-d2) - S * CND(-d1);				
			}
			return dBlackScholes;
		}


		public double CND(double X)
		{

			//double result = Chart1.DataManipulator.Statistics.NormalDistribution(1.96);


			double L = 0.0;
			double K = 0.0;
			double dCND = 0.0;
			const double a1 = 0.31938153;
			const double a2 = -0.356563782;
			const double a3 = 1.781477937;
			const double a4 = -1.821255978;
			const double a5 = 1.330274429;
			L = Math.Abs(X);
			K = 1.0 / (1.0 + 0.2316419 * L);
			dCND = 1.0 - 1.0 / Math.Sqrt(2 * Convert.ToDouble(Math.PI.ToString())) *
				Math.Exp(-L * L / 2.0) * (a1 * K + a2 * K * K + a3 * Math.Pow(K, 3.0) +
						a4 * Math.Pow(K, 4.0) + a5 * Math.Pow(K, 5.0));

			if (X < 0)
			{
				return 1.0 - dCND;
			}
			else
			{
				return dCND;
			}
		}
	}
}

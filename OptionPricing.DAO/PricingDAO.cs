// File              : PricingDAO.cs
// Author            : Pierre Cariou <pierrecariou@outlook.fr>
// Date              : 06.11.2022
// Last Modified Date: 06.11.2022
// Last Modified By  : Pierre Cariou <pierrecariou@outlook.fr>

using System.Data;
using System.Data.SqlClient;

namespace OptionPricing.DAO;

public interface IPricingDAO
{
	int create(PricingDTO DTO);
	PricingDTO read(int pricingId);
}

public class PricingDAO : IPricingDAO
{
	private readonly string connectionString =
		"Server=localhost;Database=pricingDB;User id=sa;Password=PAAsword!";
	private int pricingId;

	// CRUD Implementation //
	public int create(PricingDTO DTO) {
		using (SqlConnection connection = new SqlConnection(connectionString))
		{
			connection.Open();
			using (SqlCommand cmd = new SqlCommand("spInsertPricing", connection))
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@date_time", DTO.dateTime));
				cmd.Parameters.Add(new SqlParameter("@premium", DTO.premium));
				cmd.Parameters.Add(new SqlParameter("@model", DTO.model));
				cmd.Parameters.Add(new SqlParameter("@strike", DTO.strike));
				cmd.Parameters.Add(new SqlParameter("@maturity", DTO.maturity));

				cmd.Parameters.Add(new SqlParameter("@last_name", DTO.lastName));
				cmd.Parameters.Add(new SqlParameter("@first_name", DTO.firstName));
				cmd.Parameters.Add(new SqlParameter("@name", DTO.name));
				cmd.Parameters.Add(new SqlParameter("@initial_stock_price", DTO.initialStockPrice));
				cmd.Parameters.Add(new SqlParameter("@implied_volatility", DTO.impliedVolatility));
				cmd.Parameters.Add(new SqlParameter("@risk_free_rate", DTO.riskFreeRate));
				cmd.Parameters.Add(new SqlParameter("@underlying_type", DTO.underlyingType));
	
				var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
				returnParameter.Direction = ParameterDirection.ReturnValue;

				cmd.ExecuteNonQuery();
				pricingId = (int)returnParameter.Value;
				//Console.WriteLine(pricingId);
			}
			connection.Close();
		}
		return pricingId;
	}

	public PricingDTO read(int pricingId) {

		PricingDTO DTO = new PricingDTO();

		using (SqlConnection connection = new SqlConnection(connectionString))
		{
			connection.Open();
			using (SqlCommand cmd = new SqlCommand("spGetPricing", connection))
			{
				cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Pricing_id", pricingId));
				SqlDataReader reader = cmd.ExecuteReader();

				while (reader.Read()) {
					DTO.dateTime = (DateTime)reader.GetValue(0);
					DTO.premium = Convert.ToSingle(reader.GetValue(1));
					DTO.model = (string)reader.GetValue(2);
					DTO.strike = Convert.ToSingle(reader.GetValue(3));
					DTO.maturity = (DateTime)reader.GetValue(4);
					DTO.lastName = (string)reader.GetValue(5);
					DTO.firstName = (string)reader.GetValue(6);
					DTO.name = (string)reader.GetValue(7);
					DTO.initialStockPrice = Convert.ToSingle(reader.GetValue(8));
					DTO.impliedVolatility = Convert.ToSingle(reader.GetValue(9));
					DTO.riskFreeRate = Convert.ToSingle(reader.GetValue(10));
					DTO.underlyingType = (string)reader.GetValue(11);
				}
			}
			connection.Close();
		}
		return DTO;
	}
}

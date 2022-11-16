// File              : Trader.cs
// Author            : Pierre Cariou <pierrecariou@outlook.fr>
// Date              : 08.11.2022
// Last Modified Date: 08.11.2022
// Last Modified By  : Pierre Cariou <pierrecariou@outlook.fr>

namespace OptionPricing.Domain;

public class Trader
{
	public FirstName FirstName { get; private set; }
	public LastName LastName { get; private set; }
	public Desk Desk { get; private set; }

	public Trader(FirstName firstName, LastName lastName, Desk desk)
	{
		if (firstName == null)
			throw new Exception("Trader's first name is missing");
		if (lastName == null)
			throw new Exception("Trader's last name is missing");
		if (desk == null)
			throw new Exception("Desk must be initialized");
		FirstName = firstName;
		LastName = lastName;
		Desk = desk;
	}
}

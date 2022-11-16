// File              : Desk.cs
// Author            : Pierre Cariou <pierrecariou@outlook.fr>
// Date              : 08.11.2022
// Last Modified Date: 08.11.2022
// Last Modified By  : Pierre Cariou <pierrecariou@outlook.fr>

namespace OptionPricing.Domain;

public class Desk
{
	public DeskName DeskName { get; private set; }

	public Desk(DeskName deskName)
	{
		if (deskName == null)
			throw new Exception("Desk name should be initialized");
		DeskName = deskName;
	}
}

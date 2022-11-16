// File              : DeskName.cs
// Author            : Pierre Cariou <pierrecariou@outlook.fr>
// Date              : 08.11.2022
// Last Modified Date: 08.11.2022
// Last Modified By  : Pierre Cariou <pierrecariou@outlook.fr>

namespace OptionPricing.Domain;

public class DeskName
{
	public string Value { get; private set; }

	public DeskName(string deskName)
	{
		if (deskName == null)
			throw new Exception("Invalid desk name");
		Value = deskName;
	}
}

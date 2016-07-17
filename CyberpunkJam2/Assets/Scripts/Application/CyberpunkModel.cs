using UnityEngine;
using System.Collections;

using Framework.MVC;

public class CyberpunkModel : Model<CyberpunkApplication> {

	private FightModel fight;
	public FightModel Fight {
		get {
			return fight = Assert<FightModel> (fight);
		}
	}
}

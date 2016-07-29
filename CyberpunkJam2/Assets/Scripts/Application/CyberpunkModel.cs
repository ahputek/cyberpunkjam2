using UnityEngine;
using System.Collections;

using Framework.MVC;

public class CyberpunkModel : Model<CyberpunkApplication> {

	private FightModel fight;
	public FightModel Fight {
		get {
			return fight = Assert<FightModel> (fight, true);
		}
	}

	private BookFightModel bookFight;
	public BookFightModel BookFight {
		get {
			return bookFight = Assert<BookFightModel>(bookFight, true);
		}
	}
}

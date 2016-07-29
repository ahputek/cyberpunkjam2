using UnityEngine;
using System.Collections;

using Framework.MVC;

public class BookFightModel : Model<CyberpunkApplication> {

	[SerializeField]
	public RobotData[] robotData;
}

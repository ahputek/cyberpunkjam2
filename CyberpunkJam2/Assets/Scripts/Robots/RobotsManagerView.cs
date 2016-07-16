using UnityEngine;
using System.Collections;

using Framework.MVC;

public class RobotsManagerView : View<CyberpunkApplication> {

	[SerializeField]
	private RobotView fighterLeft;

	[SerializeField]
	private RobotView fighterRight;
}

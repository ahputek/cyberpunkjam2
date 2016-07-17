using UnityEngine;
using System.Collections;

using Framework.MVC;

public class FightModel : Model<CyberpunkApplication> {

	public RobotModel[] Robots;

	private IEnumerator Start () {
		yield return null;
		App.Notify (Constants.UPDATE_FIGHT, App.Controller.Fight, this);
	}
}

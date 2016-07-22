using UnityEngine;
using System.Collections;

using Framework.MVC;

public class FightModel : Model<CyberpunkApplication> {

	public RobotModel[] Robots;

	private IEnumerator Start () {
		yield return null;
		this.Robots[0].Health = 300;
		this.Robots[1].Health = 300;

		this.Robots[0].Power = 50;
		this.Robots[1].Power = 50;

		App.Notify (Constants.UPDATE_FIGHT, this);

	}
}

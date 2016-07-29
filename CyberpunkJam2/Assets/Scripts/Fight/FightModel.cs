using UnityEngine;
using System.Collections;
using System.Xml;

using Framework.MVC;

public class FightModel : Model<CyberpunkApplication> {

	private TextAsset textAsset;

	public RobotModel[] Robots;

	public RobotModel PlayerRobot {
		get {
			return this.playerRobot;
		}
	}
	private RobotModel playerRobot;

	private IEnumerator Start () {
		yield return null;

		this.playerRobot = this.Robots[0];
		App.Notify(Constants.LOAD_XML, App.Controller.Fight, this);
	}
}

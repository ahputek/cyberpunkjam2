using UnityEngine;
using System.Collections;
using System.Xml;

using Framework.MVC;

public class FightModel : Model<CyberpunkApplication> {

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

		// temporarily give 40 skill points
		this.playerRobot.SkillPoints += 20;
		App.Notify(Constants.UPDATE_HANGAR, App.Controller.Robot, this.playerRobot);
	}
}

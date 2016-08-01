using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using Framework.MVC;

public class HangarView : View<CyberpunkApplication> {

	[SerializeField]
	private Text robotNameLabel;

	[SerializeField]
	private StatBar strengthBar;

	[SerializeField]
	private StatBar agilityBar;

	[SerializeField]
	private StatBar vitalityBar;

	[SerializeField]
	private StatBar dextirityBar;

	[SerializeField]
	private StatBar pointsBar;

	[SerializeField]
	private StatBar winBar;

	[SerializeField]
	private StatBar lossBar;

	[SerializeField]
	private StatBar drawBar;

	[SerializeField]
	private Text infoStatLabel;

	// used in ui events
	private RobotModel currentRobot;

	public void UpdateDisplay (RobotModel robot) {
		this.robotNameLabel.text = robot.Name;
		this.strengthBar.UpdateDisplay(robot.Power);
		this.agilityBar.UpdateDisplay(robot.Speed);
		this.vitalityBar.UpdateDisplay(robot.Hardness);
		this.dextirityBar.UpdateDisplay(robot.Accuracy);
		this.pointsBar.UpdateDisplay(robot.SkillPoints);

		this.winBar.UpdateDisplay(robot.Win);
		this.lossBar.UpdateDisplay(robot.Loss);
		this.drawBar.UpdateDisplay(robot.Draw);

		this.currentRobot = robot;

		this.infoStatLabel.text = "<color=\"" + Constants.WHITE +"\">" + robot.Name + "</color>\n\n" +
		"<color=\"" + Constants.MAIN_COLOR +"\">" + "Robot info: " + "</color>\n\n" +
		"<color=\"" + Constants.MAIN_COLOR +"\">" + "Health: " + RobotController.ResolveHealth(robot) + "</color>\n" +
		"<color=\"" + Constants.MAIN_COLOR +"\">" + "Damage: " + RobotController.ResolveDamage(robot) + "</color>\n" +
		"<color=\"" + Constants.MAIN_COLOR +"\">" + "Armor: " + RobotController.ResolveDefense(robot) + "</color>\n" +
		"<color=\"" + Constants.MAIN_COLOR +"\">" + "Atk Speed: " + RobotController.ResolveAttackSpeed(robot) + "</color>\n";

		bool showButton = robot.SkillPoints > 0;
		GetStatButton(this.strengthBar).SetActive(showButton);
		GetStatButton(this.agilityBar).SetActive(showButton);
		GetStatButton(this.vitalityBar).SetActive(showButton);
		GetStatButton(this.dextirityBar).SetActive(showButton);
	}

	private GameObject GetStatButton (StatBar bar) {
		return bar.transform.GetChild(0).gameObject;
	}

	#region UI events
	public void AddStat (string stat) {
		if(this.currentRobot == null) {
			return;
		}

		// dirty usage of robot controller
		RobotController robotController = App.Controller.Robot;
		robotController.AddStat(this.currentRobot, stat);

		UpdateDisplay(this.currentRobot);
	}
	#endregion
}

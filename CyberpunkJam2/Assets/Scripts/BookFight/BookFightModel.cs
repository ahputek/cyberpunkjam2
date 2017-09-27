using UnityEngine;
using System.Collections;

using Framework.MVC;

public class BookFightModel : Model<CyberpunkApplication> {

	[SerializeField]
	public RobotData[] robotData;

	private void Start () {
		Refresh();
	}

	public void Refresh () {
		// get player's robot stats
		RobotModel playerRobot = this.App.Model.Fight.PlayerRobot;

		for(int i = 0; i < this.robotData.Length; i++) {
			RobotData aiRobot = this.robotData[i];
			aiRobot.Power = Random.Range(playerRobot.Power - 15, playerRobot.Power + 20);
			aiRobot.Speed = Random.Range(playerRobot.Speed - 10, playerRobot.Speed + 15);
			aiRobot.Hardness = Random.Range(playerRobot.Hardness - 5, playerRobot.Hardness + 5);
			aiRobot.Accuracy = Random.Range(playerRobot.Accuracy - 20, playerRobot.Accuracy + 20);
			this.robotData[i] = aiRobot;
		}

		// update view
		BookFightView view = App.View.BookFight;
		view.UpdateDisplay();
	}
}

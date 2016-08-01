using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BookFightTab : MonoBehaviour {

	[SerializeField]
	private Text stats;

	[SerializeField]
	private Image robotIcon;

	private const string ENDLINE = "\n";

	public void UpdateDisplay (RobotData robot) {
		this.stats.text = ConstructStats(robot);
	}

	private string ConstructStats (RobotData robot) {
		string value = string.Empty;
		value += "Name: " + robot.Name;
		value += ENDLINE;
		value += "STR: " + robot.Power;
		value += ENDLINE;
		value += "AGI: " + robot.Speed;
		value += ENDLINE;
		value += "DEX: " + robot.Accuracy;
		value += ENDLINE;
		value += "VIT: " + robot.Hardness;
//		value += ENDLINE;
//		value += "Record: " + robot.Win + "-" + robot.Loss + "-" + robot.Draw;
		return value;
	}
}

using UnityEngine;
using System.Collections;
using System.Xml;

using Framework.MVC;

public class FightController : Controller<CyberpunkApplication> {
	
	public override void OnNotification (string p_event, Object p_target, params object[] p_data) {
		if (p_event.Equals (Constants.UPDATE_FIGHT)) {
			FightView view = App.View.Fight;
			if(p_data.Length > 0) {
				FightModel model = (FightModel) p_data[0];
				view.UpdateDisplay (model);
			}
		}
		else if(p_event.Equals(Constants.LOAD_XML)) {
			FightModel model = (FightModel) p_data[0];
			LoadXml(model);
		}
	}

	private void LoadXml (FightModel fight) {
		XmlDocument document = new XmlDocument();
		string filePath = Application.streamingAssetsPath + "/TestRobots.xml";
		string result = System.IO.File.ReadAllText(filePath);
		document.LoadXml(result);

		XmlNode node = document.ChildNodes.Item(0);
		for(int i = 0; i < node.ChildNodes.Count; i++) {
			ReadRobot(node.ChildNodes.Item(i), fight.Robots[i]);
		}

		App.Notify (Constants.UPDATE_FIGHT, this, App.Model.Fight);
	}

	private void ReadRobot (XmlNode node, RobotModel robot) {
		robot.Name = node.Attributes["name"].Value;
		robot.Health = int.Parse(node.Attributes["health"].Value);
		robot.Power = int.Parse(node.Attributes["power"].Value);
	}
}

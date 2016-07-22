using UnityEngine;
using System.Collections;
using System.Xml;

using Framework.MVC;

public class FightModel : Model<CyberpunkApplication> {

	private TextAsset textAsset;

	public RobotModel[] Robots;

	private IEnumerator Start () {
		yield return null;

		App.Notify(Constants.LOAD_XML, App.Controller.Fight, this);
	}
}

using UnityEngine;
using System.Collections;

using Framework.MVC;

public class HangarController : Controller<CyberpunkApplication> {

	public override void OnNotification (string p_event, Object p_target, params object[] p_data) {
		if(p_event.Equals(Constants.UPDATE_HANGAR)) {	
			HangarView view = App.View.Hangar;
			RobotModel robot = (RobotModel) p_data[0];
			if(robot == null) {
				return;
			}
			view.UpdateDisplay(robot);
		}
	}
}

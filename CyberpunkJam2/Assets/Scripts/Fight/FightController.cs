using UnityEngine;
using System.Collections;

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
	}
}

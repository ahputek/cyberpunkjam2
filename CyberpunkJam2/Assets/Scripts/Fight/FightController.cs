using UnityEngine;
using System.Collections;

using Framework.MVC;

public class FightController : Controller<CyberpunkApplication> {
	
	public override void OnNotification (string p_event, Object p_target, params object[] p_data) {
		if (p_event.Equals (Constants.UPDATE_FIGHT)) {
			FightView view = App.View.Fight;
			FightModel model = (FightModel) p_data.GetValue (0);
			view.UpdateDisplay (model);
		}
	}
}

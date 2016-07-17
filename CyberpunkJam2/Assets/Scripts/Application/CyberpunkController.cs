using UnityEngine;
using System.Collections;

using Framework.MVC;

public class CyberpunkController : Controller<CyberpunkApplication> {

	private FightController fight;
	public FightController Fight {
		get {
			return fight = Assert<FightController>(fight);
		}
	}

	public override void OnNotification (string p_event, Object p_target, params object[] p_data)
	{
		base.OnNotification (p_event, p_target, p_data);
		Debug.Log (p_event);
	}
}

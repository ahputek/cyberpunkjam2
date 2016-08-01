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

	private RobotController robot;
	public RobotController Robot {
		get {
			return robot = Assert<RobotController>(robot, true);
		}
	}

	private HangarController hangar;
	public HangarController Hangar {
		get {
			return hangar = Assert<HangarController>(hangar, true);
		}
	}

	public override void OnNotification (string p_event, Object p_target, params object[] p_data)
	{
		base.OnNotification (p_event, p_target, p_data);
//		Debug.Log(p_event + ", " + p_target + ", " + p_data.Length);
	}
}

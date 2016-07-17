using UnityEngine;
using System.Collections;

using Framework.MVC;

public class RobotController : Controller<CyberpunkApplication> {

	public override void OnNotification (string p_event, Object p_target, params object[] p_data) {
		
	}

	public void Attack (RobotModel attacker, RobotModel target) {
		int damage = attacker.Power;

		ReceiveAttack (target, damage);
	}

	public void ReceiveAttack (RobotModel target, int damage) {
		target.Health -= damage;

		if (target.Health <= 0) {
			Die (target);
		}
	}

	public void Die (RobotModel robot) {

	}
}

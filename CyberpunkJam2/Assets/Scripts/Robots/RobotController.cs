using UnityEngine;
using System.Collections;

using Framework.MVC;

public class RobotController : Controller<CyberpunkApplication> {

	public override void OnNotification (string p_event, Object p_target, params object[] p_data) {
		if(p_event.Equals(Constants.ATTACK)) {
			RobotModel robotA = (RobotModel) p_data[0];
			RobotModel robotB = (RobotModel) p_data[1];
			Attack(robotA, robotB);
		}
		else if(p_event.Equals(Constants.WIN)) {
			RobotModel robot = (RobotModel) p_data[0];
			Win(robot);
		}
		else if(p_event.Equals(Constants.LOSE)) {
			RobotModel robot = (RobotModel) p_data[0];
			Lose(robot);
		}
	}

	public void Attack (RobotModel attacker, RobotModel target) {
		// get view, then play animation
		RobotView view = attacker.GetComponent<RobotView>();
		if(view != null) {
			view.Attack();
		}

		int damage = attacker.Power;

		ReceiveAttack (target, damage);
	}

	public void ReceiveAttack (RobotModel target, int damage) {
		// get view, then play animation
		RobotView view = target.GetComponent<RobotView>();
		if(view != null) {
			StartCoroutine(view.Hit());
		}

		target.Health -= damage;

		if (target.Health <= 0) {
//			Die (target);
		}
	}

	public void Win (RobotModel robot) {
		// get view, then play animation
		RobotView view = robot.GetComponent<RobotView>();
		if(view != null) {
			view.Win();
		}
	}

	public void Lose (RobotModel robot) {
		// get view, then play animation
		RobotView view = robot.GetComponent<RobotView>();
		if(view != null) {
			view.Lose();
		}
	}
}

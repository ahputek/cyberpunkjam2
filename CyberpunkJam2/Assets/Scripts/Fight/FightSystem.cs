using UnityEngine;
using System.Collections;

public class FightSystem : MonoBehaviour {

	private enum Turn { RobotA, RobotB };

	[SerializeField]
	private Turn turn;

	private RobotModel robotA;
	private RobotModel robotB;

	private void Start () {
		StartCoroutine(TakeTurn());
	}

	private IEnumerator TakeTurn () {
		bool flag = true;
		while(flag) {
			CyberpunkApplication app = CyberpunkApplication.Instance;
			if(app.Model.Fight != null) {
				this.robotA = app.Model.Fight.Robots[0];
				this.robotB = app.Model.Fight.Robots[1];
			}

			yield return new WaitForSeconds(2);
			if(robotA != null && robotB != null) {
				Attack(robotA, robotB);
			}

//			yield return new WaitForSeconds(0.5f);
//			if(robotA != null && robotB != null) {
//				ResolveRobotStatus(robotA, robotB);
//				flag = IsAlive(robotB);
//			}

			yield return new WaitForSeconds(2);
			if(robotA != null && robotB != null) {
				Attack(robotB, robotA);
			}

//			yield return new WaitForSeconds(0.5f);
//			if(robotA != null && robotB != null) {
//				ResolveRobotStatus(robotB, robotA);
//				flag = IsAlive(robotA);
//			}
		}
	}

	private void Attack (RobotModel attacker, RobotModel target) {
		CyberpunkApplication app = CyberpunkApplication.Instance;
		app.Notify(Constants.ATTACK, app.Controller.Robot, attacker, target);
		app.Notify(Constants.UPDATE_FIGHT, app.Controller.Fight,  app.Model.Fight);
	}

	private void ResolveRobotStatus (RobotModel attacker, RobotModel target) {
		if(IsAlive(target)) {
			CyberpunkApplication app = CyberpunkApplication.Instance;
			app.Notify(Constants.WIN, app.Controller.Robot, target);
			app.Notify(Constants.LOSE, app.Controller.Robot, attacker);
		}
	}

	private bool IsAlive (RobotModel robot) {
		return robot.Health > 0;
	}
}

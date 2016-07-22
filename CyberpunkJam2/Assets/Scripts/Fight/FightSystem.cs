using UnityEngine;
using System.Collections;

public class FightSystem : MonoBehaviour {

	private enum Turn { IDLE, ROBOT_A, ROBOT_B, DONE };

	[SerializeField]
	private Turn turn;

	private RobotModel robotA;
	private RobotModel robotB;

	private void Awake () {
		this.turn = Turn.IDLE;

		StartCoroutine(FSM());
	}

	// FSM will be called every frame
	private IEnumerator FSM () {
		while(true) {
			yield return StartCoroutine(this.turn.ToString());
		}
	}

	private IEnumerator IDLE () {
		yield return null;

		yield return new WaitUntil(() => this.turn != Turn.IDLE);
	}

	private IEnumerator ROBOT_A () {
		yield return null;
		CyberpunkApplication app = CyberpunkApplication.Instance;
		if(app.Model.Fight != null) {
			this.robotA = app.Model.Fight.Robots[0];
			this.robotB = app.Model.Fight.Robots[1];
		}

		Attack(robotA, robotB);
		yield return new WaitUntil(() => this.turn != Turn.ROBOT_A);
	}

	private IEnumerator ROBOT_B () {
		yield return null;
		CyberpunkApplication app = CyberpunkApplication.Instance;
		if(app.Model.Fight != null) {
			this.robotA = app.Model.Fight.Robots[0];
			this.robotB = app.Model.Fight.Robots[1];
		}

		Attack(robotB, robotA);
		yield return new WaitUntil(() => this.turn != Turn.ROBOT_B);
	}

	private IEnumerator DONE () {
		yield return null;

		yield return new WaitUntil(() => this.turn != Turn.DONE);
	}

	private void Attack (RobotModel attacker, RobotModel target) {
		CyberpunkApplication app = CyberpunkApplication.Instance;
		app.Notify(Constants.ATTACK, app.Controller.Robot, attacker, target);
		app.Notify(0.5f, Constants.UPDATE_FIGHT, app.Controller.Fight,  app.Model.Fight);

		ResolveRobotStatus(attacker, target);
	}

	private void ResolveRobotStatus (RobotModel attacker, RobotModel target) {
		if(!IsAlive(target)) {
			CyberpunkApplication app = CyberpunkApplication.Instance;
			app.Notify(Constants.WIN, app.Controller.Robot, attacker);
			app.Notify(Constants.LOSE, app.Controller.Robot, target);
		}
	}

	private bool IsAlive (RobotModel robot) {
		return robot.Health > 0;
	}


}

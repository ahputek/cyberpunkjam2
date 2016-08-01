using UnityEngine;
using System.Collections;

public class FightSystem : MonoBehaviour {

	public static FightSystem Instance { private set; get; }

	public enum Turn { IDLE, START, ROBOT_A, ROBOT_B, DONE };

	[SerializeField]
	public Turn turn;

	private RobotModel robotA;
	private RobotModel robotB;

	private void Awake () {
		Instance = this;
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

	private IEnumerator START () {
		yield return null;

		CyberpunkApplication app = CyberpunkApplication.Instance;
		app.Notify (Constants.UPDATE_FIGHT, this, app.Model.Fight);
		app.Notify (Constants.IDLE, app.Controller.Robot, app.Model.Fight.Robots[0]);
		app.Notify (Constants.IDLE, app.Controller.Robot, app.Model.Fight.Robots[1]);

		yield return new WaitForSeconds(1);
		this.turn = Turn.ROBOT_A;

		yield return new WaitUntil(() => this.turn != Turn.START);
	}

	private IEnumerator ROBOT_A () {
		yield return null;
		CyberpunkApplication app = CyberpunkApplication.Instance;
		if(app.Model.Fight != null) {
			this.robotA = app.Model.Fight.Robots[0];
			this.robotB = app.Model.Fight.Robots[1];
		}

		Attack(robotA, robotB);
		yield return new WaitForSeconds(1);
		if(IsAlive(robotA) && IsAlive(robotB))
			this.turn = Turn.ROBOT_B;
		else
			this.turn = Turn.DONE;
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
		yield return new WaitForSeconds(1);
		if(IsAlive(robotA) && IsAlive(robotB))
			this.turn = Turn.ROBOT_A;
		else
			this.turn = Turn.DONE;
		yield return new WaitUntil(() => this.turn != Turn.ROBOT_B);
	}

	private IEnumerator DONE () {
		yield return null;
		CyberpunkApplication.Instance.Notify(2, Constants.UPDATE_HANGAR, CyberpunkApplication.Instance.Controller.Hangar, this.robotA);
		CyberpunkApplication.Instance.Notify(2, Constants.RELOAD_GAME);
		yield return null;
		Invoke("ResetState", 2.1f);
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
			app.Notify(1, Constants.LOSE, app.Controller.Robot, target);
		}
	}

	private bool IsAlive (RobotModel robot) {
		return robot.Health > 0;
	}

	private void ResetState () {
		this.turn = Turn.IDLE;
		CyberpunkApplication.Instance.Model.Fight.Robots[0].Health = CyberpunkApplication.Instance.Model.Fight.Robots[0].MaxHealth; 
		CyberpunkApplication.Instance.Model.Fight.Robots[1].Health = CyberpunkApplication.Instance.Model.Fight.Robots[1].MaxHealth; 
	}
}

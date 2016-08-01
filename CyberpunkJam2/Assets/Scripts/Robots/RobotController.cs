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
		else if(p_event.Equals(Constants.IDLE)) {
			RobotModel robot = (RobotModel) p_data[0];
			Idle(robot);
		}
	}

	public void Attack (RobotModel attacker, RobotModel target) {
		// get view, then play animation
		RobotView view = attacker.GetComponent<RobotView>();
		if(view != null) {
			view.Attack();
		}

		int diceResult, damage;
		int HitRate = ResolveHitRate(attacker, target);
		int BlockRate = ResolveBlockRate (target);
		int DodgeRate = ResolveDodgeRate (attacker, target);

		if (HitRate > (diceResult = DieHitRate ())) {
			//insert dodge animation for target here, attacker misses
			damage = 0;
		} 
		else {
			damage = ResolveDamage (attacker, target);

			if (BlockRate > (diceResult = DieBlockRate ())) {
				//insert animation here
				damage = ResolveDamage (attacker, target);
			}
		}

		//damage = ResolveDamage (attacker, target);
		//Debug.Log ("ReducedDmg: "+damage.ToString());

		ReceiveAttack (target, damage);
	}

	public void ReceiveAttack (RobotModel target, int damage) {
		// get view, then play animation
		RobotView view = target.GetComponent<RobotView>();
		if(view != null) {
			StartCoroutine(view.Hit());
		}

		target.Health -= damage;
		//Debug.Log ("TargetHP: "+target.Health.ToString ());

		if (target.Health <= 0) {
//			Die (target);
		}
	}

	#region HitRate, BlockRate, DodgeRate, DiceRates, and Damage Reduction Computation
	public int ResolveDamage(RobotModel attacker, RobotModel target){
		//Initial Stats of Damage
		int attackerDamage = attacker.Power + (attacker.Accuracy/5);
		int targetDefense = target.Hardness / 5;

		//Damage mitigation
		int totalDamage = attackerDamage - targetDefense;
		return totalDamage;
	}

	public int ResolveHitRate(RobotModel attacker, RobotModel target){
		//Initial Stats or Computation for hit and dodge rate using basic stats
		int attackerHitRate = attacker.Accuracy + (attacker.Speed/5);
		int targetDodgeRate = target.Speed;

		//Final equation for Hitrate
		int hitRate = 100 - (70 + (attackerHitRate - targetDodgeRate));
		return hitRate;
	}

	public int DieHitRate(){
		//Dice Equation for the HitRate
		int diceResult = 5*(Random.Range (1, 10) + Random.Range (1, 10));
		return diceResult;
	}

	public int ResolveBlockRate(RobotModel target){
		//Equation for the block rate of the targetted robot
		int targetBlockRate = (target.Hardness / 3) + (target.Power / 5);

		//Final equation for BlockRate
		int blockRate = 100 - (20 + targetBlockRate);
		return blockRate;
	}

	public int DieBlockRate(){
		//Dice Equation for the BlockRate
		int diceResult = 5*(Random.Range(1,10) + Random.Range(1,10));
		return diceResult;
	}

	public int ResolveDodgeRate(RobotModel attacker, RobotModel target){
		//Equation for the DodgeRate of the target
		int targetDodgeRate = target.Speed;
		int attackerHitRate = ResolveHitRate (attacker, target);

		//Final Equation for the DodgeRate of the target
		int dodgeRate = 100 - (60 - (attackerHitRate - targetDodgeRate));
		return dodgeRate;
	}

	public int DieDodgeRate(){
		//Dice Equation for the DodgeRate
		int diceResult = 5 * Random.Range(1,20);
		return diceResult;
	}
	#endregion
	public void Idle (RobotModel robot) {
		// get view, then play animation
		RobotView view = robot.GetComponent<RobotView>();
		if(view != null) {
			view.Idle();
		}
	}

	public void Win (RobotModel robot) {
		robot.Win++;
		robot.SkillPoints += 5;

		// get view, then play animation
		RobotView view = robot.GetComponent<RobotView>();
		if(view != null) {
			view.Win();
		}
	}

	public void Lose (RobotModel robot) {
		robot.Loss++;
		robot.SkillPoints += 2;

		// get view, then play animation
		RobotView view = robot.GetComponent<RobotView>();
		if(view != null) {
			view.Lose();
		}
	}

	public void AddStat (RobotModel robot, string stat) {
		if(robot.SkillPoints <= 0) {
			return;
		}

		switch(stat) {
		case "STR":
			robot.Power++;
			break;
		case "AGI":
			robot.Speed++;
			break;
		case "VIT":
			robot.Hardness++;
			break;
		case "DEX":
			robot.Accuracy++;
			break;
		}

		robot.SkillPoints--;
	}

	private const int BASE_HEALTH = 300;
	private const int HEALTH_MULTIPLIER = 5;

	public static int ResolveHealth (RobotModel robot) {
		return BASE_HEALTH + (HEALTH_MULTIPLIER * robot.Hardness);
	}

	public static int ResolveDamage (RobotModel robot) {
		return robot.Power + Mathf.CeilToInt(robot.Accuracy / 5);
	}

	public static int ResolveDefense (RobotModel robot) {
		return Mathf.CeilToInt(robot.Hardness / 5);
	}

	public static int ResolveAttackSpeed (RobotModel robot) {
		return robot.Speed;
	}
}

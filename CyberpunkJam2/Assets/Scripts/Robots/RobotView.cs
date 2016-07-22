using UnityEngine;
using System.Collections;

using Framework.MVC;

public class RobotView : View<CyberpunkApplication> {

	private RobotModel robotModel;

	private Animator animator;

	private const string IDLE = "Idle_";
	private const int IDLE_COUNT = 3;

	private const string ATTACK = "Attack_";
	private const int ATTACK_COUNT = 3;

	private const string DODGE = "Dodge_";
	private const int DODGE_COUNT = 1;

	private const string BLOCK = "Block_";
	private const int BLOCK_COUNT = 1;

	private const string HIT = "Hit_";
	private const int HIT_COUNT = 1;

	private const string LOSE = "Lose_";
	private const int LOSE_COUNT = 1;

	private const string WIN = "Win_";
	private const int WIN_COUNT = 1;

	private void Start () {
		this.robotModel = GetComponent<RobotModel> ();
		this.animator = GetComponent<Animator> ();
	}

	// ranging from 1 to max
	private int GetRandomIndex (int max) {
		return Random.Range(1, max);
	}

	private string GetAnimationString (string baseString, int max) {
		int index = GetRandomIndex(max);
		return string.Concat(baseString, index.ToString());
	}

	#region Animation Events
	public void Attack () {
		this.animator.Play(GetAnimationString(ATTACK, ATTACK_COUNT));
	}

	public IEnumerator Hit () {
		yield return new WaitForSeconds(0.5f);
		this.animator.Play(GetAnimationString(HIT, HIT_COUNT));
	}

	public void Win () {
		this.animator.Play(GetAnimationString(WIN, WIN_COUNT));
	}

	public void Lose () {
		this.animator.Play(GetAnimationString(LOSE, LOSE_COUNT));
	}
	#endregion
}

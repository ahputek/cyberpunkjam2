using UnityEngine;
using System.Collections;

public class RobotInputHandler : MonoBehaviour {

	private Animator animator;

	[SerializeField]
	private bool player1;

	[SerializeField]
	private bool player2;

	private void Start () {
		this.animator = GetComponent<Animator> ();
	}

	private void Update () {
		if (this.player1) {
			if (Input.GetKeyDown (KeyCode.Z)) {
				this.animator.Play ("Attack_1");
			}
			if (Input.GetKeyDown (KeyCode.X)) {
				this.animator.Play ("Attack_2");
			}
			if (Input.GetKeyDown (KeyCode.C)) {
				this.animator.Play ("Attack_3");
			}
		} else if (this.player2) {
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				this.animator.Play ("Attack_1");
			}
			if (Input.GetKeyDown (KeyCode.DownArrow)) {
				this.animator.Play ("Attack_2");
			}
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				this.animator.Play ("Attack_3");
			}
		}
	}
}

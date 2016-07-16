using UnityEngine;
using System.Collections;

using Framework.MVC;

public class RobotView : View<CyberpunkApplication> {

	private Animator animator;

	private void Start () {
		this.animator = GetComponent<Animator> ();
	

	}
}

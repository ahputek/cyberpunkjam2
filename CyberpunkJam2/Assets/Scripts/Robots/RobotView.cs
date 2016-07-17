using UnityEngine;
using System.Collections;

using Framework.MVC;

public class RobotView : View<CyberpunkApplication> {

	private RobotModel robotModel;

	private RobotController robotController { get; set; }

	private Animator animator;

	private void Start () {
		this.robotModel = GetComponent<RobotModel> ();
		this.animator = GetComponent<Animator> ();
	}

	#region Animation Events
	public void Attack () {
		
	}
	#endregion
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using Framework.MVC;

public class FightView : View<CyberpunkApplication> {

	[SerializeField]
	private Text player1Name;

	[SerializeField]
	private Text player2Name;

	[SerializeField]
	private Slider player1Slider;

	[SerializeField]
	private Slider player2Slider;

	public void UpdateDisplay (FightModel fight) {
		this.player1Name.text = fight.Robots[0].Name;
		this.player2Name.text = fight.Robots[1].Name;

		this.player1Slider.maxValue = fight.Robots[0].MaxHealth;
		this.player1Slider.value = fight.Robots [0].Health;
		this.player2Slider.maxValue = fight.Robots[1].MaxHealth;
		this.player2Slider.value = fight.Robots [1].Health;
	}

	#region UI events
	public void Refresh () {
		App.Notify(Constants.UPDATE_FIGHT, App.Controller.Fight, App.Model.Fight);
		FightSystem.Instance.turn = FightSystem.Turn.IDLE;
	}

	public void AttackLeft () {
		FightSystem.Instance.turn = FightSystem.Turn.ROBOT_A;
	}

	public void AttackRight () {
		FightSystem.Instance.turn = FightSystem.Turn.ROBOT_B;
	}

	public void Restart () {
		UnityEngine.SceneManagement.SceneManager.LoadScene(0);
	}
	#endregion
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using Framework.MVC;

public class FightView : View<CyberpunkApplication> {

	[SerializeField]
	private Slider player1Slider;

	[SerializeField]
	private Slider player2Slider;

	public void UpdateDisplay (FightModel fight) {
		this.player1Slider.value = fight.Robots [0].Health;
		this.player2Slider.value = fight.Robots [1].Health;

		Debug.Log("Updated fight");
	}
}

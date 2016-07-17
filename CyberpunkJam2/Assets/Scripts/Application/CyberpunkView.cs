using UnityEngine;
using System.Collections;

using Framework.MVC;

public class CyberpunkView : View<CyberpunkApplication> {

	private FightView fight;
	public FightView Fight {
		get {
			return this.fight = Assert<FightView> (this.fight, true);
		}
	}

	private void Update () {
		if(Input.GetKeyUp(KeyCode.Space)) {
			Messenger.Broadcast("OpenLobby");
			Debug.Log (Fight);
		}
	}
}

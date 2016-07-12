using UnityEngine;
using System.Collections;

using Framework.MVC;

public class CyberpunkView : View<CyberpunkApplication> {

	private void Update () {
		if(Input.GetKeyUp(KeyCode.Space)) {
			Messenger.Broadcast("OpenLobby");
		}
	}
}

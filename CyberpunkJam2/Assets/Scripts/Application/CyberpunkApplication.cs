using UnityEngine;
using System.Collections;

using Framework.MVC;

public class CyberpunkApplication : BaseApplication<CyberpunkModel, CyberpunkView, CyberpunkController> {

	protected override void Start () {
		base.Start ();
		SceneAdd("Robots");
		SceneAdd("Lobby");
	}
}

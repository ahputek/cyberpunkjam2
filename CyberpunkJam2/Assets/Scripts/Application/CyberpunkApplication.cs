using UnityEngine;
using System.Collections;

using Framework.MVC;

public class CyberpunkApplication : BaseApplication<CyberpunkModel, CyberpunkView, CyberpunkController> {

	public static CyberpunkApplication Instance {
		get;
		private set;
	}

	private void Awake () {
		Instance = this;
	}

	protected override void Start () {
		base.Start ();
		SceneAdd("Robots");
		SceneAdd("Lobby");
		SceneAdd("Fight");
	}
}

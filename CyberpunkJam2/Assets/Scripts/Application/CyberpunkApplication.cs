using UnityEngine;
using System.Collections;

using Framework.MVC;

public class CyberpunkApplication : BaseApplication<CyberpunkModel, CyberpunkView, CyberpunkController> {

	private void Start () {
		SceneAdd("Robots");
		
	}
}

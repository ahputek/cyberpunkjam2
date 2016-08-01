using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using Framework.MVC;

public class LobbyView : View<CyberpunkApplication>, IPanel {

	[SerializeField]
	private GameObject rootView;

	[SerializeField]
	private Toggle firstToggle;

	private void Start () {
		UnityEngine.Assertions.Assert.IsNotNull(this.rootView);
	}

	public void Show () {
		this.rootView.SetActive(true);
		this.firstToggle.isOn = true;
	}

	public void Hide () {
		this.rootView.SetActive(false);
	}
}

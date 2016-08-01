using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;

public class PanelHandler : MonoBehaviour {

	IPanel panel;

	[SerializeField]
	private string openMessage;

	[SerializeField]
	private string closeMesssage;

	private void OnEnable () {
		Messenger.AddListener(this.openMessage, OnOpen);
		Messenger.AddListener(this.closeMesssage, OnClose);
	}

	private void OnDisable () {
		Messenger.RemoveListener(this.openMessage, OnOpen);
		Messenger.RemoveListener(this.closeMesssage, OnClose);
	}

	private void Start () {
		this.panel = (IPanel) GetComponent("IPanel");
		Assert.IsNotNull(this.panel);
		Assert.IsFalse(this.openMessage.Equals(string.Empty));
		Assert.IsFalse(this.closeMesssage.Equals(string.Empty));
	}

	private void OnOpen () {
		this.panel.Show();
	}

	private void OnClose () {
		this.panel.Hide();
	}
}

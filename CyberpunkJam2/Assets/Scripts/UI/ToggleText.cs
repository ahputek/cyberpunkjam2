using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToggleText : MonoBehaviour {

	[SerializeField]
	private Text text;

	[SerializeField]
	private Color normal;

	[SerializeField]
	private Color selected;

	private void Start () {
		UnityEngine.Assertions.Assert.IsNotNull(this.text);

		Toggle toggle = GetComponent<Toggle>();
		ChangeState(toggle.isOn);
	}

	public void ChangeState (bool flag) {
		this.text.color = flag ? selected : normal;
	}
}

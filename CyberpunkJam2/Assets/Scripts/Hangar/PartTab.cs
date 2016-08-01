using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PartTab : MonoBehaviour {

	[SerializeField]
	private string partName;

	[SerializeField]
	private Text partNameLabel;

	private void Start () {
		this.partNameLabel.text = this.partName;
	}

	private void Next () {

	}

	private void Previous () {

	}
}

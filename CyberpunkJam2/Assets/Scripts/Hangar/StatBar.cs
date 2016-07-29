using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatBar : MonoBehaviour {

	[SerializeField]
	private string statName;

	[SerializeField]
	private Text label;

	private const string SEPARATOR = ": ";

	public void UpdateDisplay (int level) {
		this.label.text = string.Concat(this.statName, SEPARATOR, level.ToString());
	}
}

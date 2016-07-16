using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

using Framework.MVC;
using Test;

public class InventoryView : View<TestApplication> {

	[SerializeField]
	private Toggle[] toggle;

	private Text[] buttonText;

	[SerializeField]
	private Text infoName;

	[SerializeField]
	private Text infoDescription;

	private int index;

	private void Start () {
		this.buttonText = new Text[this.toggle.Length];
		for (int i = 0; i < this.toggle.Length; i++) {
			this.buttonText [i] = this.toggle [i].GetComponentInChildren<Text> ();
		}
	}

	public void UpdateDisplay (List<Item> items) {
		for (int i = 0; i < this.toggle.Length; i++) {
			this.buttonText [i].text = items [i].Name;
		}
	}

	public void Select (int index) {
		this.index = index;
		UpdateInfoPanel ();
	}

	private void UpdateInfoPanel () {
		Item currentItem = App.Model.Inventory.Items [this.index];
		this.infoName.text = currentItem.Name;
		this.infoDescription.text = currentItem.Description;
	}
}

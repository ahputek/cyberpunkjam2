using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using System.Collections;

using Framework.MVC;
using Test;

public class ItemView : View<TestApplication> {

	[SerializeField]
	private Toggle toggle = null;
	private Text toggleText;
	private ToggleGroup toggleGroup;
	private Button addButton;
	private Button removeButton;

	private void Start () {
		if (toggleGroup.AnyTogglesOn () == true) {
			toggleGroup.SetAllTogglesOff ();
		}

		// cache model
		ItemModel item = App.Model.Item;

		// update display once
		InitItemSlots (item);
	}

	// update display once
	private void InitItemSlots (ItemModel item){
		
		//sample.Toggles = (Toggle)Instantiate (sample.Toggles, transform.position, transform.rotation);
		//Instantiate (Toggle, new Vector3 (100, 50, 0), transform.rotation);

	}

	private void UpdateItemSlots (ItemModel item){
		
		if (this.toggle.isOn == true) {
			this.toggle.isOn = false;
		}
	}

	public void OnToggleStatus(){
		ItemModel item = App.Model.Item;

		UpdateItemSlots (item);
	}

	public void OnButtonPress(){
		ItemModel item = App.Model.Item;

		UpdateItemSlots (item);
	}
}

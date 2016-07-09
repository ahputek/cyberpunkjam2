using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using Framework.MVC;
using Test;

public class ItemModel : Model<TestApplication> {

	private bool toggleStatus;
	private GameObject toggleObject;
	private Toggle myToggle;
	private Button addButton;
	private Button removeButton;

	public GameObject Toggles {
		get {
			return toggleObject;
		}
		set {
			toggleObject = value;

			ItemView itemView = App.View.Item;

			//itemView.
		}
	}

	public bool ToggleStatus {
		get {
			return toggleStatus;
		}
		set {
			toggleStatus = value;

			ItemView itemView = App.View.Item;

			itemView.OnToggleStatus ();
		}
	}

	public Button AddButton {
		get {
			return addButton;
		}
		set {
			addButton = value;

			ItemView itemView = App.View.Item;

			itemView.OnButtonPress();
		}
	}

	public Button RemoveButton {
		get {
			return removeButton;
		}
		set {
			removeButton = value;

			ItemView itemView = App.View.Item;

			itemView.OnButtonPress();
		}
	}
}
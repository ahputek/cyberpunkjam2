using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Framework.MVC;
using Test;

public class InventoryModel : Model<TestApplication> {

	private List<Item> items = new List<Item>();
	public List<Item> Items {
		get {
			return this.items;
		}
	}

	private void Start () {
		InitializeItems ();
		App.Notify (Constants.UPDATE_INVENTORY, this.items);
	}

	private void InitializeItems () {
		int count = 8;
		for (int i = 0; i < count; i++) {
			string name = InventoryController.GetRandomName ();
			Item item = InventoryController.CreateItem (name, "Description");
			this.items.Add (item);
		}
	}
}

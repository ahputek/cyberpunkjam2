using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Framework.MVC;
using Test;

public class InventoryController : Controller<TestApplication> {

	public override void OnNotification (string p_event, Object p_target, params object[] p_data) {
		switch (p_event) {
		case Constants.UPDATE_INVENTORY:
			InventoryView inventory = App.View.Inventory;
			inventory.UpdateDisplay ((List<Item>) p_data [0]);
			break;
		}
	}

	public static Item CreateItem (string name, string description) {
		Item item = new Item ();
		item.Name = name;
		item.Description = description;
		return item;
	}

	public static string GetRandomName () {
		string[] names = new string[] {
			"Tango",
			"Healing Salve",
			"Ironwood Branch",
			"Shadow Blade",
			"Blink Dagger",
			"Clarity Potion",
			"Aegis of Immortal",
			"Divine Rapier",
			"Bloodthorn",
			"Trash"
		};

		return names [Random.Range (0, names.Length)];
	}
}

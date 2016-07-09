using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using Framework.MVC;
using Test;

public class ItemController : Controller<TestApplication> {

	public override void OnNotification (string p_event, Object p_target, params object[] p_data)
	{
		// remove this line if not needed
		base.OnNotification (p_event, p_target, p_data);

		if (p_event.Equals (Constants.MOUSECLICK)) {

			ItemModel itemModel = (ItemModel)p_data [0];

			bool isCheck = (bool)p_data [1];

			SetStatus (itemModel, isCheck);
		}
	}

	public void SetStatus (ItemModel item, bool ischeck) {
		item.ToggleStatus = ischeck;
	}
}
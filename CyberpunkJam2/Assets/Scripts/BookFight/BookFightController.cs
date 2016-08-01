using UnityEngine;
using System.Collections;

using Framework.MVC;

public class BookFightController : Controller<CyberpunkApplication> {

	public override void OnNotification (string p_event, Object p_target, params object[] p_data) {
		if(p_event.Equals(Constants.UPDATE_BOOK_FIGHT)) {
			BookFightModel model = App.Model.BookFight;
			BookFightView view = App.View.BookFight;
			view.UpdateDisplay(model);
		}
	}

	private void Start () {
//		App.Notify(2, Constants.UPDATE_BOOK_FIGHT);
	}
}

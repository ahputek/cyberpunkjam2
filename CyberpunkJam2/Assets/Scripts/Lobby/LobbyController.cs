using UnityEngine;
using System.Collections;

using Framework.MVC;

public class LobbyController : Controller<CyberpunkApplication> {

	public override void OnNotification (string p_event, Object p_target, params object[] p_data) {
		if(p_event.Equals(Constants.START_FIGHT)) {
			LobbyView view = App.View.Lobby;
			view.Hide();
		}
		else if(p_event.Equals(Constants.RELOAD_GAME)) {
			LobbyView view = App.View.Lobby;
			view.Show();

			// refresh robot stats
			BookFightModel bookFight = App.Model.BookFight;
			bookFight.Refresh();
//			App.Notify(Constants.UPDATE_HANGAR);
		}
	}
}

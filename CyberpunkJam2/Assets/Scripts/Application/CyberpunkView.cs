using UnityEngine;
using System.Collections;

using Framework.MVC;

public class CyberpunkView : View<CyberpunkApplication> {

	private LobbyView lobby;
	public LobbyView Lobby {
		get {
			return this.lobby = Assert<LobbyView>(this.lobby, true);
		}
	}

	private FightView fight;
	public FightView Fight {
		get {
			return this.fight = Assert<FightView> (this.fight, true);
		}
	}

	private BookFightView bookFight;
	public BookFightView BookFight {
		get {
			return bookFight = Assert<BookFightView>(bookFight, true);
		}
	}

	private HangarView hangar;
	public HangarView Hangar {
		get {
			return hangar = Assert<HangarView>(hangar, true);
		}
	}

	private void Update () {
		if(Input.GetKeyUp(KeyCode.Space)) {
			Messenger.Broadcast("OpenLobby");
			Debug.Log (Fight);
		}
	}
}

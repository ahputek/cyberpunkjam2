using UnityEngine;
using System.Collections;

using Framework.MVC;

public class BookFightView : View<CyberpunkApplication> {

	[SerializeField]
	private BookFightTab[] tabs;

	public void UpdateDisplay (BookFightModel bookFight) {
		for(int i = 0; i < this.tabs.Length; i++) {
			this.tabs[i].UpdateDisplay(bookFight.robotData[i]);
		}
	}

	public void Fight () {
		App.Notify(Constants.START_FIGHT);
	}
}

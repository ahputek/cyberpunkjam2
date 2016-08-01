using UnityEngine;
using System.Collections;

using Framework.MVC;

public class BookFightView : View<CyberpunkApplication> {

	[SerializeField]
	private BookFightTab[] tabs;

	public void UpdateDisplay () {
		for(int i = 0; i < this.tabs.Length; i++) {
			this.tabs[i].UpdateDisplay(App.Model.BookFight.robotData[i]);
		}
	}

	public void UpdateDisplay (BookFightModel bookFight) {
		for(int i = 0; i < this.tabs.Length; i++) {
			this.tabs[i].UpdateDisplay(bookFight.robotData[i]);
		}
	}

	public void Fight (int index) {
		RobotData data = App.Model.BookFight.robotData[index];
		App.Model.Fight.Robots[1].Name = data.Name;
		App.Model.Fight.Robots[1].Accuracy = data.Accuracy;
		App.Model.Fight.Robots[1].Power = data.Power;
		App.Model.Fight.Robots[1].Speed = data.Speed;
		App.Model.Fight.Robots[1].Hardness = data.Hardness;
		App.Model.Fight.Robots[1].Weight = data.Weight;
		App.Model.Fight.Robots[1].Popularity = data.Popularity;

		App.Notify(Constants.START_FIGHT);
		FightSystem.Instance.turn = FightSystem.Turn.START;
	}
}

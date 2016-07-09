using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using Framework.MVC;

namespace Test {
	public class TestView : View<TestApplication> {

		private SampleView sample;
		private ItemView item;
		private Button testButton;
		private string testString;

		public SampleView Sample { 
			get {
				return sample = Assert<SampleView>(sample);
			}
		}

		public ItemView Item {
			get {
				return item = Assert<ItemView> (item);
			}
		}

		private void Update () {
			if (Input.GetKeyUp (KeyCode.Space)) {
				// cache controller
				SampleController sampleController = App.Controller.Sample;

				// cache model
				SampleModel sampleModel = App.Model.Sample;

				// notify app
				App.Notify (Constants.GENERATE, sampleController, sampleModel, TestController.GetRandomName ());
			}

			if (Input.GetKeyUp (KeyCode.Tab)) {

				SampleController sampleController = App.Controller.Sample;

				SampleModel sampleModel = App.Model.Sample;

				App.Notify (Constants.CHANGE, sampleController, sampleModel, TestController.GetRandomColor());
			}

			if (Input.GetMouseButtonUp (0)) {

				ItemController itemController = App.Controller.Item;

				ItemModel itemModel = App.Model.Item;

				App.Notify (Constants.MOUSECLICK, itemController, itemModel, TestController.GetSystemStatus());
			}
		}
	}
}
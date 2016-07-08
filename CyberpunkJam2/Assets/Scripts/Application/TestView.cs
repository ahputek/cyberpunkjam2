﻿using UnityEngine;
using System.Collections;

using Framework.MVC;

namespace Test {
	public class TestView : View<TestApplication> {

		private SampleView sample;
		public SampleView Sample { 
			get {
				return sample = Assert<SampleView>(sample);
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
		}
	}
}
using UnityEngine;
using System.Collections;

using Framework.MVC;

namespace Test {
	public class TestModel : Model<TestApplication> {

		private SampleModel sample;
		public SampleModel Sample {
			get {
				return sample = Assert<SampleModel>(sample);
			}
		}
	}
}
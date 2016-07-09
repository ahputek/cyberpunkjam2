using UnityEngine;
using System.Collections;

using Framework.MVC;

namespace Test {
	public class TestModel : Model<TestApplication> {

		private SampleModel sample;
		private ItemModel item;

		public SampleModel Sample {
			get {
				return sample = Assert<SampleModel>(sample);
			}
		}

		public ItemModel Item {
			get {
				return item = Assert<ItemModel> (item);
			}
		}
	}
}
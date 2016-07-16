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

		private ItemModel item;
		public ItemModel Item {
			get {
				return item = Assert<ItemModel> (item);
			}
		}

		private InventoryModel inventory;
		public InventoryModel Inventory {
			get {
				return inventory = Assert<InventoryModel> (inventory);
			}
		}
	}
}
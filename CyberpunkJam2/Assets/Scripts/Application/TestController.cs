using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using Framework.MVC;

namespace Test {
	public class TestController : Controller<TestApplication> {

		private SampleController sample;
		private ItemController item;

		public SampleController Sample {
			get {
				return sample = Assert<SampleController>(sample);
			}
		}

		public ItemController Item {
			get {
				return item = Assert<ItemController> (item);
			}
		}

		public static string GetRandomName () {
			string[] names = {
				"Don",
				"Ronnie",
				"Shadrach",
				"JM",
				"Will",
				"James",
				"Pao"
			};

			return names[Random.Range(0, names.Length)];
		}

		public static string GetRandomColor() {
			string [] colors = {
				"0",
				"0",
				"0"
			};

			return colors[Random.Range(0, colors.Length)];
		}

		public static bool GetSystemStatus() {
			bool SlotStat = true;

			return SlotStat; 
		}
	}
}
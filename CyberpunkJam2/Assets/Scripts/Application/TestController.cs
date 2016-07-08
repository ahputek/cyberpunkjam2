using UnityEngine;
using System.Collections;

using Framework.MVC;

namespace Test {
	public class TestController : Controller<TestApplication> {

		private SampleController sample;

		public SampleController Sample {
			get {
				return sample = Assert<SampleController>(sample);
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
	}
}
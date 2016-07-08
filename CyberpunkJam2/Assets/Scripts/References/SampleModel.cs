using UnityEngine;
using System.Collections;

using Framework.MVC;
using Test;

public class SampleModel : Model<TestApplication> {

	private string name;
	private string colors;
	/*private int colorsR;
	private int colorsG;
	private int colorsB;*/

	public string Name {
		get {
			return name;
		}
		set {
			name = value;

			// cache view
			SampleView sampleView = App.View.Sample;

			// call OnNameChange everytime when name field is changed
			sampleView.OnNameChange();
		}
	}

	public string Color {
		get {
			return colors;
		}
		set {
			colors = value;
			SampleView sampleView = App.View.Sample;

			sampleView.OnColorChange ();
		}
	}
	/*public int ColorR {
		get {
			return colorsR;
		}
		set {
			colorsR = value;

			SampleView sampleView = App.View.Sample;
		
			sampleView.OnColorChange ();
		}
	}
	public int ColorG {
		get {
			return colorsG;
		}
		set {
			colorsG = value;

			SampleView sampleView = App.View.Sample;

			sampleView.OnColorChange ();
		}
	}
	public int ColorB {
		get {
			return colorsB;
		}
		set {
			colorsB = value;

			SampleView sampleView = App.View.Sample;

			sampleView.OnColorChange ();
		}
	}*/
}
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using System.Collections;

using Framework.MVC;
using Test;

public class SampleView : View<TestApplication> {

	[SerializeField]
	private Text sampleText;

	private void Start () {
		// checks if sampleText is not null, throws an exception if null
		UnityEngine.Assertions.Assert.IsNotNull(this.sampleText);

		// cache model
		SampleModel sample = App.Model.Sample;

		// update display once
		UpdateDisplay(sample);
	}

	// update display once
	private void UpdateDisplay (SampleModel sample) {
		this.sampleText.text = sample.Name;
		Color colors = new Color (255, 255, 255);
		this.sampleText.color = colors;

	}

	private void UpdateTextColor (SampleModel sample){
		Color colors = new Color(0, 0, 0);
		this.sampleText.color = colors;
	}

	// bind to model
	public void OnNameChange () {
		// cache model
		SampleModel sample = App.Model.Sample;

		// update model once
		UpdateDisplay(sample);
	}

	public void OnColorChange () {
		SampleModel sample = App.Model.Sample;

		UpdateTextColor (sample);
	}
}

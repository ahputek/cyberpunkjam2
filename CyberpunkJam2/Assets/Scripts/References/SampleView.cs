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
	}

	// bind to model
	public void OnNameChange () {
		// cache model
		SampleModel sample = App.Model.Sample;

		// update model once
		UpdateDisplay(sample);
	}
}

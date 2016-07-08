using UnityEngine;
using System.Collections;

using Framework.MVC;
using Test;

public class SampleController : Controller<TestApplication> {

	public override void OnNotification (string p_event, Object p_target, params object[] p_data)
	{
		// remove this line if not needed
		base.OnNotification (p_event, p_target, p_data);

		// react if event is a match
		if(p_event.Equals(Constants.GENERATE)) {
			// cache and cast model
			SampleModel sampleModel = (SampleModel) p_data[0];

			// cache and cast new name
			string newName = p_data[1].ToString();

			// set name while injecting dependency to SampleModel
			SetName(sampleModel, newName);
		}

		if (p_event.Equals (Constants.CHANGE)) {

			SampleModel sampleModel = (SampleModel)p_data [0];

			string newColor = p_data [1].ToString ();
			/*string strColorR = p_data[0].ToString();
			string strColorG = p_data[0].ToString();
			string strColorB = p_data[0].ToString();
			int newColorR = int.Parse(strColorR);
			int newColorG = int.Parse(strColorG);
			int newColorB = int.Parse(strColorB);*/

			SetColor(sampleModel, newColor);
		}
	}

	// inverts the control to the SampleModel argument
	public void SetName (SampleModel sample, string name) {
		sample.Name = name;
	}

	public void SetColor (SampleModel sample, string colors/*int colorsR, int colorsG, int colorsB*/) {
		sample.Color = colors;
		/*sample.ColorR = colorsR;
		sample.ColorG = colorsG;
		sample.ColorB = colorsB;*/
	}
}
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuHandler : MonoBehaviour {

	public void Load (string scene) {
		SceneManager.LoadScene(scene);
	}

	public void Quit () {
		Application.Quit();
	}
}

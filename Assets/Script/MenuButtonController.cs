using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtonController : MonoBehaviour {
	public Button[] buttons;

	void Start() {
		//button: 0=play; 1=tutorial; 2=learn; 3=MainMenu
		buttons [0].onClick.AddListener (goMainMenu);
		buttons [1].onClick.AddListener (goPlay);
		buttons [2].onClick.AddListener (goTutorial);
		buttons [3].onClick.AddListener (goLearn);
	}
	void goMainMenu() {
		SceneManager.LoadScene (0);
	}

	void goPlay() {
		SceneManager.LoadScene (1);
	}

	void goTutorial() {
		SceneManager.LoadScene (2);
	}

	void goLearn() {
		SceneManager.LoadScene (3);
	}
}

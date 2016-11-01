using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtonController : MonoBehaviour {
	public Button[] buttons;
    Scene currScene;

	void Start() {
        //button: 0=levels; 1=tutorial; 2=learn; 3=MainMenu
        currScene = SceneManager.GetActiveScene();
        buttons [0].onClick.AddListener (goMainMenu);
		buttons [1].onClick.AddListener (goLevel);
		buttons [2].onClick.AddListener (goTutorial);
		buttons [3].onClick.AddListener (goLearn);
        //to deactivate the button that lead to the same scene as current scene
        for (int i = 0; i < 4; i++)
        {
            if (currScene.buildIndex == i)
            {
                buttons[i].gameObject.SetActive(false);
            }
        }
    }

    void goMainMenu() {
            SceneManager.LoadScene(0);
	}

	void goLevel() {
            SceneManager.LoadScene(1);
	}

	void goTutorial() {       
            SceneManager.LoadScene(2);        
	}

	void goLearn() {
            SceneManager.LoadScene(3);        
	}
    
    
}

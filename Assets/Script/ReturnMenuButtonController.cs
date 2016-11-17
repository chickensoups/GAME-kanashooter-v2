using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnMenuButtonController : MonoBehaviour {

    public Button returnMeunuButton;

    void Start()
    {
        returnMeunuButton.onClick.AddListener(goToMenu);
    }
    public void goToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

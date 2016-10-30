using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController: MonoBehaviour
{
    public Button PlayButton, TutorialButton, LearnButton, MainMenuButton;

    void Start()
    {
        Button btnPlay = PlayButton.GetComponent<Button>();
        Button btnTutorial = TutorialButton.GetComponent<Button>();
        Button btnLearn = LearnButton.GetComponent<Button>();
        Button btnMainMenu = MainMenuButton.GetComponent<Button>();
        btnPlay.onClick.AddListener(Play);
        btnTutorial.onClick.AddListener(Tutorial);
        btnLearn.onClick.AddListener(Learn);
        btnMainMenu.onClick.AddListener(BackToMainMenu);

    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Play()
    {
        SceneManager.LoadScene("Play");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Learn()
    {
        SceneManager.LoadScene("Learn");
    }
}

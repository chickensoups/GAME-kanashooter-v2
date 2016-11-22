using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController: MonoBehaviour
{
    public Button PlayButton, SelectLevelButton, TutorialButton, LearnButton;

    void Start()
    {
        Button btnPlay = PlayButton.GetComponent<Button>();
        Button btnSelectLevel = SelectLevelButton.GetComponent<Button>();
        Button btnTutorial = TutorialButton.GetComponent<Button>();
        Button btnLearn = LearnButton.GetComponent<Button>();

        btnPlay.onClick.AddListener(Play);
        btnSelectLevel.onClick.AddListener(SelectLevel);
        btnTutorial.onClick.AddListener(Tutorial);
        btnLearn.onClick.AddListener(Learn);

    }

    public void Play()
    {
        PlayerDataUtils.loadData();
        LevelUtils.currentLevel = LevelUtils.GetLevel(PlayerDataUtils.playerData.currentLevelIndex);
        SceneManager.LoadScene("Play");
    }

    public void SelectLevel()
    {
        SceneManager.LoadScene("Levels");
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

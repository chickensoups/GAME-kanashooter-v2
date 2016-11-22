using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelUpDialog : MonoBehaviour {

    private Text welcomeMessage;
    private Level level;
    public Button NextLevel, RedoLevel, close;
    // Use this for initialization
    private static DialogManager _instance;

    public static DialogManager instance
    {
        get { return _instance; }
    }


    public void ShowData()
    {
        Button RedoButton = RedoLevel.GetComponent<Button>();
        Button NextButton = NextLevel.GetComponent<Button>();
        Button CloseButton = close.GetComponent<Button>();
        RedoButton.onClick.AddListener(OnRedoButtonClick);
        NextButton.onClick.AddListener(OnNextButtonClick);
        CloseButton.onClick.AddListener(OnCloseButtonClick);
    }


    // Update is called once per frame
    void Update()
    {

    }

    void OnRedoButtonClick()
    {
        Done_GameController.instance.healthbar.GetComponent<HealthbarController>().SetCurrentHealth(100);
        Done_GameController.instance.progressbar.GetComponent<ProgressbarController>().resetProgress();
        LevelUtils.currentLevel = LevelUtils.GetLevel(PlayerDataUtils.playerData.currentLevelIndex);
        gameObject.SetActive(false);
        Done_GameController.instance.Start();
    }

    void OnNextButtonClick()
    {
        Done_GameController.instance.healthbar.GetComponent<HealthbarController>().SetCurrentHealth(100);
        Done_GameController.instance.progressbar.GetComponent<ProgressbarController>().resetProgress();
        PlayerDataUtils.playerData.currentLevelIndex = PlayerDataUtils.playerData.currentLevelIndex + 1;
        PlayerDataUtils.saveData();
        LevelUtils.currentLevel = LevelUtils.GetLevel(PlayerDataUtils.playerData.currentLevelIndex);
        Done_GameController.instance.levelData = LevelUtils.currentLevel;
        BulletTypeScript.instance.answers = LevelUtils.currentLevel.GetAnswers();
        gameObject.SetActive(false);
        Done_GameController.instance.Start();
    }

    public void OnCloseButtonClick()
    {
        gameObject.SetActive(false);
    }
}

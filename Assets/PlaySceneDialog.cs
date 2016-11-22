using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlaySceneDialog : MonoBehaviour {

    private Text welcomeMessage;
    private Level level;
    public GameObject NextLevel, RedoLevel, close;
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
        Debug.Log("ABC");
        SceneManager.LoadScene("Play");
    }

    void OnNextButtonClick()
    {
        Done_GameController.instance.healthbar.GetComponent<HealthbarController>().SetCurrentHealth(100);
        Done_GameController.instance.progressbar.GetComponent<ProgressbarController>().resetProgress();
        LevelUtils.currentLevel = LevelUtils.GetLevel(PlayerDataUtils.playerData.currentLevelIndex + 1);
        gameObject.SetActive(false);
        SceneManager.LoadScene("Play");
    }

    public void OnCloseButtonClick()
    {
        gameObject.SetActive(false);
    }
}

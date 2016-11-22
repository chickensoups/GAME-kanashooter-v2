using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameoverDialog : MonoBehaviour {

    private Text welcomeMessage;
    private Level level;
    public Button RedoLevel, close;
    // Use this for initialization
    private static DialogManager _instance;

    public static DialogManager instance
    {
        get { return _instance; }
    }


    public void ShowData()
    {
        Button RedoButton = RedoLevel.GetComponent<Button>();
        Button CloseButton = close.GetComponent<Button>();

        RedoButton.onClick.AddListener(OnRedoButtonClick);
        CloseButton.onClick.AddListener(OnCloseButtonClick);
    }


    // Update is called once per frame
    void Update()
    {

    }

    void OnRedoButtonClick()
    {
        LevelUtils.currentLevel = LevelUtils.GetLevel(PlayerDataUtils.playerData.currentLevelIndex);
        gameObject.SetActive(false);
        SceneManager.LoadScene("Play");
    }


    public void OnCloseButtonClick()
    {
        gameObject.SetActive(false);
    }
}

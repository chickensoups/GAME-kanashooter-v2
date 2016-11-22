﻿using UnityEngine;
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
        Done_GameController.instance.healthbar.GetComponent<HealthbarController>().SetCurrentHealth(100);
        Done_GameController.instance.progressbar.GetComponent<ProgressbarController>().resetProgress();
        LevelUtils.currentLevel = LevelUtils.GetLevel(PlayerDataUtils.playerData.currentLevelIndex);
        gameObject.SetActive(false);
        Done_GameController.instance.Start();
    }


    public void OnCloseButtonClick()
    {
        gameObject.SetActive(false);
    }
}

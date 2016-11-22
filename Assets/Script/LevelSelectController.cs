using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LevelSelectController : MonoBehaviour
{
    Level[] levels = new Level[50];
    public GameObject levelUnlockedPrefab;
    public GameObject levelLockedPrefab;
    private GameObject highestUnlockedLevel;
    public GameObject infoPanel;
    public static Level currentViewInfoLevel;
    private int currentUnlockedLevel = 1;
    private GameObject levelPrefab;
    // Use this for initialization
    void Start()
    {
        LevelUtils.initLevel();
        PlayerDataUtils.loadData();
        if (PlayerDataUtils.playerData.highestLevelUnlocked != 0)
        {
            currentUnlockedLevel = PlayerDataUtils.playerData.highestLevelUnlocked;
        } 
        

        for (int i = 0; i < LevelUtils.GetLevels().Count; i++)
        {
            CreateSelectLevel(i);
        }
    }
    void CreateSelectLevel(int i)
    {
        levels[i] = new Level();
        levels[i].SetIndex(i);
        if (i < currentUnlockedLevel)
        {
            levels[i].SetIsUnlocked(true);
        }

        if (levels[i].IsUnlocked())
        {
            levelPrefab = Instantiate(levelUnlockedPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            levelPrefab.GetComponentInChildren<Text>().text = i + 1 + "";

            Button btn = levelPrefab.GetComponent<Button>();
            btn.onClick.AddListener(OnButtonClick);

            Button btnInfo = levelPrefab.GetComponentsInChildren<Button>()[1];
            btnInfo.onClick.AddListener(OnButtonInfoClick);
        }
        else
        {
            levelPrefab = Instantiate(levelLockedPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        }
        if (i == currentUnlockedLevel - 1)
        {
            highestUnlockedLevel = levelPrefab;
        }
        levelPrefab.transform.SetParent(transform);
        levelPrefab.transform.localScale = new Vector3(1, 1);
        if (i == LevelUtils.GetLevels().Count - 1 || i == LevelUtils.GetLevels().Count - 2)
        {
            levelPrefab.GetComponent<Image>().color = Color.red;
        }
    }
    void OnButtonClick()
    {
        
        int levelNumber = Int32.Parse(EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text);
        LevelUtils.currentLevel = LevelUtils.GetLevel(levelNumber);
        PlayerDataUtils.playerData.currentLevelIndex = levelNumber;
        PlayerDataUtils.saveData();
        SceneManager.LoadScene("Play");
    }
    void OnButtonInfoClick()
    {
        infoPanel.SetActive(true);
        GameObject goParent = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;
        int levelNumber = Int32.Parse(goParent.GetComponentInChildren<Text>().text);
        Debug.Log(levelNumber);
        currentViewInfoLevel= LevelUtils.GetLevel(levelNumber);
        infoPanel.GetComponent<DialogManager>().ShowData();
    }
}



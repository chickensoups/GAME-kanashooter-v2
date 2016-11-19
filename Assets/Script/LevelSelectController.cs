using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelSelectController : MonoBehaviour
{
    Level[] levels = new Level[50];
    public GameObject levelUnlockedPrefab;
    public GameObject levelLockedPrefab;
    private GameObject highestUnlockedLevel;

    // Use this for initialization
    void Start()
    {
        LevelUtils.initLevel();
        int currentUnlockedLevel = 10;
        for (int i = 0; i < 20; i++)
        {
            GameObject levelPrefab;
            levels[i] = new Level();
			levels[i].SetIndex(i) ;
            if (i < currentUnlockedLevel)
            {
				levels[i].SetIsUnlocked(true);
            }


			if (levels[i].IsUnlocked())
            {
                levelPrefab = Instantiate(levelUnlockedPrefab, Vector3.zero, Quaternion.identity) as GameObject;
                levelPrefab.GetComponentInChildren<Text>().text = i + 1+"";
           
            }
            else
            {
                levelPrefab = Instantiate(levelLockedPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            }
            if (i == currentUnlockedLevel - 1)
            {
                highestUnlockedLevel = levelPrefab;
            }
            levelPrefab.transform.parent = transform;
            levelPrefab.transform.localScale = new Vector3(1, 1);
            Button btn = levelPrefab.GetComponent<Button>();
            btn.onClick.AddListener(OnButtonClick);

            
        }

    }
    void OnButtonClick()
    {
        int levelNumber = Int32.Parse(EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text);
        LevelUtils.currentLevel = LevelUtils.GetLevel(levelNumber);
        SceneManager.LoadScene("Play");
        PlayerDataUtils.saveData();
    }
  
}



﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelSelectController : MonoBehaviour
{
    Level[] levels = new Level[50];
    public GameObject levelUnlockedPrefab;
    public GameObject levelLockedPrefab;
    private GameObject highestUnlockedLevel;
    // Use this for initialization
    void Start()
    {
        int currentUnlockedLevel = 10;
        for (int i = 0; i < 50; i++)
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
            Button btn = levelPrefab.GetComponent<Button>();
            btn.onClick.AddListener(OnButtonClick);
        }

      //  Vector3 positionScroll = highestUnlockedLevel.transform.position;
     //   GetComponent<RectTransform>().position = new Vector3(transform.position.x,270, transform.position.z) ;
 

    }
    void OnButtonClick()
    {
        Debug.Log("It works");
        //To do ...
    }
   
}



using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class DialogManager : MonoBehaviour {
    private Button btnClose;
    private Text welcomeMessage;
    private Level level;
    public GameObject answerPrefab;
    public GameObject questionPrefab;
    public Transform questionsTransform;
    public Transform answersTransform;
	// Use this for initialization
	void Start () {
        level = LevelSelectController.currentViewInfoLevel;
        btnClose = GetComponentInChildren<Button>();
        btnClose.onClick.AddListener(OnCloseButton);
        GetComponentsInChildren<Text>()[1].text = level.GetWelcomeMessage();
        Debug.Log(GetComponentInChildren<Text>().text);
       
        

        for (int i = 0; i < level.GetAnswers().Count; i++)
        {
            GameObject answerTemp;
            answerTemp = Instantiate(answerPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            answerTemp.transform.SetParent(answersTransform);
            answerTemp.transform.localScale = new Vector3(1,1);
            answerTemp.GetComponentInChildren<Text>().text = level.GetAnswers()[i];
        }

        for (int i = 0; i < level.GetAnswers().Count; i++)
        {
            GameObject questionTemp;
            questionTemp =  Instantiate(questionPrefab,Vector3.zero,Quaternion.identity) as GameObject;
            questionTemp.transform.SetParent(questionsTransform);
            questionTemp.transform.localScale = new Vector3(1, 1);
            questionTemp.GetComponentInChildren<Text>().text = level.GetAnswers()[i];
        }
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCloseButton()
    {
        gameObject.SetActive(false);
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
public class DialogManager : MonoBehaviour {
    private Button btnClose;
    private Text welcomeMessage;
    private Level level;
    public GameObject answerPrefab;
    public GameObject questionPrefab;
    public Transform questionsTransform;
    public Transform answersTransform;
    // Use this for initialization
    private static DialogManager _instance;

    public static DialogManager instance
    {
        get { return _instance; }
    }

    public GameObject currentTarget;

    public void ShowData()
    {

        foreach(Transform child in answersTransform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in questionsTransform)
        {
            Destroy(child.gameObject);
        }

       
        level = LevelSelectController.currentViewInfoLevel;
        btnClose = GetComponentInChildren<Button>();
        btnClose.onClick.AddListener(OnCloseButtonClick);
        GetComponentsInChildren<Text>()[1].text = level.GetWelcomeMessage();
        Debug.Log(GetComponentInChildren<Text>().text);



        for (int i = 0; i < level.GetAnswers().Count; i++)
        {
            GameObject answerTemp;
            answerTemp = Instantiate(answerPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            answerTemp.transform.SetParent(answersTransform);
            answerTemp.transform.localScale = new Vector3(1, 1);
            answerTemp.GetComponentInChildren<Text>().text = level.GetAnswers()[i];
            Debug.Log(level.GetAnswers()[i]);


            AudioSource audioSource = answerTemp.AddComponent<AudioSource>();
            audioSource.clip = Resources.Load("sound/pronunciation/"+level.GetAnswers()[i]) as AudioClip;
            Button btn = answerTemp.GetComponent<Button>();
            btn.onClick.AddListener(OnAnswerButtonClick);
        }

        for (int i = 0; i < level.GetAnswers().Count; i++)
        {
            GameObject questionTemp;
            questionTemp = Instantiate(questionPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            questionTemp.transform.SetParent(questionsTransform);
            questionTemp.transform.localScale = new Vector3(1, 1);
            questionTemp.GetComponentInChildren<Text>().text = level.GetQuestions()[i];

            AudioSource audioSource = questionTemp.AddComponent<AudioSource>();
            audioSource.clip = Resources.Load("sound/pronunciation/" + level.GetAnswers()[i]) as AudioClip;
            Button btn = questionTemp.GetComponent<Button>();
            btn.onClick.AddListener(OnAnswerButtonClick);
        }
    }
	
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCloseButtonClick()
    {
        level = LevelSelectController.currentViewInfoLevel;
        gameObject.SetActive(false);
    }
    void OnAnswerButtonClick()
    {
        GameObject btn = EventSystem.current.currentSelectedGameObject;
        AudioSource clip = btn.GetComponent<AudioSource>();
        clip.Play();
    }
}

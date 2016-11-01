using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class HomeResumeButtonController : MonoBehaviour {
    //home button is the small button at high right conner
    //Resume button is the whole screen + make the screen darker
    public Button HomeButton, ResumeButton;
    public GameObject MenuPanel;
    void Start()
    {
        ResumeButton.gameObject.SetActive(false);
        HomeButton.onClick.AddListener(openMenuPanel);
    }
    void Update()
    {   
        //to make sure that newly activated buttons work properly
        if(HomeButton.gameObject.activeInHierarchy)
        {
            HomeButton.onClick.AddListener(openMenuPanel);
        }
        if(ResumeButton.gameObject.activeInHierarchy)
        {
            ResumeButton.onClick.AddListener(closeMenuPanel);
        }
    }
    void openMenuPanel()
    {
        MenuPanel.SetActive(true);
        //deactivate Home button, activate Resume button
        HomeButton.gameObject.SetActive(false);
        ResumeButton.gameObject.SetActive(true);
        //Pause scene
        Time.timeScale = 0;
    }
    void closeMenuPanel()
    {
        MenuPanel.SetActive(false);
        //deactivate Resume button, activate Home button
        HomeButton.gameObject.SetActive(true);
        ResumeButton.gameObject.SetActive(false);
        //Stop pausing scene
        Time.timeScale = 1;
    }
}

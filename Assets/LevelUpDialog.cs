using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelUpDialog : MonoBehaviour {

    private Text welcomeMessage;
    private Level level;
    public Button NextLevel, RedoLevel, close;

    public GameObject explosion;
    // Use this for initialization
    private static DialogManager _instance;

    public static DialogManager instance
    {
        get { return _instance; }
    }


    public void ShowData()
    {
        for (int i = 0; i < 300; i++)
        {
            Vector3 pos = new Vector3(Done_GameController.instance.transform.position.x + Random.Range(-100, 100), Done_GameController.instance.transform.position.y, Done_GameController.instance.transform.position.z + Random.Range(-100, 100));
            Instantiate(explosion, pos, Quaternion.identity);
        }
        Button RedoButton = RedoLevel.GetComponent<Button>();
        Button NextButton = NextLevel.GetComponent<Button>();
        Button CloseButton = close.GetComponent<Button>();
        RedoButton.onClick.AddListener(OnRedoButtonClick);
        NextButton.onClick.AddListener(OnNextButtonClick);
        CloseButton.onClick.AddListener(OnCloseButtonClick);
        StartCoroutine(explosionAnimate());
    }


    // Update is called once per frame
    IEnumerator explosionAnimate()
    {
        yield return new WaitForSeconds(0.01f);
        while (true)
        {
            Vector3 pos = new Vector3(Done_GameController.instance.transform.position.x + Random.Range(-20, 20), Done_GameController.instance.transform.position.y, Done_GameController.instance.transform.position.z + Random.Range(-20, 20));
            Instantiate(explosion, pos, Quaternion.identity);
            yield return new WaitForSeconds(0.01f);
            if (!gameObject.activeSelf)
            {
                break;
            }

        }
    }

    void OnRedoButtonClick()
    {
        LevelUtils.currentLevel = LevelUtils.GetLevel(PlayerDataUtils.playerData.currentLevelIndex);
        gameObject.SetActive(false);
        SceneManager.LoadScene("Play");
    }

    void OnNextButtonClick()
    {
        PlayerDataUtils.playerData.currentLevelIndex = PlayerDataUtils.playerData.currentLevelIndex + 1;
        LevelUtils.currentLevel = LevelUtils.GetLevel(PlayerDataUtils.playerData.currentLevelIndex);
        PlayerDataUtils.saveData();
        SceneManager.LoadScene("Play");
        gameObject.SetActive(false);
    }

    public void OnCloseButtonClick()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }
}

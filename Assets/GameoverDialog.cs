using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameoverDialog : MonoBehaviour {

    private Text welcomeMessage;
    private Level level;
    public Button RedoLevel, close;

    public GameObject explosion;
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
        StartCoroutine(explosionAnimate());
    }


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


    public void OnCloseButtonClick()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }
}

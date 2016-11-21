using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Done_GameController : MonoBehaviour
{
    public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float startWait;
	
	public GUIText gameOverText;

    public int index;
    private string name;
    private string welcomeMessage;
    public List<string> questions;
    public List<string> answers;
    private int enemyEachWaveCount;
    private float waveWait;
    private float spawnWait;
    private bool isRotate;
    private bool isFaster;

    public static int levelNumber;

    private static Done_GameController _instance;

    public GameObject progressbar, healthbar;


    public static Done_GameController instance
    {
        get { return _instance; }
    }

    void Awake()
    {
        _instance = this;
    }

    void Start ()
    {
        Level levelData = LevelUtils.currentLevel;
        index = levelData.GetIndex();
        name = levelData.GetName();
        welcomeMessage = levelData.GetWelcomeMessage();
        answers = levelData.GetAnswers();
        questions = levelData.GetQuestions();
        enemyEachWaveCount = levelData.GetEnemyEachWaveCount();
        waveWait = levelData.GetWaveWait();
        spawnWait = levelData.GetSpawnWait();
        isRotate = levelData.IsRotate();
        isFaster = levelData.IsFaster();
		gameOverText.text = "";

        StartCoroutine (SpawnWaves ());
        StartCoroutine(RegenHealthbar());
    }

    void Update ()
	{
	    if (healthbar.GetComponent<HealthbarController>().GetCurrentHealth() <= 0)
	    {
	        gameOverText.text = "Game Over!!!";
	    }
	    if (progressbar.GetComponent<ProgressbarController>().GetCurrentPoint() >= progressbar.GetComponent<ProgressbarController>().GetWinPoint3())
	    {
	        gameOverText.text = "Level up!!!";
	        PlayerDataUtils.playerData.highestLevelUnlocked = LevelUtils.currentLevel.GetIndex();
	    }
    }

    IEnumerator RegenHealthbar()
    {
        yield return new WaitForSeconds(1);
        while (true)
        {
            healthbar.GetComponent<HealthbarController>().regenHealth();
            yield return new WaitForSeconds(1);
            if (gameOverText.text.Equals("Game Over!!!") || gameOverText.text.Equals("Level up!!!"))
            {
                break;
            }

        }
    }
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				GameObject enemy = Instantiate (hazard, spawnPosition, spawnRotation) as GameObject;
			    int randomIndex = Random.Range(0, questions.Count);
                enemy.GetComponentInChildren<TextMesh>().text = questions[randomIndex];
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

		    if (gameOverText.text.Equals("Game Over!!!") || gameOverText.text.Equals("Level up!!!"))
		    {
		        break;
		    }
			
		}
	}
	
	
	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
	}

    public void OnApplicationQuit()
    {
        PlayerDataUtils.saveData();
    }

    public void OnApplicationFocus(bool focusStatus)
    {
        if (!focusStatus)
        {
            PlayerDataUtils.saveData();
        }
    }
}
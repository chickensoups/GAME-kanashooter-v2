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
    public GameObject LevelUpPanel, GameoverPanel;
	
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
    private bool isStop = false;

    public GameObject explosion;

    public static int levelNumber;

    private static Done_GameController _instance;

    public GameObject progressbar, healthbar;

    public Level levelData;


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
        levelData = LevelUtils.currentLevel;
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

        StartCoroutine (SpawnWaves ());
        StartCoroutine(RegenHealthbar());
    }

    void Update ()
	{
	    if (healthbar.GetComponent<HealthbarController>().GetCurrentHealth() <= 0)
	    {
            GameoverPanel.SetActive(true);
            GameoverPanel.GetComponent<GameoverDialog>().ShowData();
	        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
	        for (int i = 0; i < 10; i++)
	        {
                Vector3 pos = new Vector3(transform.position.x + Random.Range(-100, 100), transform.position.y, transform.position.z + Random.Range(-100, 100));
                Instantiate(explosion, pos, Quaternion.identity);
	        }
	        for (int i = 0; i < enemies.Length; i++)
	        {
	            Destroy(enemies[i]);
	        }
            isStop = true;
	    }
	    if (progressbar.GetComponent<ProgressbarController>().GetCurrentPoint() >= progressbar.GetComponent<ProgressbarController>().GetWinPoint3())
	    {
            isStop = true;
	        if (PlayerDataUtils.playerData.highestLevelUnlocked <= LevelUtils.currentLevel.GetIndex())
	        {
	            PlayerDataUtils.playerData.highestLevelUnlocked = LevelUtils.currentLevel.GetIndex() + 1;

	        }
	        PlayerDataUtils.saveData();
            LevelUpPanel.SetActive(true);
            LevelUpPanel.GetComponent<LevelUpDialog>().ShowData();
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < enemies.Length; i++)
            {
                Destroy(enemies[i]);
            }
        }
    }

    IEnumerator RegenHealthbar()
    {
        yield return new WaitForSeconds(1);
        while (true)
        {
            healthbar.GetComponent<HealthbarController>().regenHealth();
            yield return new WaitForSeconds(1);
            if (isStop)
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

		    if (isStop)
		    {
		        break;
		    }
		}
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
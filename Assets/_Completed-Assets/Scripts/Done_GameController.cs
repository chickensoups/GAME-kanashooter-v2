using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Done_GameController : MonoBehaviour
{
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	
	public GUIText gameOverText;

    public List<string> questions = new List<string>(new[] {"あ", "い", "う", "え", "お" });
    public List<string> answers = new List<string>(new[] { "a", "i", "u", "e", "o" });

    private bool gameOver;
	private bool restart;
	private int score;

    private static Done_GameController _instance;

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
		gameOver = false;
		restart = false;
		gameOverText.text = "";
		score = 0;
		StartCoroutine (SpawnWaves ());
	}
	
	void Update ()
	{
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
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
			
			if (gameOver)
			{
				restart = true;
				break;
			}
		}
	}
	
	
	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
}
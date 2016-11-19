using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Level
{
	private int index;
    private string name;
    private string welcomeMessage;
    private List<string> questions;
    private List<string> answers;
    private int enemyEachWaveCount;
    private float waveWait;
    private float spawnWait;
    private bool isRotate;
    private bool isFaster;
	private bool isUnlocked;

    public Level()
    {

    }

    public Level(int index, string name, string welcomeMessage, List<string> questions, List<string> answers,int enemyEachWaveCount, float waveWait, float spawnWait, bool isRotate, bool isFaster)
    {
        this.index = index;
        this.name = name;
        this.welcomeMessage = welcomeMessage;
        this.questions = questions;
        this.answers = answers;
        this.enemyEachWaveCount = enemyEachWaveCount;
        this.waveWait = waveWait;
        this.spawnWait = spawnWait;
        this.isRotate = isRotate;
        this.isFaster = isFaster;
    }

    public int GetIndex()
    {
        return index;
    }

    public List<string> GetQuestions()
    {
        return questions;
    }

    public List<string> GetAnswers()
    {
        return answers;
    }

    public float GetWaveWait()
    {
        return waveWait;
    }

    public float GetSpawnWait()
    {
        return spawnWait;
    }

    public int GetEnemyEachWaveCount()
    {
        return enemyEachWaveCount;
    }

    public bool IsRotate()
    {
        return isRotate;
    }

    public bool IsFaster()
    {
        return isFaster;
    }

    public string GetName()
    {
        return name;
    }

    public string GetWelcomeMessage()
    {
        return welcomeMessage;
    }

	public bool IsUnlocked(){
		return isUnlocked;
	}

	public void SetIndex(int index){
		this.index = index;
	}

	public void SetIsUnlocked(bool state){
		isUnlocked = state;
	}
}


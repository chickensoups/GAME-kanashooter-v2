using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProgressAndBarrierHealthBarController : MonoBehaviour {

	//PROGRESS BAR CONTROLLER
	public Image currentProgressBar;
	public Image[] Stars;

	private float currentpoint = 0;
	private float winPoint1 = 5;
	private float winPoint2 = 10;
	private float winPoint3 = 15;

	private void UpdateProgressBar(){
		float ratio = currentpoint / winPoint3;
		currentProgressBar.rectTransform.localScale = new Vector3 (ratio,1,1);
		if (currentpoint == winPoint1) {
			Stars [0].GetComponent<Image>().color = new Color(1,1,1,255);
		}if (currentpoint == winPoint2) {
			Stars [1].GetComponent<Image>().color = new Color(1,1,1,255);;
		}if (currentpoint == winPoint3) {
			Stars [2].GetComponent<Image>().color = new Color(1,1,1,255);;
		}
	}

	public void increaseProgress(float increasePoint){
		currentpoint += increasePoint;
		UpdateProgressBar();
	}

	public void decreaseProgress(float decreasePoint){
		currentpoint -= decreasePoint;
		UpdateProgressBar();
	}

	public float GetCurrentPoint(){
		return currentpoint;
	}

	public float GetWinPoint3(){
		return winPoint3;
	}

	//BARRIER HEALTH BAR CONTROLLER
	public Image currentHealthBar;

	private float currentHealth = 100;
	private float fullHealth = 100;

	private void UpdateHealthBar(){
		float ratio = currentHealth / fullHealth;
		currentHealthBar.rectTransform.localScale = new Vector3 (ratio,1,1);
	}

	public void increaseHealth(float increasePoint){
		currentHealth += increasePoint;
		UpdateHealthBar();
	}

	public void regenHealth(){
		increaseHealth (1);
	}

	public void decreaseHealth(float decreasePoint){
		currentHealth -= decreasePoint;
		UpdateHealthBar();
	}

	public float GetCurrentHealth(){
		return currentHealth;
	}

	public float GetFullHealth(){
		return fullHealth;
	}


}

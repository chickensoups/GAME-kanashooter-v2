using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthbarController : MonoBehaviour {

    public Image currentHealthBar;

	private float currentHealth = 100;
	private float fullHealth = 100;

	private void UpdateHealthBar(){
		float ratio = currentHealth / fullHealth;
	    GetComponentInChildren<Text>().text = currentHealth.ToString();
		currentHealthBar.rectTransform.localScale = new Vector3 (ratio,1,1);
	}

	public void increaseHealth(float increasePoint){
		currentHealth += increasePoint;
		UpdateHealthBar();
	}

	public void regenHealth(){
	    if (currentHealth < 100)
	    {
            increaseHealth(1);
        }
	}

	public void decreaseHealth(float decreasePoint){
		currentHealth -= decreasePoint;
		UpdateHealthBar();
	}

	public float GetCurrentHealth(){
		return currentHealth;
	}

    public void SetCurrentHealth(float currentHealth)
    {
        this.currentHealth = currentHealth;
    }

    public float GetFullHealth(){
		return fullHealth;
	}


}

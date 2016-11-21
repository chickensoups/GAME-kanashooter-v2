using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Done_DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
    public GameObject scoreAnimationText;
    public GameObject progressAnimationText;
    public int scoreValue;
	private Done_GameController gameController;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <Done_GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Boundary" || other.tag == "Enemy" || other.tag == "EnemyBolt")
		{
			return;
		}

		if (other.tag == "Barrier")
		{
		    if (explosion != null)
		    {
		        Instantiate(explosion, transform.position, transform.rotation);
		    }
            Done_GameController.instance.healthbar.GetComponent<HealthbarController>().decreaseHealth(5);
            Vector3 positionScore = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
            GameObject scoreTextAnimation = (GameObject) Instantiate(scoreAnimationText, positionScore, Quaternion.identity);
            scoreTextAnimation.GetComponentInChildren<TextMesh>().color = Color.red;
            scoreTextAnimation.GetComponentInChildren<TextMesh>().text = "-" + 5;
            Destroy(gameObject);
        }

	    if (other.tag == "Bolt" && gameObject.tag != "EnemyBolt")
	    {
            Destroy(other.gameObject);
	        Instantiate(explosion, transform.position, transform.rotation);
	        if (other.GetComponentInChildren<TextMesh>().text ==
	            Done_GameController.instance.answers[
	                Done_GameController.instance.questions.IndexOf(gameObject.GetComponentInChildren<TextMesh>().text)])
	        {
	            Instantiate(explosion, transform.position, transform.rotation);
                GameObject progressAnimation = (GameObject) Instantiate(progressAnimationText, transform.position, Quaternion.identity);
	            progressAnimation.GetComponentInChildren<TextMesh>().text = scoreValue.ToString();
	            progressAnimation.GetComponentInChildren<TextMesh>().color = Color.green;
                Done_GameController.instance.progressbar.GetComponent<ProgressbarController>().increaseProgress(scoreValue);
	            Destroy(gameObject);
	            Destroy(other.gameObject);
	        }
	        else
	        {
                Done_GameController.instance.progressbar.GetComponent<ProgressbarController>().resetProgress();
            }
	    }
        
	}

    void OnDestroy()
    {
        if (gameObject == Done_PlayerController.instance.currentTarget)
        {
            Done_PlayerController.instance.currentTarget = null;
        }
    }
}
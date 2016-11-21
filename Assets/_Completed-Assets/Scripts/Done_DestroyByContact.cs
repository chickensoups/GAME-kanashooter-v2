using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Done_DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
    public GameObject smallStar;
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
<<<<<<< HEAD
                GameObject scoreTextAnimation = (GameObject)Instantiate(scoreAnimationText, transform.position, Quaternion.identity);
                scoreTextAnimation.GetComponentInChildren<TextMesh>().color = Color.yellow;
                Instantiate(smallStar, transform.position,new Quaternion());
                if (gameObject.name == "EnemyShip(Clone)")
	            {
                    scoreTextAnimation.GetComponentInChildren<TextMesh>().text = "+" + 2;
                    Done_GameController.instance.progressbar.GetComponent<ProgressbarController>().increaseProgress(2);
                }
	            else
	            {
                    scoreTextAnimation.GetComponentInChildren<TextMesh>().text = "+" + 1;
                    Done_GameController.instance.progressbar.GetComponent<ProgressbarController>().increaseProgress(1);
                }
=======
                GameObject progressAnimation = (GameObject) Instantiate(progressAnimationText, transform.position, Quaternion.identity);
	            progressAnimation.GetComponentInChildren<TextMesh>().text = scoreValue.ToString();
	            progressAnimation.GetComponentInChildren<TextMesh>().color = Color.green;
                Done_GameController.instance.progressbar.GetComponent<ProgressbarController>().increaseProgress(scoreValue);
>>>>>>> 39c1efcd343cef7455bf52c1f98d8c07c4e9732c
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
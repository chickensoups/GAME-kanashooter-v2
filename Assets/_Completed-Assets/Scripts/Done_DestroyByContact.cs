using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Done_DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
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
		if (other.tag == "Boundary" || other.tag == "Enemy")
		{
			return;
		}

		if (other.tag == "Barrier")
		{
		    if (explosion != null)
		    {
		        Instantiate(explosion, transform.position, transform.rotation);
		    }
            Destroy(gameObject);
        }

	    if (other.tag == "Bolt")
	    {
            Destroy(other.gameObject);
	        Instantiate(explosion, transform.position, transform.rotation);
	        if (other.GetComponentInChildren<TextMesh>().text == Done_GameController.instance.answers[Done_GameController.instance.questions.IndexOf(gameObject.GetComponentInChildren<TextMesh>().text)])
	        {
	            Instantiate(explosion, transform.position, transform.rotation);
                Destroy(gameObject);
                Destroy(other.gameObject);
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
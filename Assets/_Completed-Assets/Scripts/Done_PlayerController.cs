using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class Done_Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class Done_PlayerController : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Done_Boundary boundary;

	public GameObject shot;

	public Transform shotSpawn;
	public float fireRate;
	 
    private static Done_PlayerController _instance;
    
    public static Done_PlayerController instance
    {
        get { return _instance; }
    }

    public GameObject currentTarget;
    public static string currentBulletType;

    void Awake()
    {
        _instance = this;
    }

	void Update ()
	{
		if (currentTarget != null && currentBulletType != null) 
		{
			GameObject ShotClone = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
		    ShotClone.GetComponentInChildren<TextMesh>().text = currentBulletType;
			GetComponent<AudioSource>().Play ();
		    currentBulletType = null;
		}
	}

	void FixedUpdate ()
	{
	    if (currentTarget == null )
	    {
            return;
        }

	    float enemyPositionX = currentTarget.transform.position.x;
	    if (Mathf.Abs(transform.position.x - enemyPositionX) < 0.5)
	    {
	        transform.position = new Vector3(enemyPositionX, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.identity;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            return;
        }
        if (transform.position.x < enemyPositionX)
	    {
	        GetComponent<Rigidbody>().velocity = new Vector3(speed, 0.0f, 0.0f);
	    }
	    else
	    {
            GetComponent<Rigidbody>().velocity = new Vector3(-speed, 0.0f, 0.0f);
        }
		
		GetComponent<Rigidbody>().position = new Vector3
		(
			Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
		);
		
		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}
}

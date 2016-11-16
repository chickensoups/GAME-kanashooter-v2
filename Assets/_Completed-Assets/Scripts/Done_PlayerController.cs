using UnityEngine;
using System.Collections;

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
	 
	private float nextFire;

    private static Done_PlayerController _instance;
    
    public static Done_PlayerController instance
    {
        get { return _instance; }
    }

    public GameObject currentTarget, currentBulletType;

    void Awake()
    {
        _instance = this;
    }

	void Update ()
	{
		if (currentTarget != null && currentBulletType != null && Time.time > nextFire) 
		{
            nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource>().Play ();
		}
	}

	void FixedUpdate ()
	{
	    float enemyPositionX = currentTarget.transform.position.x;
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

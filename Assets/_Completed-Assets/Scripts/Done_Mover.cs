using UnityEngine;
using System.Collections;

public class Done_Mover : MonoBehaviour
{
	public float speed;

	void Start ()
	{
		GetComponentsInChildren<Rigidbody>()[0].velocity = transform.forward * speed;
	    if (GetComponentsInChildren<Rigidbody>().Length > 1)
	    {
            GetComponentsInChildren<Rigidbody>()[1].velocity = transform.forward * speed;
        }
        
    }
}

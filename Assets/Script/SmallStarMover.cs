using UnityEngine;
using System.Collections;

public class SmallStarMover : MonoBehaviour {

    public float speed;

    void Update()
    {
        GetComponent<Rigidbody2D>().transform.Translate(transform.forward*Time.deltaTime*speed);
        if(GetComponent<Rigidbody2D>().transform.position.z >= 14)
        {
            Destroy(gameObject);
        }
    }
}

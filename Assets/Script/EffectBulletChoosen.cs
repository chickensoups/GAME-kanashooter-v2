using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class EffectBulletChoosen : MonoBehaviour {
    public GameObject explosion;
	// Use this for initialization
	void Start () {
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
	}

     void  OnButtonClick()
    {
        Instantiate(explosion, transform.position, transform.rotation);
    }
	// Update is called once per frame
	void Update () {
	
	}
}

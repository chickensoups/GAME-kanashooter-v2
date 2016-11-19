using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Script;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BulletTypeScript : MonoBehaviour
{

    public GameObject BulletTypePrefabs;
    public List<string> answer = new List<string>(new[] { "a", "i", "u", "e", "o" });

    // Use this for initialization
    void Start () {
	    for (int i = 0; i < answer.Count; i++)
	    {
	        GameObject BulletType = Instantiate(BulletTypePrefabs, Vector3.zero, Quaternion.identity) as GameObject;
            BulletType.transform.parent = transform;
            BulletType.transform.localScale = new Vector3(1, 1);
	        BulletType.name = answer[i];
	        BulletType.GetComponentInChildren<Text>().text = answer[i];
	    }
	    GameObject[] BulletTypeButtons = GameObject.FindGameObjectsWithTag("BulletType");
	    for (int i = 0; i < BulletTypeButtons.Length; i++)
	    {
	        Button btn = BulletTypeButtons[i].GetComponent<Button>();
            btn.onClick.AddListener(ChooseBulletType);

	    }
	}

    private void ChooseBulletType()
    {
        string bulletTypeString = EventSystem.current.currentSelectedGameObject.name;
        Done_PlayerController.currentBulletType = bulletTypeString;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

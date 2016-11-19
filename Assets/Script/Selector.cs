using UnityEngine;
using System.Collections;

public class Selector : MonoBehaviour {

    void OnMouseDown()
    {
        Debug.Log(gameObject.GetComponentInChildren<TextMesh>().text);
        Done_PlayerController.instance.currentTarget = gameObject;
    }
}

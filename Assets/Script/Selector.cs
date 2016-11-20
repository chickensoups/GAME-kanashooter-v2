using UnityEngine;
using System.Collections;

public class Selector : MonoBehaviour {

    void OnMouseDown()
    {
        Done_PlayerController.instance.currentTarget = gameObject;
    }
}

using System;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KanaScript : MonoBehaviour
{
    void Start()
    {
        GameObject[] characters = GameObject.FindGameObjectsWithTag("Character");
        for (int i = 0; i < characters.Length; i++)
        {
            Button btn = characters[i].GetComponent<Button>();
            btn.onClick.AddListener(ClickCharacter);
        }
    }

    void ClickCharacter()
    {

        String character = EventSystem.current.currentSelectedGameObject.name.ToLower();
        
        AudioClip audio = Resources.Load<AudioClip>("sound/pronunciation/" + character);
        AudioSource.PlayClipAtPoint(audio, new Vector3(0, 0, 0) );
    }

}

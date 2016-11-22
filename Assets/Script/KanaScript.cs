using System;
using UnityEngine;
using System.Collections;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KanaScript : MonoBehaviour
{
    public Button HiraganaTab, KatakanaTab;
    public GameObject prefabs;
    public static string[] ROMA_CHARS = { "a", "i", "u", "e", "o", "ka", "ki", "ku", "ke", "ko", "sa", "shi", "su", "se", "so", "ta", "chi", "tsu", "te", "to", "na", "ni", "nu", "ne", "no", "ha", "hi", "fu", "he", "ho", "ma", "mi", "mu", "me", "mo", "ya", ".", "yu", ".", "yo", "ra", "ri", "ru", "re", "ro", "wa", ".", "n", ".", "wo" };
    public static string[] HIRA_CHARS = { "あ", "い", "う", "え", "お", "か", "き", "く", "け", "こ", "さ", "し", "す", "せ", "そ", "た", "ち", "つ", "て", "と", "な", "に", "ぬ", "ね", "の", "は", "ひ", "ふ", "へ", "ほ", "ま", "み", "む", "め", "も", "や", ".", "ゆ", ".", "よ", "ら", "り", "る", "れ", "ろ", "わ", ".", "ん", ".", "を"};
    public static string[] KATA_CHARS = { "ア", "イ", "ウ", "エ", "オ", "カ", "キ", "ク", "ケ", "コ", "サ", "シ", "ス", "セ", "ソ", "タ", "チ", "ツ", "テ", "ト", "ナ", "ニ", "ヌ", "ネ", "ノ", "ハ", "ヒ", "フ", "ヘ", "ホ", "マ", "ミ", "ム", "メ", "モ", "ヤ", ".", "ユ", ".", "ヨ", "ラ", "リ", "ル", "レ", "ロ", "ワ", ".", "ン", ".", "ヲ" };

    void Start()
    {
        HiraganaTab.GetComponent<Button>();
        KatakanaTab.GetComponent<Button>();
        initTable();
        HiraganaTab.onClick.AddListener(clickHiraganaButton);
        KatakanaTab.onClick.AddListener(clickKatakanaButton);
        GameObject[] characters = GameObject.FindGameObjectsWithTag("Character");
        for (int i = 0; i < characters.Length; i++)
        {
            Button btn = characters[i].GetComponent<Button>();
            btn.onClick.AddListener(ClickCharacter);
        }
    }

    void ClickCharacter()
    {

        String character = EventSystem.current.currentSelectedGameObject.name;
        AudioClip audio = Resources.Load<AudioClip>("sound/pronunciation/" + character);
        AudioSource.PlayClipAtPoint(audio, new Vector3(0, 0, 0), 0.5f);
    }

    void initTable()
    {
        
       // HiraganaTab.image.color = new Color(25,118,210, 255);
        HiraganaTab.image.color = Color.green;
        for (int i = 0; i < ROMA_CHARS.Length; i++)
        {
            if (ROMA_CHARS[i] != ".")
            {
                GameObject kana = Instantiate(prefabs, Vector3.zero, Quaternion.identity) as GameObject;
                kana.transform.SetParent(transform);
                kana.transform.localScale = new Vector3(1, 1);
                kana.name = ROMA_CHARS[i];
                kana.GetComponentsInChildren<Text>()[0].text = HIRA_CHARS[i];
                kana.GetComponentsInChildren<Text>()[1].text = ROMA_CHARS[i];
            }
            else
            {
                GameObject kana = Instantiate(prefabs, Vector3.zero, Quaternion.identity) as GameObject;
                kana.transform.SetParent(transform);
                kana.transform.localScale = new Vector3(1, 1);
                kana.GetComponentInChildren<Image>().enabled = false;
                kana.GetComponentsInChildren<Text>()[0].text = "";
                kana.GetComponentsInChildren<Text>()[1].text = "";
            }
        }
    }

    void clickHiraganaButton()
    {
      //  HiraganaTab.image.color = new Color(13, 253, 243, 255);
        HiraganaTab.image.color = Color.green;
        KatakanaTab.image.color = Color.white;
        GameObject[] characters = GameObject.FindGameObjectsWithTag("Character");
        if (characters.Length != 0)
        {
            for (int i = 0; i < ROMA_CHARS.Length; i++)
            {
                if (ROMA_CHARS[i] != ".")
                {
                    characters[i].GetComponentsInChildren<Text>()[0].text = HIRA_CHARS[i];
                }
            }
        }
    }

    void clickKatakanaButton()
    {
      //  KatakanaTab.image.color = new Color(25, 118, 210, 1);
        KatakanaTab.image.color = Color.green;
        HiraganaTab.image.color = Color.white;
        GameObject[] characters = GameObject.FindGameObjectsWithTag("Character");
        if (characters.Length != 0)
        {
            for (int i = 0; i < ROMA_CHARS.Length; i++)
            {
                if (ROMA_CHARS[i] != ".")
                {
                    characters[i].GetComponentsInChildren<Text>()[0].text = KATA_CHARS[i];
                }
            }
        }
    }
}

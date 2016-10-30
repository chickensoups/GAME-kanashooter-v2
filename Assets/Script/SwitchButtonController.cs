using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchButtonController : MonoBehaviour {
	public Button[] buttons;
	public Image[] tutorImgs;
	public Image currentImg;

	private int numImg;

	void Start() {
		//button: 0=play; 1=tutorial; 2=learn; 3=MainMenu
		buttons [0].onClick.AddListener (GotoNextImg);
		buttons [1].onClick.AddListener (GotoPreviousImg);
		//start at image 0
		numImg = 0;
		currentImg.sprite = tutorImgs [numImg].sprite;
	}

	void GotoNextImg() {
		if (numImg < tutorImgs.Length - 1) {
			currentImg.sprite = tutorImgs [++numImg].sprite;
		} else {
			numImg = 0;
			currentImg.sprite = tutorImgs [numImg].sprite;
		}
	}

	void GotoPreviousImg() {
		if (numImg > 0) {
			currentImg.sprite = tutorImgs [--numImg].sprite;
		}
	}
}

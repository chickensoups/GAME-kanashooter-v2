using UnityEngine;
using System.Collections;

public class testIncreaseProgress : MonoBehaviour {

	private ProgressAndBarrierHealthBarController progressAndBarrierHealthBarController;

	void Start(){
		//find ProgressAndBarrierHealthBarController
		GameObject progressAndBarrierHealthBarControllerObject = GameObject.FindGameObjectWithTag ("ProgressAndBarrierHealthBarController");
		if (progressAndBarrierHealthBarControllerObject != null)
		{
			progressAndBarrierHealthBarController = progressAndBarrierHealthBarControllerObject.GetComponent <ProgressAndBarrierHealthBarController>();
		}
		if (progressAndBarrierHealthBarController == null)
		{
			Debug.Log ("Cannot find 'ProgressBarController' script");
		}

		//run test
		progressAndBarrierHealthBarController.decreaseHealth (10);
		StartCoroutine (increasePointTest ());
	}

	IEnumerator increasePointTest(){
		while (progressAndBarrierHealthBarController.GetCurrentPoint () < progressAndBarrierHealthBarController.GetWinPoint3()) {
			progressAndBarrierHealthBarController.increaseProgress (1);
			progressAndBarrierHealthBarController.regenHealth ();
			yield return new WaitForSeconds (1);
		}
	}
}

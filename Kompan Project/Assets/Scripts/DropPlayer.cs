using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPlayer : MonoBehaviour {

	public float timeUntilPlayerDrop = 3f;
	public GameObject[] targetsToDestroyAfterPlayerDrop;
	public GameObject targetPlatform;
	public GameObject targetToShowUponDrop;

	// Use this for initialization
	void Start () {
		StartCoroutine (WaitForPlayerDrop ());
	}

	IEnumerator WaitForPlayerDrop (){
		yield return new WaitForSeconds (timeUntilPlayerDrop);
		targetToShowUponDrop.SetActive (true);
		yield return new WaitForSeconds (1f);
		Destroy (targetPlatform);
		yield return new WaitForSeconds (4f);
		foreach (GameObject go in targetsToDestroyAfterPlayerDrop) {
			Destroy (go);
		}
	}
}
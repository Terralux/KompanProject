using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoSequence : MonoBehaviour {

	[Range(0f,10f)]
	public float activeLogoTime = 5f;
	public GameObject[] logosToBeDisplayed;

	public float distanceFromCamera = 3f;

	public float verticalOffset = -1f;

	void Awake () {
		StartCoroutine (WaitForLogoDuration (0));
	}

	IEnumerator WaitForLogoDuration(int index){
		if (index < logosToBeDisplayed.Length) {
			GameObject tempGO = Instantiate (logosToBeDisplayed [index],transform.position + transform.forward * distanceFromCamera + transform.up * verticalOffset, transform.rotation)  as GameObject;

			tempGO.transform.SetParent (transform);
			tempGO.transform.localRotation = Quaternion.Euler (new Vector3 (0, 180, 0));

			Destroy (tempGO, activeLogoTime);
			yield return new WaitForSeconds (activeLogoTime);

			StartCoroutine (WaitForLogoDuration (index + 1));
		}
	}
}
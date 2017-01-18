using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPlayer : MonoBehaviour {

	public float timeUntilPlayerDrop = 3f;
	public GameObject[] targetsToDestroyAfterPlayerDrop;
	public GameObject targetPlatform;
	public GameObject targetToShowUponDrop;

	public float fraction = 0f;
	public Renderer targetRender;

	// Use this for initialization
	void Start () {
		StartCoroutine (WaitForPlayerDrop ());
	}

	IEnumerator WaitForPlayerDrop (){
		yield return new WaitForSeconds (timeUntilPlayerDrop);
		targetRender = targetPlatform.GetComponent<Renderer>();
		targetToShowUponDrop.SetActive (true);
		yield return new WaitForSeconds (0.5f);
		StartCoroutine (Dissolve ());
	}

	IEnumerator Dissolve() {
		yield return new WaitForSeconds (0.05f);
		fraction += 0.70f * Time.deltaTime;
		targetRender.sharedMaterial.SetFloat ("_SliceAmount", fraction);

		if (fraction >= 0.8f) {
			Destroy (targetPlatform);
			foreach (GameObject go in targetsToDestroyAfterPlayerDrop) {
				Destroy (go);
			}
		} else {
			StartCoroutine (Dissolve ());
		}
	}
}
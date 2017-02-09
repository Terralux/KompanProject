using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour {

	public float timeBeforeStartup = 15f;
	[Range(5,20)]
	public float maxTimeBetweenBounces;
	[Range(0,5)]
	public float minTimeBetweenBounces;

	public GameObject parentObject;
	public GameObject firstBounce;

	// Use this for initialization
	void Start () {
		StartCoroutine (InitialBounce ());
	}

	IEnumerator InitialBounce(){
		yield return new WaitForSeconds (timeBeforeStartup);
		firstBounce.GetComponent<Animator> ().SetTrigger ("Bounce");
		StartCoroutine (WaitForNextBounce ());
	}

	IEnumerator WaitForNextBounce(){
		yield return new WaitForSeconds (Random.Range (minTimeBetweenBounces, maxTimeBetweenBounces));
		int childIndex = Random.Range (0, parentObject.transform.childCount);
		parentObject.transform.GetChild (childIndex).GetComponent<Animator> ().SetTrigger ("Bounce");
		StartCoroutine (WaitForNextBounce ());
	}
}
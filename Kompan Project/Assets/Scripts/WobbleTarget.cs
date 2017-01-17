using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WobbleTarget : LookTarget {

	public float speed = 1f;
	public float wobbleFactor = 0.2f;

	private Vector3 originalSize;
	private bool isInFocus = false;

	private float fraction = 0f;
	private Vector3 currentSize;

	public GameObject splashParticles;
	public GameObject bubbleParticles;

	public GameObject textObject;
	public float textDistance = 1f;

	private bool hasBeenChosen = false;
	private Vector3 originalPosition;

	public static GameObject chosenBubble;

	[HideInInspector]
	public int sceneIndex;

	// Use this for initialization
	void Awake () {
		originalSize = transform.localScale;
		splashParticles.GetComponent<ParticleSystem> ().Stop ();
	}
	
	// Update is called once per frame
	void Update () {
		if (chosenBubble != null) {
			if (chosenBubble == gameObject) {
				//Fade to black
				if (Vector3.Distance (transform.position, Camera.main.transform.position) < 1f) {
					if (sceneIndex > 0) {
						//UnityEngine.SceneManagement.SceneManager.LoadScene (sceneIndex);
					} else {
						//UnityEngine.SceneManagement.SceneManager.LoadScene (1);
					}
				} else {
					fraction += 0.05f * speed * Time.deltaTime;
					transform.position = Vector3.Lerp (originalPosition, Camera.main.transform.position, fraction);
				}
			}else{
				textObject.transform.SetParent (transform);

				if (transform.localScale.magnitude > 0.01f) {
					fraction += 0.15f * speed * Time.deltaTime;
					transform.localScale = Vector3.Lerp (originalSize, Vector3.zero, fraction);
				} else {
					Pop ();
				}
			}
		} else {
			if (isInFocus) {
				float myValue = speed * Time.time;
				transform.localScale = new Vector3 (originalSize.x + Mathf.Cos (myValue) * wobbleFactor, originalSize.y + Mathf.Sin (myValue) * wobbleFactor, originalSize.z + Mathf.Cos (myValue) * wobbleFactor);
			}
		}
	}

	#region implemented abstract members of LookTarget

	public override void Action () {
		StopAllCoroutines ();
		isInFocus = false;
		GetComponent<SphereCollider> ().enabled = false;
		fraction = 0f;
		originalPosition = transform.position;
		hasBeenChosen = true;
		chosenBubble = gameObject;
	}

	public override void Focus(bool inFocus) {
		if (!isInFocus && inFocus) {
			splashParticles.SetActive (true);
			splashParticles.GetComponent<ParticleSystem> ().Emit (30);
			bubbleParticles.GetComponent<ParticleSystem> ().Play ();
		}
		isInFocus = inFocus;

		if (!inFocus) {
			currentSize = transform.localScale;
			StartCoroutine (LerpSizeToOrigin ());
			bubbleParticles.GetComponent<ParticleSystem> ().Stop ();
		} else {
			StopAllCoroutines ();
		}
	}

	#endregion

	IEnumerator LerpSizeToOrigin(){
		fraction += 0.01f * speed * 0.001f;
		transform.localScale = Vector3.Lerp (currentSize, originalSize, fraction);
		yield return new WaitForSeconds (0.01f);
		if (fraction >= 1) {
			transform.localScale = originalSize;
			fraction = 0f;
		} else {
			StartCoroutine (LerpSizeToOrigin ());
		}
	}

	public void InitializeText(){
		Destroy(GetComponent<LookAtPlayer> ());
		textObject.SetActive (true);
		textObject.transform.SetParent (null);
		//Debug.Log("<color=red>THIS NEEDS TO BE FIXED!</color>");
		/*
		 * Bloqx
		 * Cross Systems
		 * Elements
		 * Galaxy
		 * Imaginator
		 * Organic Robinia
		 * Freegame
		 * Corocord
		*/
	}

	public void Pop(){
		
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WobbleTarget : LookTarget {

	public float speed = 1f;
	public float wobbleFactor = 0.2f;

	private Vector3 originalSize;
	private bool isInFocus = false;

	public float fraction = 0f;
	private Vector3 currentSize;

	public GameObject splashParticles;
	public GameObject bubbleParticles;

	public GameObject textObject;
	public float textDistance = 1f;

	private Vector3 originalPosition;

	public static GameObject chosenBubble;

	[HideInInspector]
	public int sceneIndex;

	private FadeMaster fm;

	void Awake () {
		originalSize = transform.localScale;
		splashParticles.GetComponent<ParticleSystem> ().Stop ();
		fm = GameObject.FindGameObjectWithTag ("FadeMaster").GetComponent<FadeMaster> ();
	}

	void Update () {
		if (chosenBubble != null) {
			if (chosenBubble == gameObject) {
				if (Vector3.Distance (transform.position, Camera.main.transform.position) < 1f) {
					fm.Fade (1);
					fm.OnCompletelyFaded += InitiateLoad;
				} else {
					fraction += 0.05f * speed * Time.deltaTime;
					transform.position = Vector3.Lerp (originalPosition, Camera.main.transform.position, fraction);
				}
			}else{
				textObject.transform.SetParent (transform);

				if (fraction < 1) {
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


	void InitiateLoad () {
		fm.OnCompletelyFaded -= InitiateLoad;
		UnityEngine.SceneManagement.SceneManager.LoadScene (1);
	}

	#region implemented abstract members of LookTarget

	public override void Action () {
		StopAllCoroutines ();
		isInFocus = false;
		GetComponent<SphereCollider> ().enabled = false;
		fraction = 0f;
		originalPosition = transform.position;
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
		fraction += 0.5f * speed * 0.001f;
		transform.localScale = Vector3.Lerp (currentSize, originalSize, fraction);
		yield return new WaitForSeconds (0.05f);
		if (fraction >= 1) {
			transform.localScale = originalSize;
			fraction = 0f;
			StopAllCoroutines ();
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
		splashParticles.transform.SetParent (null);
		splashParticles.GetComponent<ParticleSystem> ().Emit (30);
		Destroy (gameObject);
	}
}
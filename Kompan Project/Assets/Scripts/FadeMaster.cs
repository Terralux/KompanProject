using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeMaster : MonoBehaviour {

	public Renderer fadeRenderer;

	FadeMaster fm;
	private float fraction;

	public delegate void voidEvent ();
	public voidEvent OnCompletelyFaded;

	private bool hasTriggeredFade = false;

	// Use this for initialization
	void Awake () {
		fadeRenderer.material.SetFloat ("_SliceAmount", 1);
		if (fm == null) {
			fm = this;
		} else {
			Destroy (this);
		}
	}

	public void Fade(float speed){
		StartCoroutine (TransitionFade (speed));
	}

	IEnumerator TransitionFade(float speed){
		yield return new WaitForSeconds (0.01f);
		fraction += speed * Time.deltaTime;

		if (fraction < 1) {
			fadeRenderer.material.SetFloat ("_SliceAmount", 1 - fraction);
		} else {
			fadeRenderer.material.SetFloat ("_SliceAmount", fraction - 1);

			if (!hasTriggeredFade) {
				hasTriggeredFade = true;
				if (OnCompletelyFaded != null) {
					OnCompletelyFaded ();
				}
			}
		}

		if (fraction < 2) {
			StartCoroutine (TransitionFade (speed));
		} else {
			fraction = 0f;
			hasTriggeredFade = false;
		}
	}
}

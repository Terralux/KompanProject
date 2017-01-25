using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTranslate : MonoBehaviour {

	public float heightRange = 1f;
	public float speed = 0.01f;

	private float fraction;
	private Vector3 origin;

	private bool isGoingUp;

	void Awake(){
		origin = transform.position;
	}

	void Update () {
		fraction += Time.deltaTime * speed * (isGoingUp?1:-1);
		transform.position = Vector3.Lerp (origin, origin + Vector3.up * heightRange, fraction);

		if (fraction >= 1) {
			isGoingUp = false;
		}
		if(fraction <= 0){
			isGoingUp = true;
		}
	}
}
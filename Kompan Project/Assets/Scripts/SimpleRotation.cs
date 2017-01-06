﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotation : MonoBehaviour {

	[Range(-100,100)]
	public float speed;

	[Range(1,5)]
	public float radiusOffset = 3f;

	[Range(0f,1f)]
	public float heightOffset = 0.2f;

	private float rotationOffset;

	[HideInInspector]
	public bool isSlowingDown = false;

	[Range(0.05f,10f)]
	public float slowDownFactor = 10f;

	void Start(){
		rotationOffset = 360f/transform.childCount;

		for (int i = 0; i < transform.childCount; i++) {
			transform.GetChild (i).localPosition = Vector3.zero;
			transform.GetChild (i).Rotate (new Vector3 (0, rotationOffset * i, 0));
			transform.GetChild (i).localPosition = transform.GetChild (i).forward * radiusOffset + new Vector3 (0, Random.Range (-heightOffset, heightOffset), 0);
		}
	}

	void Update () {
		transform.Rotate (new Vector3 (0, speed, 0) * Time.deltaTime);

		if (isSlowingDown) {
			speed -= Time.deltaTime * slowDownFactor;
			if (speed <= 0) {
				Destroy (this);
			}
		}
	}
}
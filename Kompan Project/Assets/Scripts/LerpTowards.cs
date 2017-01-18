﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTowards : MonoBehaviour {

	[HideInInspector]
	public Transform target;

	private Vector3 origin;

	private float fraction;

	[Range(0.1f,5f)]
	public float speed;

	// Use this for initialization
	void Awake () {
		origin = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			fraction += speed * Time.deltaTime;
			transform.position = Vector3.Lerp (origin, target.position, fraction);
		}
	}
}

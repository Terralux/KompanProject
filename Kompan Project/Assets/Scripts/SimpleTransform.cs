﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTransform : MonoBehaviour {

	public float speed = 25;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, -speed, 0));
	}
}

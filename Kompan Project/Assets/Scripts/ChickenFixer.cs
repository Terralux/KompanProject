using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenFixer : MonoBehaviour {

	public Transform[] transforms;

	// Use this for initialization
	void Awake () {
		foreach (Transform t in transforms) {
			t.localRotation = Quaternion.Euler(new Vector3 (0, t.localRotation.eulerAngles.y, 0));
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
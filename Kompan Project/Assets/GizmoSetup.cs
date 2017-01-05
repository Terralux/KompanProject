using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoSetup : MonoBehaviour {

	public Transform[] t1;

	void OnDrawGizmos(){

		Gizmos.DrawWireSphere (transform.position, 0.3f);

		foreach(Transform t in t1) {
			Gizmos.DrawLine (transform.position, t.position);
		}
	}
}

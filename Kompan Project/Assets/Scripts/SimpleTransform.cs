using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTransform : MonoBehaviour {

	public float speed = 25;

	private bool isSlowingDown = false;
	[HideInInspector]
	public float slowDownFactor;

	public enum Axis
	{
		X,
		Y,
		Z
	}

	public Axis myAxis = Axis.Y;
	
	// Update is called once per frame
	void Update () {

		if (isSlowingDown) {

			if (speed < 0.05f && speed > -0.05f) {
				Destroy (this);
			}

			if (speed > 0) {
				speed -= Time.deltaTime * slowDownFactor;
			} else {
				speed += Time.deltaTime * slowDownFactor;
			}
		}

		switch(myAxis){
		case Axis.X:
			transform.Rotate (new Vector3 (-speed, 0, 0));
			break;
		case Axis.Y:
			transform.Rotate (new Vector3 (0, -speed, 0));
			break;
		case Axis.Z:
			transform.Rotate (new Vector3 (0, 0, -speed));
			break;
		}
	}

	public void SlowDown(float neoSlowDownFactor){
		isSlowingDown = true;
		slowDownFactor = neoSlowDownFactor;
	}
}
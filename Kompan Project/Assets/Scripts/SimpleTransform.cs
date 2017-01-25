using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTransform : MonoBehaviour {

	public float speed = 25;

	public enum Axis
	{
		X,
		Y,
		Z
	}

	public Axis myAxis = Axis.Y;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

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
}

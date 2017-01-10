using UnityEngine;
using System.Collections;

public abstract class LookTarget : MonoBehaviour {

	public abstract void Action ();
	public abstract void Focus (bool isInFocus);

}

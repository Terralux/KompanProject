using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractivePopup : InteractiveObject {

	public GameObject objectToShow;

	void Awake(){
		objectToShow.SetActive (false);
	}

	#region implemented abstract members of InteractiveObject

	public override void Interact (Vector3 targetPosition){
		
	}

	public override void Initialize (Vector3 targetPosition){
		objectToShow.SetActive (!objectToShow.activeSelf);
	}

	public override void End (Vector3 targetPosition){
		
	}

	#endregion
}
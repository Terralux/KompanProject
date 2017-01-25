using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationInteractiveObject : InteractiveObject {

	private Animator anim;

	public string animationTriggerString = "Action";

	void Start(){
		anim = GetComponent<Animator> ();
	}

	#region implemented abstract members of InteractiveObject

	public override void Interact (Vector3 targetPosition){
		
	}

	public override void Initialize (Vector3 targetPosition){
		anim.SetTrigger (animationTriggerString);
	}

	public override void End (Vector3 targetPosition){

	}

	#endregion
}
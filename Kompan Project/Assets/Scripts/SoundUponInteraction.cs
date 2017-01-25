using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundUponInteraction : InteractiveObject {

	private AudioSource audio;
	public float frequency;

	private int position = 0;

	void Awake(){
		AudioClip myClip = AudioClip.Create ("MySinusoid", 44100 * 2, 1, 44100, true, OnAudioRead, OnAudioSetPosition);
		audio = GetComponent<AudioSource> ();
		audio.clip = myClip;
	}

	#region implemented abstract members of InteractiveObject

	public override void Interact (Vector3 targetPosition){
		audio.Play ();
	}

	public override void Initialize (Vector3 targetPosition){
		audio.Play ();
	}

	public void OnAudioRead(float[] data){
		int count = 0;
		while (count < data.Length) {
			data [count] = Mathf.Sign (Mathf.Sin (2 * Mathf.PI * frequency * position / 44100));
			position++;
			count++;
		}
	}

	public void OnAudioSetPosition(int newPosition){
		position = newPosition;
	}
	public override void End (Vector3 targetPosition){
	
	}

	#endregion
}
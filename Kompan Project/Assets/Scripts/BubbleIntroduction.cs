using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleIntroduction : MonoBehaviour {

	public Transform player;

	public float playerOffset;

	public GameObject[] objectsToSpawn;
	public float movementSpeed;

	public float spawnDelay;

	public float startDelay;

	public float slowDownThreshold;

	public float slowDownFactor;

	private int objectsOnEachSide;
	private int currentIndex = 0;

	private Transform leftParent;
	private Transform rightParent;

	private SimpleTransform stl;
	private SimpleTransform str;

	public float heightOffset = 3f;

	public Transform[] teleportLocations;

	void Awake () {
		objectsOnEachSide = objectsToSpawn.Length/2;
		StartCoroutine (WaitForStartUp ());
	}

	IEnumerator WaitForStartUp(){
		yield return new WaitForSeconds (startDelay);

		leftParent = (new GameObject ("Left Parent")).transform;
		rightParent = (new GameObject ("Right Parent")).transform;

		leftParent.position = player.position;
		rightParent.position = player.position;

		stl = leftParent.gameObject.AddComponent<SimpleTransform> ();
		str = rightParent.gameObject.AddComponent<SimpleTransform> ();

		stl.myAxis = SimpleTransform.Axis.Y;
		str.myAxis = SimpleTransform.Axis.Y;

		stl.speed = movementSpeed;
		str.speed = -movementSpeed;

		StartCoroutine (WaitForNextSpawn ());
	}

	IEnumerator WaitForNextSpawn(){
		if (currentIndex < objectsOnEachSide) {
			yield return new WaitForSeconds (spawnDelay);
			GameObject lGO = Instantiate (objectsToSpawn [currentIndex], player.position + player.forward * -playerOffset + Vector3.up * heightOffset, Quaternion.identity) as GameObject;
			GameObject rGO = Instantiate (objectsToSpawn [currentIndex + objectsOnEachSide], player.position + player.forward * -playerOffset + Vector3.up * heightOffset, Quaternion.identity) as GameObject;

			lGO.GetComponent<WobbleTarget> ().teleportLocation = teleportLocations [currentIndex];
			rGO.GetComponent<WobbleTarget> ().teleportLocation = teleportLocations [currentIndex + objectsOnEachSide];

			lGO.transform.SetParent (leftParent);
			rGO.transform.SetParent (rightParent);

			currentIndex++;
			StartCoroutine (WaitForNextSpawn ());
		} else {
			StartCoroutine (WaitForSlowDown ());
		}
	}

	IEnumerator WaitForSlowDown(){
		yield return new WaitForSeconds (0.05f);
		if (rightParent.rotation.eulerAngles.y > slowDownThreshold) {
			stl.SlowDown (slowDownFactor);
			str.SlowDown (slowDownFactor);
		} else {
			StartCoroutine (WaitForSlowDown ());
		}
	}
}
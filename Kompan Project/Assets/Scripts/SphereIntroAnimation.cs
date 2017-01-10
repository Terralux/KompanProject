using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereIntroAnimation : MonoBehaviour {

	public Transform parentObject;

	public GameObject[] islandOptions;
	private List<GameObject> instantiatedIslands = new List<GameObject>();

	public int index;

	[Range(0f,2f)]
	public float offset;

	public Transform targetPosition;

	// Use this for initialization
	void Awake () {
		for (int i = 0; i < islandOptions.Length; i++) {
			GameObject go = new GameObject ("Position " + (i + 1));
			go.transform.SetParent (parentObject);
		}
		StartCoroutine (WaitForNextSpawn());
	}

	IEnumerator WaitForNextSpawn(){
		if (index < islandOptions.Length) {

			instantiatedIslands.Add(Instantiate (islandOptions [index], transform.position + (Random.onUnitSphere * 2), islandOptions [index].transform.rotation) as GameObject);

			instantiatedIslands [instantiatedIslands.Count - 1].GetComponent<LerpTowards> ().target = parentObject.GetChild (index);

			yield return new WaitForSeconds (offset);
			index++;

			StartCoroutine (WaitForNextSpawn ());
		} else {
			yield return new WaitForSeconds (2f);
			parentObject.GetComponent<SimpleRotation> ().isSlowingDown = true;
			Debug.Log("No more islands! :D");
		}
	}

	void OnDrawGizmos(){
		Gizmos.DrawLine (transform.position, targetPosition.position);
	}

	void Update(){
		for (int i = 0; i < instantiatedIslands.Count; i++) {
			if (Vector3.Distance (instantiatedIslands [i].transform.position, targetPosition.position) < 4f) {
				instantiatedIslands [i].transform.SetParent (parentObject);
			}
		}
	}

	/*
	void OrganizeChildren(){
		for (int j = instantiatedIslands.Count - 1; j > 0; j--) {
			for (int i = 0; i < j; i++) {
				if (instantiatedIslands [i] > instantiatedIslands [i + 1]) {
					GameObject temp = instantiatedIslands [i];
					instantiatedIslands [i] = instantiatedIslands [i + 1];
					instantiatedIslands [i + 1] = temp;
				}
			}
		}
	}
	*/
}
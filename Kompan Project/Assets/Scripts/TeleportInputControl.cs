using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportInputControl : MonoBehaviour {

	public float teleportMarkerHeightOffset = 0.1f;

	public Transform playArea;

	private float heightOffset = 0.2f;

	private SteamVR_TrackedObject trackedObj;

	private SteamVR_Controller.Device Controller{
		get { return SteamVR_Controller.Input ((int)trackedObj.index); }
	}

	private Transform teleportTarget;

	private Vector3 teleportLocation;

	private FadeMaster fm;

	private bool canTeleport = true;
	private bool teleporterIsOn = true;

	public GameObject teleportIcon;
	public GameObject exitIcon;

	void Awake(){
		fm = GameObject.FindGameObjectWithTag ("FadeMaster").GetComponent<FadeMaster>();

		teleportTarget = transform.GetChild (0);
		teleportTarget.SetParent (null);

		if (teleportTarget == null) {
			Debug.LogError ("The Teleport target is missing, please add a child to handle Transform");
		}

		trackedObj = GetComponent<SteamVR_TrackedObject> ();
	}

	// Update is called once per frame
	void Update () {
		if (teleporterIsOn) {
			RaycastHit hit;
			Ray ray = new Ray (trackedObj.transform.position, trackedObj.transform.forward);

			if (Physics.Raycast (ray, out hit, 100f)) {
				if (hit.collider.gameObject.CompareTag ("Terrain")) {

					teleportTarget.position = hit.point + new Vector3 (0, teleportMarkerHeightOffset, 0);

					teleportIcon.SetActive (true);
					exitIcon.SetActive (false);

					if (Controller.GetHairTriggerDown () && canTeleport) {
						//fm.Fade (1);
						//fm.OnCompletelyFaded += MovePlayer;
						teleportLocation = hit.point;
						canTeleport = false;
						MovePlayer ();
					}
				}else if (hit.collider.gameObject.CompareTag ("Exit")) {
					teleportTarget.position = hit.point + new Vector3 (0, teleportMarkerHeightOffset, 0);

					teleportIcon.SetActive (false);
					exitIcon.SetActive (true);

					if (Controller.GetHairTriggerDown () && canTeleport) {
						if (!SteamVR_LoadLevel.loading) {
							SteamVR_LoadLevel.Begin ("Kompan Test Scene", false, 0.5f, 0, 0, 0, 1);
						}
					}
				}
			}
		} else {
			teleportTarget.position = new Vector3 (100000, 100000, 100000);
		}
	}

	void MovePlayer(){
		fm.OnCompletelyFaded -= MovePlayer;
		Vector3 difference = playArea.position - transform.position;
		difference = new Vector3 (difference.x, 0, difference.z);
		playArea.position = teleportLocation + new Vector3 (0, heightOffset, 0) + difference;
		canTeleport = true;
	}

	void OnCollisionEnter(Collision col){
		if (col.collider.CompareTag ("Terrain")) {
			GetComponent<Rigidbody> ().useGravity = false;
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.CompareTag ("Interactive")) {
			teleporterIsOn = false;
			teleportTarget.position = new Vector3 (100000, -100000, 100000);
		}
	}

	void OnTriggerExit(Collider col){
		if (col.CompareTag ("Interactive")) {
			teleporterIsOn = true;
		}
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionControl : MonoBehaviour {

	public Transform playArea;

	private SteamVR_TrackedObject trackedObj;

	private bool isInFocus = false;

	private LookTarget prevLt;
	private LookTarget lt;

	private float passedTime = 0f;

	private SteamVR_Controller.Device Controller{
		get { return SteamVR_Controller.Input ((int)trackedObj.index); }
	}

	void Awake(){
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
	}

	void Update () {
		RaycastHit hit = new RaycastHit();
		Ray ray = new Ray (trackedObj.transform.position, trackedObj.transform.forward);

		isInFocus = false;

		if (Physics.Raycast (ray, out hit, 100f)) {
			if (hit.collider != null) {
				prevLt = lt;
				lt = hit.collider.gameObject.GetComponent<LookTarget> ();

				if (lt != null) {
					if ((lt as WobbleTarget).isActiveAndEnabled) {
						isInFocus = true;
						lt.Focus (isInFocus);

						if (lt != prevLt) {
							passedTime = 0f;
							if (prevLt != null) {
								prevLt.Focus (false);
							}
						}
					}

					if (Controller.GetHairTriggerDown ()) {
						lt.Action ();
					}
				} else {
					if (prevLt != null) {
						prevLt.Focus (false);
					}
				}
			} else {
				if (prevLt != null) {
					prevLt.Focus (false);
				}
			}
		}
	}
}
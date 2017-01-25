using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObjectNode : MonoBehaviour {
	public Transform[] reachableNodes;

	public Vector3 GetLerpedLocation(Vector3 target){

		int targetDirectionIndex = 0;

		for (int i = 1; i < reachableNodes.Length; i++) {
			if (Vector3.Dot (target, reachableNodes [targetDirectionIndex].position) < Vector3.Dot (target, reachableNodes [i].position)) {
				targetDirectionIndex = i;
			}
		}

		float maxDistance = Vector3.Distance (reachableNodes [targetDirectionIndex].position, transform.position);

		float distanceToOrigin = Vector3.Distance (transform.position, target);
		float distanceToClosestReachable = Vector3.Distance (reachableNodes [targetDirectionIndex].position, target);

		float fraction = (distanceToOrigin < distanceToClosestReachable ? distanceToClosestReachable - distanceToOrigin : distanceToOrigin - distanceToClosestReachable) / maxDistance;

		return Vector3.Lerp (reachableNodes [targetDirectionIndex].position, transform.position, fraction);
	}
}
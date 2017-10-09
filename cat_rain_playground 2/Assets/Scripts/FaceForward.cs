using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FaceForward : MonoBehaviour {

	private Transform parent;

	// Use this for initialization
	void Start () {
		parent = transform.parent;
	}

	/**
	 * Plot a point just in front of the game object, and face it. Useful for making the character tilt
	 * when walking up slopes, since RAINS navmesh system did not work properly.
	 */
	private bool GetPoint(out Vector3 result) {
		for (int i = 0; i < 30; i++) {
			Vector3 point = transform.position + transform.parent.forward * 0.1f;
			NavMeshHit hit;
			if (NavMesh.SamplePosition(point, out hit, 1.0f, NavMesh.AllAreas)) {
				result = hit.position;
				return true;
			}
		}
		result = Vector3.zero;
		return false;
	}
	void Update() {
		Vector3 point;
		if (GetPoint(out point)) {
			transform.LookAt (point);
		}
	}
}

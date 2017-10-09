using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RAIN.Core;

public class BreakableObject : MonoBehaviour {

	private AudioSource as_dropped;

	private GameObject contents;

	// Use this for initialization
	void Start () {
		as_dropped = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnEnable() {
		Reset ();
	}

	public void Reset() {
		Destroy (contents);
	}

	void OnCollisionEnter(Collision coll) {
		if(coll.transform.tag.Equals ("Floor")) {
			GameObject.Find ("CatAI").GetComponent<AIRig> ().AI.WorkingMemory.SetItem<bool> ("waiting", false);
			if(!as_dropped.isPlaying) {
				as_dropped.Play ();
			}
			if(contents == null) {
				contents = (GameObject)Instantiate (Resources.Load("Spill"), coll.contacts [0].point + Vector3.up * 0.01f, Quaternion.identity);

			}
		}
	}
}

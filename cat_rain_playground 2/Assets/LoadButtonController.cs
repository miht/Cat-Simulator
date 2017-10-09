using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadButtonController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (!File.Exists (Application.persistentDataPath + "/gameState.dat")) {
			gameObject.SetActive (false);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

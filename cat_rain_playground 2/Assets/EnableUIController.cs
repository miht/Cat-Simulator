using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableUIController : MonoBehaviour {

	public UIController UIController;
	public VariableController vc;

	// Use this for initialization
	void Start () {
		
	}

	void OnEnable() {
		UIController.enabled = true;
		vc.hasPlayedTutorial = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

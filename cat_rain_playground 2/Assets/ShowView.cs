using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowView : MonoBehaviour {

	public GameObject view;

	// Use this for initialization
	void Start () {
		view.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonDown (0)) {
			view.SetActive (false);
		}
		
	}
}

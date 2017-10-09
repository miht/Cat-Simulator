using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour {

	public GameObject interactableCanvas;

	public Text canvasDescription;
	public Button btn_ok;

	// Use this for initialization
	void Start () {
		btn_ok.onClick.AddListener (Dismiss);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public virtual void Dismiss() {
		interactableCanvas.SetActive (false);
	}

	public virtual void Interact() {
//		interactableCanvas.SetActive (true);
	}

	public virtual void Clicked() {
		interactableCanvas.SetActive (true);
	}
}

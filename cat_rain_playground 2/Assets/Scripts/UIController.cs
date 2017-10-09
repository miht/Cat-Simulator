using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * This class handles which UI objects should be displayed in the top left corner.
 * When an object within the scene is clicked, if it has an interactable script, set the
 * top left corner info window to the corresponding object's one.
 */
public class UIController : MonoBehaviour {

	public GameObject[] ELEMENTS;

	public GameObject broadcastCanvas;
	public Text txt_broadcast;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown (0)) {

			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast (ray, out hit)) {
				Transform objectHit = hit.transform;
				HideAllElements ();

				if (objectHit.tag == "Interactable" || objectHit.tag == "Breakable" || objectHit.tag == "Consumable") {
					objectHit.GetComponent<Interactable> ().Clicked ();
				}
			}
		}
	}


	public void Broadcast(string txt) {
		HideAllElements ();
		broadcastCanvas.SetActive (true);
		txt_broadcast.text = txt;
	}
		
	public void HideAllElements() {
		foreach(GameObject g in ELEMENTS) {
			g.SetActive (false);
		}
	}

	public void ShowElement(GameObject g) {
		HideAllElements ();
		g.SetActive (true);
	}
}

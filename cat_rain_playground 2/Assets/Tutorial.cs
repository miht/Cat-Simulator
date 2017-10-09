using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

	public GameObject[] clickable_objects;
	public GameObject[] tut_canvas_objects;

	public GameObject[] disableObjects;
	public UIController ui_c;

	private int current = 0;

	// Use this for initialization
	void Start () {
		
	}

	void OnEnable() {
		tut_canvas_objects [0].SetActive (true);
		foreach(GameObject g in disableObjects) {
			g.SetActive (false);
		}
		ui_c.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown (0)) {

			if(clickable_objects[current] != null) {
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

				if (Physics.Raycast (ray, out hit)) {
					Transform objectHit = hit.transform;
					Debug.Log ("Hit inst. ID: " + objectHit.GetInstanceID () + ", Tar inst. ID: " + clickable_objects[current].GetInstanceID ());
					if (objectHit.GetInstanceID () == clickable_objects[current].transform.GetInstanceID ()) {
						Debug.Log ("Hello");
						
						UpdateTutorial ();
					}
				}
			}
			else {
				UpdateTutorial ();
			}
		}
	}

	public void UpdateTutorial() {
		tut_canvas_objects [current].SetActive (false);
		current++;
		if(current >= tut_canvas_objects.Length) {
			//Tutorial is over
			Debug.Log("Destroying tutorial");			
			DestroyImmediate(gameObject);
			return;
		}
		tut_canvas_objects [current].SetActive (true);
	}
}

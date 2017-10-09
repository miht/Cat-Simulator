using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Breakable : Interactable {
	
	public float breakforce = 1000f;

	private Vector3 startPosition = Vector3.zero;
	private Quaternion startRotation = Quaternion.identity;

	public Button btn_no;

	// Use this for initialization
	void Start () {
		startPosition = transform.position;
		startRotation = transform.rotation;

		btn_ok.onClick.AddListener (Restore);
		btn_no.onClick.AddListener (Dismiss);

		canvasDescription.text = "This cup has not been tipped yet.";
		btn_ok.gameObject.SetActive (false);
		btn_no.transform.Find("Text").GetComponent<Text>().text = "Got it";

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.A)) {
			Vector3 catPos = GameObject.Find ("Cat").transform.position;
			GetComponent<Rigidbody>().velocity = (transform.position - catPos).normalized*breakforce;
		}
	}

	public override void Dismiss() {
		base.Dismiss ();
	}

	void Restore () {
		Dismiss ();

		transform.position = startPosition;
		transform.rotation = startRotation;

		transform.tag = "Breakable";
		GetComponent<BreakableObject> ().Reset ();
		canvasDescription.text = "This cup was tipped, \nbut it has been restored.";

		btn_ok.gameObject.SetActive (false);
		btn_no.transform.Find("Text").GetComponent<Text>().text = "Got it";
	}

	public override void Clicked() {
		interactableCanvas.SetActive (true);


	}

	public override void Interact() {
		Vector3 catPos = GameObject.Find ("Cat").transform.position;
		GetComponent<Rigidbody> ().velocity = transform.forward * breakforce;
		transform.tag = "Interactable";
		btn_ok.gameObject.SetActive (true);
		canvasDescription.text = "Tipped cup. Would you like to clean up?";
		btn_no.transform.Find("Text").GetComponent<Text>().text = "Not now";
	}
}

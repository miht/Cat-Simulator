using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RAIN.Core;
using UnityEngine.UI;

public class Consumable : Interactable {

	public string name;

	public float amount = 100f;
	public float maxAmount = 100f;

	public float rate = 1f;

	public GameObject contents;
	public GameObject arrow;

	public Button btn_no;

	// Use this for initialization
	void Start () {
		btn_ok.onClick.AddListener (Refill);
		btn_no.onClick.AddListener (Dismiss);
	}

	public void Consume(float amount) {
		this.amount -= rate * Time.deltaTime;
		this.amount = Mathf.Clamp (this.amount, 0f, maxAmount);

		if(IsEmpty()) {
			Deactivate ();
		}
	}

	public override void Dismiss() {
		base.Dismiss ();
	}

	public bool IsEmpty() {
		return amount <= 0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Refill() {
		
		AI ai = GameObject.Find ("CatAI").GetComponent<AIRig> ().AI;

		float resources = ai.WorkingMemory.GetItem<float> ("Resources");

		if(resources <= 0f) {
			GameObject.Find ("UIController").GetComponent<UIController> ().Broadcast ("You don't have anything to refill with. " +
				"To gain more resources, play a game or two with your cat.");
			return;
		}

		float needed = maxAmount - amount;
		if(resources >= needed) {
			amount += needed;
			resources -= needed;
			GameObject.Find ("UIController").GetComponent<UIController> ().Broadcast ("You've successfully fed the cat, and you've got "
				+ resources + " resources left.");
		}
		else {
			amount += resources;
			resources = 0f;
			GameObject.Find ("UIController").GetComponent<UIController> ().Broadcast ("It looks like you've run out of resources." +
				" Play a game with your cat in order to gain more.");
		}

		ai.WorkingMemory.SetItem<float> ("Resources", resources);
		Activate ();
	}

	private void Deactivate() {
		contents.GetComponent<MeshRenderer> ().enabled = false;
		arrow.SetActive (true);
	}

	private void Activate() {
		Dismiss ();
		contents.GetComponent<MeshRenderer> ().enabled = true;
		arrow.SetActive (false);
	}

	public float Rate {
		get{return rate;}
		set{rate = value;}
	}

	public override void Clicked() {
		interactableCanvas.SetActive (true);
		if(amount < maxAmount) {
			canvasDescription.text = "This is a container of " + name + ". There is currently " +
				amount + "/" + maxAmount + " " + name + " left. \nWould you like\nto refill?";

			btn_ok.gameObject.SetActive (true);
			btn_no.transform.Find("Text").GetComponent<Text>().text = "Later";
		}
		else {
			canvasDescription.text = "This is a container of " + name + ". There is currently " +
			amount + "/" + maxAmount + " " + name + " left.";
			btn_ok.gameObject.SetActive (false);
			btn_no.transform.Find("Text").GetComponent<Text>().text = "Got it";
		}
	}
}

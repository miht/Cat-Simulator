using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using RAIN.Core;
using UnityEngine.AI;

public class CatInteractable : Interactable {

	public Button btn_no;

	public GameObject ai;

	public GameObject mainCamera;

	private string name = "";
	public Text txt_cat_info;

	// Use this for initialization
	void Start () {
		btn_no.onClick.AddListener (Dismiss);
		btn_ok.onClick.AddListener (Play);

		name = GameObject.Find ("GameControl").GetComponent<GameControl> ().catName;
		txt_cat_info.text = "This is " + name + ". \n\nWould you like to play a game with it?";
	}

	// Update is called once per frame
	void Update () {

	}

	public void Play() {
		DeactivateCat ();
		Instantiate (Resources.Load ("Game"));

	}

	public void ActivateCat() {
		GetComponent<NavMeshAgent> ().enabled = true;
		mainCamera.SetActive (true);
		ai.SetActive (true);
	}

	public void DeactivateCat() {
		GetComponent<NavMeshAgent> ().enabled = false;
		mainCamera.SetActive (false);
		ai.SetActive (false);
	}

	public override void Dismiss() {
		base.Dismiss ();
	}

	public virtual void Interact() {
	}

	public override void Clicked() {
		interactableCanvas.SetActive (true);
	}
}

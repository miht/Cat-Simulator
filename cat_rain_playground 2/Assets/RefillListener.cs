using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RefillListener : MonoBehaviour {

	public Button btn_refill;
	public Tutorial tutorial;

	public Consumable consum;

	// Use this for initialization
	void Start () {
		btn_refill.onClick.AddListener (Click);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void Click() {
		tutorial.UpdateTutorial ();
		consum.Refill ();
	}
}

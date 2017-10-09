using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : Timer {

	public Light lamp;

	//What hours the lamp should be enabled
	public float startTime = 19f;
	public float endTime = 7f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Power() {
		lamp.enabled = !lamp.enabled;
	}

	public override void OnHourChange(int hour) {
		if(hour == startTime) {
			lamp.enabled = true;
		}
		else if(hour == endTime) {
			lamp.enabled = false;
		}
	}
}

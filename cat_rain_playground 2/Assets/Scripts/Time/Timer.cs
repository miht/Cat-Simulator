using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Timer : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public virtual void OnHourChange(int hour) {
		
	}

	public virtual void OnMinuteChange(int hour) {

	}

	public virtual void OnDayChange(int day) {

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Wallclock : Timer {

	public Transform dial_hour;
	public Transform dial_minute;

	public Text txt_day;
	public Text txt_hour;
	public Text txt_minute;

	// Use this for initialization
	void Start () {
		txt_day.text = "Day " + GameObject.Find ("Time").GetComponent<Clock> ().GetDay ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	 * On hour change, rotate the hour dial. Update the label
	 */

	public override void OnHourChange (int hour)
	{
		dial_hour.localEulerAngles = new Vector3 (0f, -hour * 30f, 0f);

		if(hour < 10) {
			txt_hour.text = "0" + hour;
		}
		else {
			txt_hour.text = "" + hour;
		}
	}

	/**
	 * On minute change, rotate the minute dial. Update the label
	 */
	public override void OnMinuteChange(int minute) {
		dial_minute.localEulerAngles = new Vector3 (0f, -minute * 6f, 0f);

		if(minute < 10) {
			txt_minute.text = "0" + minute;
		}
		else {
			txt_minute.text = "" + minute;
		}
	}

	/**
	 * On day change, update the day label
	 */
	public override void OnDayChange(int day) {
		txt_day.text = "Day " + day;
	}
		
}

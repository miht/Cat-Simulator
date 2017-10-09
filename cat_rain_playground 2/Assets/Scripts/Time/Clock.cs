using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour {

	//A list of timed objects within the scene
	private Timer[] timers;

	//The current day
	public int day = 0;

	//The time in hours
	public float hour = 12;
	public float minute = 0f;

	//The rate of time. a rate of 10 makes on hour in game pass in 6 minutes in real life.
	public static float rate = 1000f;

	//The total time in seconds passed since first launch
	private float time = 0f;

	// Use this for initialization
	void Start () {
		//GameControl.control.Load ();

		time -= (time % 3600);

		timers = GameObject.FindObjectsOfType<Timer> ();

		//Every hour and minute, send interrupts to all timed objects
		InvokeRepeating ("HourInterrupt", 0f, 3600f / rate);
		InvokeRepeating ("MinuteInterrupt", 0f, 60f / rate);

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		time = Mathf.Repeat (time + Time.deltaTime * rate, 3600f * 24f);
	}

	public float GetTime() {
		return time;
	}
	public void SetTime(float time) {
		this.time = Mathf.Repeat (time, 3600f * 24f);
	}

	public float GetDay() {
		return day;
	}
	public void SetDay(int day) {
		this.day = day;
	}
		
	/**
	 * The percentage of day. For instance, 12 am represents 0.5. 6 pm represents 0.75
	 */
	public float getPercentageOfDay() {
		return time / (24f * 3600f);
	}

	/**
	 * Return a sine value that oscillates between night and day. For instance, unlike getPercentageOfDay, this
	 * value does not reset.
	 * 
	 * Used for calculating light strength in scene.
	 */
	public float getDayNightRatio() {
		float val = Mathf.Sin (Mathf.PI * getPercentageOfDay ());
		return (val / 2) + 0.5f;
	}

	/**
	 * Fast forward the time a set number of seconds.
	 */
	public void fastForwardTime(float skip) {
		this.time += Mathf.Repeat (skip, 3600f * 24f);
	}

	private void HourInterrupt() {
		
		foreach(Timer t in timers) {
			t.OnHourChange (GetHour());

			if(GetHour() == 0 || GetHour () == 24) {
				day++;
				t.OnDayChange (day);
			}
		}
	}

	private void MinuteInterrupt() {
		foreach(Timer t in timers) {
			t.OnMinuteChange (GetMinute());
		}
	}

	/**
	 * Return the current hour. 
	 */
	public int GetHour() {
		return Mathf.RoundToInt((time - (time % 3600f)) / 3600f);
	}

	public int GetMinute() {
		return Mathf.RoundToInt ((time - (time % 60f)) / 60f) % 60;
	}

}

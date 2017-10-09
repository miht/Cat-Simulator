using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour {

	public float strength = 0.1f;

	//The colors during day and night
	public Color day;
	public Color night;

	private Clock clock;
	private Light sun;

	// Use this for initialization
	void Start () {
		clock = GameObject.FindGameObjectWithTag ("Clock").GetComponent<Clock>();
		sun = GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float percentageOfDay = clock.getPercentageOfDay ();
		float dayNightRatio = clock.getDayNightRatio ();

		//The suns' rotation varies depending on the percentage of day. 24 pm means 360 degrees, which is the starting
		//rotation of the sun during a new day
		float rotX = percentageOfDay * 360f;
		transform.localRotation = Quaternion.Euler (new Vector3 (rotX + 90f, 0f, 0f));

		//The sun's intensity and color oscillates back and forward depending on the day/night ratio.
		sun.color = Color.Lerp (night, day, dayNightRatio);

		sun.intensity = 0.5f*strength * dayNightRatio + strength;

	}
}

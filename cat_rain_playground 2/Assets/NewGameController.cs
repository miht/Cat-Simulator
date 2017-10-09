using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RAIN.Core;
using UnityEngine.SceneManagement;

public class NewGameController : MonoBehaviour {

	public Vector3 destination = Vector3.zero;
	public float velocity = 1f;

	public GameObject decide_name_canvasObjects;
	public GameObject proceed_to_game_canvasObjects;

	private Animator anim;

	private bool moving = true;

	private string name = "Neko-chan";
	public InputField if_name;

	public Text txt_congratulations;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		if_name.onEndEdit.AddListener (delegate {SetName(if_name); });
	}
	
	// Update is called once per frame
	void Update () {
		

		if(moving) {
			transform.position += Vector3.right * velocity * Time.deltaTime;

			if(Vector3.Distance(transform.position, destination) < 0.1f) {
				velocity = 0f;
				Stop ();
			}

		}

	}

	private void Stop() {
		transform.localEulerAngles = new Vector3 (0f, 180f, 0f);
		anim.SetTrigger ("sit");
		moving = false;

		Invoke ("ShowCanvas", 1f);
	}

	private void ShowCanvas() {
		decide_name_canvasObjects.SetActive (true);
	}
		

	public void SetName(InputField if_input) {
		anim.SetTrigger ("cheer");
		string txt = if_name.text;
		if(txt.Length > 0) {
			this.name = txt;
		}
		else {
			this.name = "Neko-chan";
		}

		decide_name_canvasObjects.SetActive (false);
		ShowName ();

	}

	public void ShowName() {
		proceed_to_game_canvasObjects.SetActive (true);
		txt_congratulations.text = "Congratulations! Your kitten's new name is " + name + ".";
	}

	public void StartGame() {
		GameObject.Find ("GameControl").GetComponent<GameControl> ().NewGame ();
		GameObject.Find ("GameControl").GetComponent<GameControl>().catName = name;

		SceneManager.LoadScene ("Game");
	}
}

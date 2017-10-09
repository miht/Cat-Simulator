using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using RAIN.Core;
using UnityEngine.SceneManagement;

/**
 * Store the essential information within the game and save/load upon launch.
 * Writes to file
 */
public class GameControl : MonoBehaviour {

	public static GameControl control;

	public int day = 0;
	public bool hasPlayedTutorial = false;
	public float inGameTime;
	public String catName = "Neko-chan";

	// Use this for initialization
	void Awake () {
		if(control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		}
		else if(control != this) {
			Destroy (gameObject);
		}
	}

	void Start() {
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Escape)) {
			Save ();
			Application.Quit ();
		}
		if (Input.GetKeyDown (KeyCode.L)) {
			Load ();
		}
	}

	void OnApplicationQuit() {
		if(SceneManager.GetActiveScene ().name == "Game") {
			Save ();
		}
	}

	public void Save() {
		inGameTime = GameObject.FindGameObjectWithTag ("Clock").GetComponent<Clock>().GetTime();
		VariableController vc = GameObject.Find ("CatAI").GetComponent<VariableController> ();

		BinaryFormatter bf = new BinaryFormatter ();

		FileStream file = File.Create (Application.persistentDataPath + "/gameState.dat");

		GameData data = new GameData ();
		data.day = day;
		data.inGameTime = inGameTime;
		data.timestamp = System.DateTime.Now;

		data.name = catName;

		data.hunger = vc.hunger;
		data.thirst = vc.thirst;
		data.tiredness = vc.tired;
		data.boredom = vc.bored;
		data.need = vc.needy;
		data.dirtyness = vc.dirty;
		data.resources = vc.resources;
		data.hasPlayedTutorial = vc.hasPlayedTutorial;

		bf.Serialize (file, data);
		file.Close ();
	}

	public void Load() {
		Debug.Log (Application.persistentDataPath + "/gameState.dat");

		if(File.Exists (Application.persistentDataPath + "/gameState.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/gameState.dat", FileMode.Open);
			GameData data = (GameData)bf.Deserialize (file);
			file.Close ();

			inGameTime = data.inGameTime;

			TimeSpan timespan = System.DateTime.Now - data.timestamp;
			VariableController vc = GameObject.Find ("CatAI").GetComponent<VariableController> ();

			GameObject.Find("Time").GetComponent<Clock>().SetTime(inGameTime);
			//GameObject.FindGameObjectWithTag ("Time").GetComponent<Clock>().fastForwardTime (timespan.Seconds * Clock.rate);
			GameObject.Find ("Time").GetComponent<Clock>().SetDay(day);

			catName = data.name;

			vc.SetFloat ("Hunger", data.hunger);
			vc.SetFloat ("Thirst", data.thirst);
			vc.SetFloat ("Boredom", data.boredom);
			vc.SetFloat ("Tiredness", data.tiredness);
			vc.SetFloat ("Need", data.need);
			vc.SetFloat ("Dirtyness", data.dirtyness);
			vc.SetFloat ("Resources", data.resources);
			vc.hasPlayedTutorial = data.hasPlayedTutorial;

			GameObject.Find ("CatAI").GetComponent<AIRig> ().AI.Body = GameObject.Find ("Cat");
		}
	}

	public void NewGame() {
		Debug.Log (Application.persistentDataPath + "/gameState.dat");
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/gameState.dat");

		GameData data = new GameData ();
		data.timestamp = System.DateTime.Now;
		data.name = "Neko-chan";

		bf.Serialize (file, data);
		file.Close ();

		SceneManager.LoadScene ("NewGame");
	}

	public void LoadGame() {
		SceneManager.LoadScene ("Game");
	}
}

[Serializable]
class GameData {
	public int day = 0;
	public float inGameTime = 0f;
	public DateTime timestamp;
	public string name = "Neko-chan";
	public bool hasPlayedTutorial = false;

	public float hunger = 0f;
	public float thirst = 0f;
	public float boredom = 0f;
	public float tiredness = 0f;
	public float need = 0f;
	public float dirtyness = 0f;
	public float resources = 300f;

}

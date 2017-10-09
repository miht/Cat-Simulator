using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using RAIN.Core;

public class Turngame : MonoBehaviour {

	public TurnCatController tcc;

	public Button btn_right;
	public Button btn_left;
	public Button btn_newround;

	public Text txt_rounds;
	public Text txt_main;

	private int score = 0;
	public int round = 1;
	public int maxRounds = 5;

	private bool correct = false;


	// Use this for initialization
	void Start () {
		txt_main.text = "Can you guess which way the cat will turn? \nAs soon as you choose, the cat will start moving.";
		txt_rounds.text = "Score: " + score + ". Round: " + round + "/" + maxRounds;
	}

	public void ChooseDirection(int decision) {
		btn_left.gameObject.SetActive (false);
		btn_right.gameObject.SetActive (false);

		if(decision == tcc.direction) {
			correct = true;
		}
		else {
			correct = false;
		}

		Invoke ("RoundCheck", 2f);
		tcc.Move ();
	}

	private void RoundCheck() {
		if(correct) {
			txt_main.text = "Correct answer! Click the button to start the new round.";
			score++;
		}
		else {
			txt_main.text = "Wrong answer! Click the button to start the new round.";
		}

		if(round >= maxRounds) {
			txt_main.text = "The game has ended. Returning to the living room.";
			EndGame ();
		}
		tcc.StopMoving ();

		btn_newround.gameObject.SetActive (true);
	}

	private void EndGame() {
		
		GameObject.Find ("Cat").GetComponent <CatInteractable>().ActivateCat ();
		GameObject.Find ("CatAI").GetComponent<VariableController> ().AddScore ((float)score/(float)maxRounds);
		Debug.Log ("Score was " + (float)score/(float)maxRounds);
		Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void NewRound() {
		tcc.MoveBack ();
		btn_newround.gameObject.SetActive (false);
		round++;
		txt_rounds.text = "Score: " + score + ". Round: " + round + "/" + maxRounds;
		txt_main.text = "Can you guess which way the cat will turn? \nAs soon as you choose, the cat will start moving.";
		Invoke ("StartNewRound", 2f);
	}

	private void StartNewRound() {
		tcc.StopMoving ();
		btn_left.gameObject.SetActive (true);
		btn_right.gameObject.SetActive (true);

	}
}

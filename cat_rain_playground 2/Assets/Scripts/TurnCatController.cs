using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class handles the controls and behavior of the cat during the turn mini-game sequence.
 */
public class TurnCatController : MonoBehaviour {

	public int direction = 0;

	private Vector3 startPosition;
	private Quaternion startRotation;

	private Vector3 destination = Vector3.zero;

	public float velocity = 1f;

	Animator anim;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody> ();

		startPosition = transform.position;
		startRotation = transform.rotation;

		direction = GenerateDirection ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.X)) {
			Move ();
		}
		if(Input.GetKeyDown(KeyCode.C)) {
			MoveBack ();
		}
			
	}

	public void Move() {
		anim.SetBool ("moving", true);
		switch(direction) {
		case 0:
			destination = transform.position + Vector3.left*2f;
			break;
		case 1:
			destination = transform.position + Vector3.right*2f;
			break;
		default:
			break;
		}
		transform.LookAt (destination);

		rb.velocity = (destination - transform.position).normalized * velocity;
	}

	public void MoveBack() {
		anim.SetBool ("moving", true);
		destination = startPosition;
		transform.LookAt (destination);
		rb.velocity = (destination - transform.position).normalized * velocity;
		direction = GenerateDirection ();
	}

	public void StopMoving() {
		rb.velocity = Vector3.zero;
		transform.rotation = startRotation;
		anim.SetBool ("moving", false);
	}

	public int GenerateDirection() {
		int rand = Random.Range (0, 2);
		return rand;
	}


}

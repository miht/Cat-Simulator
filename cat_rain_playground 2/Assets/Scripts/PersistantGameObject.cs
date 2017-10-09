using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Used for game objects that should persist between scenes, such as the cat
 */
public class PersistantGameObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);

		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

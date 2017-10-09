using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RAIN.Core;
using UnityEngine.UI;
using System;

[Serializable]
public class VariableController : MonoBehaviour {

	AIRig aiRig;

	public float max = 100f;

	public float resources = 300f;

	public float hunger = 0f;
	public float thirst = 0f;
	public float bored = 0f;
	public float tired = 0f;
	public float needy = 0f;
	public float dirty = 0f;

	public float hungerIncreaseRate = 1f;
	public float thirstIncreaseRate = 1f;
	public float boredomIncreaseRate = 1f;
	public float tirednessIncreaseRate = 1f;
	public float dirtynessIncreaseRate = 1f;

	public float boredomDecreaseRate = 1f;
	public float tirednessDecreaseRate = 1f;
	public float dirtynessDecreaseRate = 1f;
	public float needynessDecreaseRate = 1f;

	public float walkSpeed = 3f;
	public float runSpeed = 7f;
	public float pounceSpeed = 1f;

	public Slider slider_hunger;
	public Slider slider_thirst;
	public Slider slider_bored;
	public Slider slider_tired;
	public Slider slider_needy;
	public Slider slider_dirty;
	public Slider slider_happy;

	public Text txt_resources;

	public bool hasPlayedTutorial = false;
	public Tutorial tutorial;

	// Use this for initialization
	void Start () {
		aiRig = GetComponent<AIRig> ();

		InitialiseVariables ();

		GameObject.Find ("GameControl").GetComponent<GameControl> ().Load ();

		//If tutorial has not been played, play it
		CheckTutorial();

		//Update the variables here
	}
	
	// Update is called once per frame
	void Update () {

		hunger = aiRig.AI.WorkingMemory.GetItem<float> ("Hunger") + Time.deltaTime *  hungerIncreaseRate;
	 	thirst = aiRig.AI.WorkingMemory.GetItem<float> ("Thirst") + Time.deltaTime *  thirstIncreaseRate;
	 	bored = aiRig.AI.WorkingMemory.GetItem<float> ("Boredom") + Time.deltaTime *  boredomIncreaseRate;
	 	tired = aiRig.AI.WorkingMemory.GetItem<float> ("Tiredness") + Time.deltaTime *  tirednessIncreaseRate;
	 	dirty = aiRig.AI.WorkingMemory.GetItem<float> ("Dirtyness") + Time.deltaTime *  dirtynessIncreaseRate;
	 	needy = aiRig.AI.WorkingMemory.GetItem<float> ("Need");
		resources = aiRig.AI.WorkingMemory.GetItem<float> ("Resources");
			
		//Update the variables here
		aiRig.AI.WorkingMemory.SetItem<float> ("Hunger", Mathf.Clamp (hunger, 0f, max));
		aiRig.AI.WorkingMemory.SetItem<float> ("Thirst", Mathf.Clamp (thirst, 0f, max));
		aiRig.AI.WorkingMemory.SetItem<float> ("Boredom", Mathf.Clamp (bored, 0f, max));
		aiRig.AI.WorkingMemory.SetItem<float> ("Tiredness", Mathf.Clamp (tired, 0f, max));
		aiRig.AI.WorkingMemory.SetItem<float> ("Dirtyness", Mathf.Clamp (dirty, 0f, max));
		aiRig.AI.WorkingMemory.SetItem<float> ("Need", Mathf.Clamp (needy, 0f, max));

		slider_hunger.value = hunger / max;
		slider_thirst.value = thirst / max;
		slider_bored.value = bored / max;
		slider_tired.value = tired / max;
		slider_needy.value = needy / max;
		slider_dirty.value = dirty / max;

		//Update the tail transform rotation here... Happy means high tail, unhappy means low..
		float happiness = (0.2f*hunger + 0.25f*thirst + 0.05f*bored + 0.25f*tired + 0.2f*needy + 0.05f*dirty);
		slider_happy.value = 1f - (happiness / max);

		txt_resources.text = "Resources left: " + Mathf.Round (resources * 1000f) / 1000f;
	}

	private void InitialiseVariables() {
		aiRig.AI.WorkingMemory.SetItem<float> ("Hunger", hunger);
		aiRig.AI.WorkingMemory.SetItem<float> ("Thirst", thirst);
		aiRig.AI.WorkingMemory.SetItem<float> ("Boredom", bored);
		aiRig.AI.WorkingMemory.SetItem<float> ("Tiredness", tired);
		aiRig.AI.WorkingMemory.SetItem<float> ("Dirtyness", dirty);
		aiRig.AI.WorkingMemory.SetItem<float> ("Need", needy);

		aiRig.AI.WorkingMemory.SetItem<float> ("Resources", resources);

		aiRig.AI.WorkingMemory.SetItem<float> ("playRate", boredomDecreaseRate);
		aiRig.AI.WorkingMemory.SetItem<float> ("sleepRate", tirednessDecreaseRate);
		aiRig.AI.WorkingMemory.SetItem<float> ("cleanRate", dirtynessDecreaseRate);
		aiRig.AI.WorkingMemory.SetItem<float> ("needRate", needynessDecreaseRate);

		aiRig.AI.WorkingMemory.SetItem<float> ("speed", walkSpeed);
		aiRig.AI.WorkingMemory.SetItem<float> ("runSpeed", runSpeed);
		aiRig.AI.WorkingMemory.SetItem<float> ("pounceSpeed", pounceSpeed);
	}

	public void SetFloat(string valueName, float value) {
		aiRig.AI.WorkingMemory.SetItem<float> (valueName, value);
	}

	public void AddScore(float score) {

		GameObject.Find ("UIController").GetComponent<UIController> ().Broadcast ("Congratulations. " +
		"You received a total of " + score * max + " points which has been converted into " + score * 3f * max + " resources");

		float r = aiRig.AI.WorkingMemory.GetItem<float> ("Resources");
		aiRig.AI.WorkingMemory.SetItem ("Resources", r + score  * 3f*max);
	}

	private void CheckTutorial() {
		if(!hasPlayedTutorial) {
			tutorial.enabled = true;
		}
	}
}

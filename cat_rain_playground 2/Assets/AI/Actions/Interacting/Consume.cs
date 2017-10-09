using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;
using RAIN.Serialization;
using RAIN.Representation;

/**
 * Customized RAIN AI class.
 * 
 * This action is done when the cat gets close enough to a consumable object to interact with it.
 * 
 */
[RAINAction]
public class Consume : RAINAction
{

	//The consumable object
	public Expression consumableVariable = new Expression();

	//WHat stat should this consumable affect? string
	public Expression statVariable = new Expression();

	//The consumable script of the consumable object
	private Consumable consum;

	public override void Start(RAIN.Core.AI ai) {
		GameObject consumable = GameObject.Find (consumableVariable.VariableName);
		consum = consumable.GetComponent<Consumable> ();

		//Look towards food when eating
		ai.Body.transform.LookAt (consumable.transform);

	}

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		float rate = consum.Rate;

		ai.WorkingMemory.SetItem<float> (statVariable.VariableName, ai.WorkingMemory.GetItem<float> (statVariable.VariableName) - rate * Time.deltaTime);

		//Get needy and dirty when eating or using litterbox
		float needy = ai.WorkingMemory.GetItem<float> ("Need");
		float dirty = ai.WorkingMemory.GetItem<float> ("Dirtyness");

		//0.3f stands for the rate of nutrition that is picked up by the body when eating
		ai.WorkingMemory.SetItem<float>("Need", needy + 0.3f* rate * Time.deltaTime);
		ai.WorkingMemory.SetItem<float> ("Dirtyness", dirty + Time.deltaTime);

		consum.Consume (rate * Time.deltaTime);

	
		if(consum.IsEmpty() || ai.WorkingMemory.GetItem<float>(statVariable.VariableName) <= 0f) {
			//no food left or not hungry/thirsty/needy
			return ActionResult.SUCCESS;
		}
		else {
			return ActionResult.FAILURE;
		}

    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;
using RAIN.Representation;

/**
 * Customized RAIN AI class.
 * 
 * This action checks if there is any food/drink/sand left in a given consumable.
 * 
 */
[RAINAction]
public class HasConsumable : RAINAction
{
	//The consumable to be checked.
	public Expression consumableVariable = new Expression();

	public override ActionResult Execute(RAIN.Core.AI ai)
	{

		GameObject consumable = GameObject.Find (consumableVariable.VariableName);
		Consumable consum = consumable.GetComponent<Consumable> ();

		if(consum.IsEmpty ()) {
			return ActionResult.FAILURE;
		}
		else {
			return ActionResult.SUCCESS;
		}
	}

	public override void Stop(RAIN.Core.AI ai)
	{
		base.Stop(ai);
	}
}
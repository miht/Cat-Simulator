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
 * This action is done when the cat gets close enough to a breakable object to interact with it.
 * 
 */

[RAINAction]
public class Break : RAINAction
{

	//The breakable object, passed on as a variable. Same object that the cat moves towards
	public Expression breakVariable = new Expression();

	//The breakable object's interactable script
	private Interactable inter;

	public override void Start(RAIN.Core.AI ai) {
		if (!breakVariable.IsVariable)
			throw new Exception("The interactable variable node requires a valid interactable Variable");

		ai.Body.transform.LookAt (ai.WorkingMemory.GetItem<GameObject> (breakVariable.VariableName).transform);
		inter = (Interactable)ai.WorkingMemory.GetItem<GameObject> (breakVariable.VariableName).GetComponent<Breakable> ();
	}

	public override ActionResult Execute(RAIN.Core.AI ai)
	{
		inter.Interact ();
		return ActionResult.SUCCESS;
	}

	public override void Stop(RAIN.Core.AI ai)
	{
		base.Stop(ai);
	}
}
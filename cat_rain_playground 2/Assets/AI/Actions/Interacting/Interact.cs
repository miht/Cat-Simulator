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
 * This action is done when the cat gets close enough to a interactable object to interact with it.
 * 
 */
[RAINAction]
public class Interact : RAINAction
{

	public Expression interactableVariable = new Expression();

	private Interactable inter;

	public override void Start(RAIN.Core.AI ai) {
		if (!interactableVariable.IsVariable)
			throw new Exception("The interactable variable node requires a valid interactable Variable");

		ai.Body.transform.LookAt (ai.WorkingMemory.GetItem<GameObject> (interactableVariable.VariableName).transform);
		inter = (Interactable)ai.WorkingMemory.GetItem<GameObject> (interactableVariable.VariableName).GetComponent<Interactable> ();
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
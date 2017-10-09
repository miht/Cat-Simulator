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
 * This action makes the cat face a target variable.
 * 
 */

[RAINAction]
public class FaceGameObject : RAINAction
{

	public Expression interactableVariable = new Expression();

	public override void Start(RAIN.Core.AI ai) {
	}

    public override ActionResult Execute(RAIN.Core.AI ai)
	{
		GameObject.Find ("CatAI").GetComponent<FaceForward> ().enabled = false;
		ai.Body.transform.LookAt (GameObject.Find(interactableVariable.VariableName).transform);
		return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}
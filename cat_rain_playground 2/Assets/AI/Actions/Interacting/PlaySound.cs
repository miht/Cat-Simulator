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
 * This action plays a sound from a given game object's audio source.
 * 
 */
[RAINAction]
public class PlaySound : RAINAction
{
	public Expression audioGameObject = new Expression();

	public override void Start(RAIN.Core.AI ai) {
	}

    public override ActionResult Execute(RAIN.Core.AI ai)
	{
		AudioSource as_object = GameObject.Find (audioGameObject.VariableName).GetComponent<AudioSource> ();
		as_object.enabled = !as_object.enabled;
		return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}
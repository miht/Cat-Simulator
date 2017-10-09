using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;
using RAIN.Serialization;

[RAINAction]
public class Eat : RAINAction
{
	
    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		GameObject food = (GameObject)ai.WorkingMemory.GetItem<GameObject> ("food");
		Consumable consum = food.GetComponent<Consumable> ();

		float rate = consum.Rate;

		ai.WorkingMemory.SetItem<float> ("Hunger", ai.WorkingMemory.GetItem<float> ("Hunger") - rate * Time.deltaTime);
		consum.Consume (rate * Time.deltaTime);

		return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}
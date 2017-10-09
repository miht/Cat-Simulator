using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;
using UnityEngine.AI;
using RAIN.Representation;

[RAINAction]
public class SetSpeed : RAINAction
{

	public Expression speed = new Expression();


	private NavMeshAgent nma;

    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
		nma = ai.Body.GetComponent<NavMeshAgent> ();

    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		nma.speed = speed.Evaluate<float> (Time.deltaTime, ai.WorkingMemory);
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}
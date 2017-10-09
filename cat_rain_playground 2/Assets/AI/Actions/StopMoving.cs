using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;
using UnityEngine.AI;

[RAINAction]
public class StopMoving : RAINAction
{

	private NavMeshAgent nma;

    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
		nma = ai.Body.GetComponent<NavMeshAgent> ();

    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		nma.ResetPath ();
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}
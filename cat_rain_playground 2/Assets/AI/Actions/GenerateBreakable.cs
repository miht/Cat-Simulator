using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using RAIN.Action;
using RAIN.Core;
using RAIN.Representation;
using RAIN.Animation;

[RAINAction]
public class GenerateBreakable : RAINAction
{

	public Expression randomBreakableVariable = new Expression ();

	private NavMeshAgent nma;
	Animator anim;

    public override ActionResult Execute(RAIN.Core.AI ai)
    {

		GameObject[] breakables = GameObject.FindGameObjectsWithTag ("Breakable");


		if(breakables.Length > 0) {
			int randItem = Random.Range (0, breakables.Length);
			ai.WorkingMemory.SetItem<GameObject> (randomBreakableVariable.VariableName, breakables[randItem]);
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
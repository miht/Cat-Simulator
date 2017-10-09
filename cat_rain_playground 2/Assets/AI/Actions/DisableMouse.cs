using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;
using RAIN.Representation;
using UnityEngine.AI;

[RAINAction]
public class DestroyObject : RAINAction
{

	public Expression objectVariable = new Expression();
    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		GameObject g = GameObject.Find ("MouseAI");
		g.GetComponent<AudioSource>().enabled = false;
		AIRig.FindRig (g).enabled = false;
		g.GetComponent<NavMeshAgent> ().enabled = false;
		g.GetComponent<MeshRenderer> ().enabled = false;

        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}
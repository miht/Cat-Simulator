using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;
using RAIN.Representation;
using UnityEngine.AI;

[RAINAction]
public class ResetMouse : RAINAction
{

	public Expression objectVariable = new Expression();

    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		GameObject g = GameObject.Find ("MouseAI");
		g.GetComponent<AudioSource>().enabled=true;
		AIRig.FindRig (g).enabled = true;
		g.GetComponent<NavMeshAgent> ().enabled = true;
		g.GetComponent<MeshRenderer> ().enabled = true;

		g.transform.position = GameObject.Find ("MouseSpawnPosition").transform.position;

		ai.WorkingMemory.SetItem<GameObject> (objectVariable.VariableName, g);

		return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}
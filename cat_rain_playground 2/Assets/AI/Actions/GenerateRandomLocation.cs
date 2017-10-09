using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using RAIN.Action;
using RAIN.Core;
using RAIN.Representation;
using RAIN.Animation;

[RAINAction]
public class GenerateRandomLocation : RAINAction
{

	public Expression randomLocationVariable = new Expression ();
	public Expression rangeVariable = new Expression();

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		float range = rangeVariable.Evaluate<float> (Time.deltaTime, ai.WorkingMemory);
		Vector3 randomDirection = Random.insideUnitSphere * range;

		randomDirection += ai.Body.gameObject.transform.position;

		NavMeshHit hit;
		NavMesh.SamplePosition(randomDirection, out hit, range, 1);
		Vector3 finalPosition = hit.position;

		ai.WorkingMemory.SetItem<Vector3> (randomLocationVariable.VariableName, finalPosition);
	
		return ActionResult.SUCCESS;

    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}
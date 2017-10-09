using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using RAIN.Action;
using RAIN.Core;
using RAIN.Representation;
using RAIN.Animation;

[RAINAction]
public class Move : RAINAction
{
	public Expression destinationVariable = new Expression();

	public Expression closestDistanceVariable = new Expression();

	private float closestDistance = 0.1f;

	private NavMeshAgent nma;
	Animator anim;

    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
		nma = ai.Body.GetComponent<NavMeshAgent> ();
		closestDistance = closestDistanceVariable.Evaluate<float> (Time.deltaTime, ai.WorkingMemory);
		GameObject.Find ("CatAI").GetComponent<FaceForward> ().enabled = true;
		nma.stoppingDistance = closestDistance;

		Vector3 dest = ai.Body.transform.position;

		if(!destinationVariable.IsVariable) {
			dest = GameObject.Find(destinationVariable.VariableName).transform.position;
		}
		else {
			Type type = ai.WorkingMemory.GetItemType (destinationVariable.VariableName);

			if(type == typeof(Vector3)) {
				dest = ai.WorkingMemory.GetItem<Vector3> (destinationVariable.VariableName);
			}
			else if(type == typeof(GameObject)){

				dest = ai.WorkingMemory.GetItem<GameObject> (destinationVariable.VariableName).transform.position;
			}
			else if(type == typeof(Transform)) {
				dest = ai.WorkingMemory.GetItem<Transform> (destinationVariable.VariableName).position;
			}
			else {
				dest = GameObject.Find(destinationVariable.VariableName).transform.position;
			}
		}
		nma.SetDestination(dest);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		
		float dist = Vector3.Distance (ai.Body.transform.position, nma.destination);
		if(dist <= closestDistance + Mathf.Epsilon) {
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
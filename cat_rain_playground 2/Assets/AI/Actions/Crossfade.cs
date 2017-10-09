using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;
using RAIN.Representation;

[RAINAction]
public class Crossfade : RAINAction
{

	public Expression state = new Expression();

	private Animator anim;

    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
		anim = GameObject.Find ("AI").GetComponent<Animator> ();
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		anim.CrossFade ("StandToSit", 0f);
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}
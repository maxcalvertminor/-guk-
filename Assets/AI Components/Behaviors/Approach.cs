using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Approach : Behavior
{
    public bool inRange;
    public bool hiding;
    public Approach(EnemyBehavior s) : base(s) {
        script = s;
        hiding = false;
    }

    public override void Accumulate()
    {
        priority += 0.3f * (inRange ? 0 : 1) + 0.2f * script.aggression;
    }

    public override void Queue()
    {
        Debug.Log(priority);
        script.queued = false;
    }
}

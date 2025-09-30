using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEvent
{
    public float damage, time;
    public Vector2 direction;

    public DamageEvent(float d, float t, Vector2 dir) {
        damage = d;
        time = t;
        direction = dir;
    }
}

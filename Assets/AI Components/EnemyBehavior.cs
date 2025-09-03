using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float health;
    public float speed;
    public float tiltSpeed;
    public Weapon weapon1;
    public Weapon weapon2;
    public GameObject head;
    public MainTankScript_Enemy lookAtPlayerScript;

    public bool queued;
    public List<Behavior> behaviors; 
    public State state;

    public float aggression;
    public float nervousness;
    public float perception;

    public List<Behavior> allBehaviors;

    // Start is called before the first frame update
    void Start()
    {
        allBehaviors = new List<Behavior> { new Approach(this) };
        behaviors = new List<Behavior>();
        lookAtPlayerScript = this.gameObject.GetComponent<MainTankScript_Enemy>();
        queued = false;
        SwitchState(State.Attacking);
        InvokeRepeating("PriorityUpdate", 0f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if(!queued) {
            Behavior priority = behaviors[0];
            foreach(Behavior behavior in behaviors) {
                if(behavior.priority > priority.priority) {
                    priority = behavior;
                }
            }
            queued = true;
            priority.Queue();
        }
    }

    public void SwitchState(State s) {
        state = s;
        switch(state) {
            case State.Inactive:
                break;
            case State.Roaming:
                break;
            case State.Attacking:
                behaviors.Clear();
                behaviors.AddRange(new Behavior[] { allBehaviors[0] });
                break;
        }
    }

    public void PriorityUpdate() {
        foreach(Behavior behavior in behaviors) {
            behavior.Accumulate();
        }
    }

    public enum State {
        Pool,
        Inactive,
        Stationary,
        Roaming,
        Attacking,
        Dead
    }

    public void TakeDamage(float damage){
        health -= damage;
        Debug.Log(health);
        if(health <= 0) {
            state = State.Dead;
        }
    }
}

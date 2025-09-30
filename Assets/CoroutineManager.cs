using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineManager : MonoBehaviour
{   
    public static List<Action> gizmos;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDrawGizmos() {
        if(gizmos != null) {
            foreach(Action gizmo in gizmos) {
                gizmo.Invoke();
            }
        }
    }

}

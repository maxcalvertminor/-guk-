using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction_of_Motion_Scipt : MonoBehaviour
{
    Quaternion to;
    private GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        to = new Quaternion(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = obj.transform.parent.gameObject.GetComponent<Rigidbody2D>().velocity.x;
        float yInput = obj.transform.parent.gameObject.GetComponent<Rigidbody2D>().velocity.y;
        float newAngle;

        if(xInput != 0 || yInput != 0) {
            newAngle = Mathf.Atan2(yInput, xInput) * Mathf.Rad2Deg;
            to = Quaternion.Euler(0, 0, newAngle - 90);
        }
        

        obj.transform.rotation = to;
    }
}

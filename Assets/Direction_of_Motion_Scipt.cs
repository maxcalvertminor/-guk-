using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction_of_Motion_Scipt : MonoBehaviour
{
    Quaternion to;
    private GameObject obj;
    public float tiltSpeed;
    public float fineTuning;

    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float xPos = Input.GetAxis("Horizontal");
        float yPos = Input.GetAxis("Vertical");

        float newAngle = Mathf.Atan2(yPos, xPos) * Mathf.Rad2Deg;

        //Debug.Log(newAngle);
        if(xPos != 0 || yPos != 0) {
            obj.transform.rotation = Quaternion.RotateTowards(obj.transform.rotation, Quaternion.Euler(0, 0, newAngle + fineTuning), tiltSpeed * Time.deltaTime);
        }
    }
}

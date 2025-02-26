using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTankMovement : MonoBehaviour
{

    public GameObject main;
    public Vector3 mousePos;
    public float tiltSpeed;
    public Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        float angle;
        float xPos = mousePos.x - /*(Screen.width/2)*/ mainCam.WorldToScreenPoint(main.transform.position).x;
        float yPos = mousePos.y - /*(Screen.height/2)*/ mainCam.WorldToScreenPoint(main.transform.position).y;
        if(xPos > 0) {
            angle = Mathf.Atan(yPos / xPos) * Mathf.Rad2Deg;
        } else {
            angle = Mathf.Atan(yPos / xPos) * Mathf.Rad2Deg + 180;
        }

        float newAngle = Mathf.Atan2(yPos, xPos) * Mathf.Rad2Deg;

        main.transform.rotation = Quaternion.RotateTowards(main.transform.rotation, Quaternion.Euler(0, 0, newAngle - 90), tiltSpeed * Time.deltaTime);

       // main.transform.eulerAngles = new Vector3(0, 0, newAngle-90);
    }
}

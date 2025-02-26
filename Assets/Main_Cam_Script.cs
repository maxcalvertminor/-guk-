using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Cam_Script : MonoBehaviour
{
    public GameObject player;
    public GameObject mainCam;
    public float camera_distance;
    public float smoothTime;
    private Rigidbody2D body;
    [SerializeField] private Vector2 acceleration = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        body = mainCam.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 camPos = mainCam.transform.position;
        Vector2 playerPos = player.transform.position;
        Vector2 holder = Vector2.SmoothDamp(camPos, playerPos, ref acceleration, smoothTime);
        mainCam.transform.position = new Vector3(holder.x, holder.y, camera_distance);
    }
}

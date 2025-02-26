using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootScript : MonoBehaviour
{
    public GameObject main;
    public GameObject movement_obj;
    public GameObject foot_left;
    public GameObject foot_right;
    public float seconds_between_steps;
    public float step_speed;
    private bool moving;
    private bool is_stepping;
    private bool right_or_left;
    public float x;
    public float y;
    public float z;
    private LineRenderer line_renderer;
    public float axle_width;
    public float tolerance;

    // Start is called before the first frame update
    void Start()
    {
        moving = true;
        is_stepping = false;
        right_or_left = true;
        line_renderer = movement_obj.GetComponent<LineRenderer>();
        line_renderer.positionCount = 4;
        line_renderer.useWorldSpace = true;
        line_renderer.alignment = LineAlignment.TransformZ;
    }

    // Update is called once per frame
    void Update()
    {
        line_renderer.SetPositions(new Vector3[4] {foot_left.transform.position, movement_obj.transform.TransformPoint(-axle_width, 0, 0), movement_obj.transform.TransformPoint(axle_width, 0, 0), foot_right.transform.position});
        if(main.GetComponent<Rigidbody2D>().velocity.magnitude > 0) {
            moving = true;
        } else {
            moving = false;
        }

        if(moving && !is_stepping) {
            if(right_or_left) {
                StartCoroutine(MyCoroutine(foot_right, x));
                right_or_left = false;
            } else {
                StartCoroutine(MyCoroutine(foot_left, -x));
                right_or_left = true;
            }
        }/* else if(!moving) {
            StartCoroutine(StepToPoint(foot_right, movement_obj.transform.TransformPoint(x, 0, z)));
            StartCoroutine(StepToPoint(foot_left, movement_obj.transform.TransformPoint(-x, 0, z)));
        } */

      /*  if(Vector2.Distance(foot_right.transform.position, movement_obj.transform.position) > tolerance) {
            StartCoroutine(StepToPoint(foot_right, movement_obj.transform.TransformPoint(x, y, z)));
        }
        if(Vector2.Distance(foot_left.transform.position, movement_obj.transform.position) > tolerance) {
            StartCoroutine(StepToPoint(foot_left, movement_obj.transform.TransformPoint(-x, y, z)));
        } */
    }

    /* IEnumerator MyCoroutine(GameObject foot, float deflection) {
        Vector3 startPoint = foot.transform.position;
        is_stepping = true;
        for(int i = 0; i < step_iterations; i++) {
            float fraction = (1 / step_iterations) * (i + 1);
            foot.transform.position = Vector3.Lerp(startPoint, movement_obj.transform.TransformPoint(deflection, y, z), fraction);
            Debug.Log(i);
            yield return new WaitForSecondsRealtime(seconds_for_steps / step_iterations);
        }

        yield return new WaitForSeconds(seconds_between_steps);
        is_stepping = false;
    } */

    // NEW METHOD
    IEnumerator MyCoroutine(GameObject foot, float deflection) {
        Vector3 startPoint = foot.transform.position;
        is_stepping = true;
        float fraction = 0;
        while(fraction < 1) {
            fraction += step_speed * Time.deltaTime;
            foot.transform.position = Vector3.Lerp(startPoint, movement_obj.transform.TransformPoint(deflection, y, z), fraction);
            yield return null;
        }

        yield return new WaitForSeconds(seconds_between_steps);
        is_stepping = false;
    }

    IEnumerator StepToPoint(GameObject foot, Vector3 point) {
        Vector3 startPoint = foot.transform.position;
        float fraction = 0;
        while(fraction < 1) {
            fraction += step_speed * Time.deltaTime;
            foot.transform.position = Vector3.Lerp(startPoint, point, fraction);
            yield return null;
        }
    }

}

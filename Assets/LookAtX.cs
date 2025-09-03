using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtX : MonoBehaviour
{
    public GameObject x;
    public float fineTuningConstant;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(x.transform.position.y - transform.position.y, x.transform.position.x - transform.position.x) * Mathf.Rad2Deg + fineTuningConstant);
    }
}

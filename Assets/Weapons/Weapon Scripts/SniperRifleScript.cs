using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperRifleScript : Weapon
{
    private Quaternion accuracy;
    public float firepoint_x;
    public float firepoint_y;
    public float firepoint_z;
    
    // Start is called before the first frame update
    void Start()
    {
        gun = gameObject;
        equipped = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void fire() {
        if(right_side) {
            Instantiate(projectile, gun.transform.TransformPoint(firepoint_x, firepoint_y, firepoint_z), gun.transform.rotation);
        } else {
            Instantiate(projectile, gun.transform.TransformPoint(-firepoint_x, firepoint_y, firepoint_z), gun.transform.rotation);
        }
        
    }
   /* public override void positionAtRight() {
        gun.transform.position = mainTank.transform.position;
        gun.transform.rotation = mainTank.transform.rotation;
        gun.transform.localPosition = new Vector3 (x, y, 0);
        gun.GetComponent<SpriteRenderer>().sprite = 
    } 

    public override void positionAtLeft() {
        gun.transform.position = mainTank.transform.position;
        gun.transform.rotation = mainTank.transform.rotation;
        gun.transform.localPosition = new Vector3 (-x, y, 0);
    } */
}
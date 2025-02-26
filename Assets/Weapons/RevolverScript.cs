using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverScript : Weapon
{
    private Quaternion accuracy;

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
        Instantiate(projectile, gun.transform.position, gun.transform.rotation);
    }
   /* public override void positionAtRight() {
        gun.transform.position = mainTank.transform.position;
        gun.transform.rotation = mainTank.transform.rotation;
        gun.transform.localPosition = new Vector3 (x, (float)0.2, 0);
    } 
    
    public override void positionAtLeft() {
        gun.transform.position = mainTank.transform.position;
        gun.transform.rotation = mainTank.transform.rotation;
        gun.transform.localPosition = new Vector3 (-x, y, 0);
    } */
}


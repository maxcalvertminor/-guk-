using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunScript : Weapon
{
    public int bulletCount;
    public float bulletVariation;
    private GameObject tempBullet;
    private Projectiles bullet;
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
        for(int i = 0; i < bulletCount; i++) {
            Instantiate(projectile, gun.transform.TransformPoint(firepoint_x, firepoint_y, firepoint_z) , Quaternion.Euler(gun.transform.rotation.eulerAngles.x, gun.transform.rotation.eulerAngles.y, gun.transform.rotation.eulerAngles.z + Random.Range(-bulletVariation, bulletVariation)));
            //tempBullet.transform.position += transform.forward * 100;
        }
    }

   /* public override void positionAtRight() {
        gun.transform.position = mainTank.transform.position;
        gun.transform.rotation = mainTank.transform.rotation;
        gun.transform.localPosition = new Vector3 (x, y, 0);
    } 

    public override void positionAtLeft() {
        gun.transform.position = mainTank.transform.position;
        gun.transform.rotation = mainTank.transform.rotation;
        gun.transform.localPosition = new Vector3 (-x, y, 0);
    } */
}
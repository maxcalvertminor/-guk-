using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public GameObject gun;
    public GameObject projectile;
    public int ammo;
    public bool equipped;
    public GameObject player;
    public GameObject mainTank;
    public Sprite ground;
    public Sprite attached_right;
    public Sprite attached_left;
    public float x;
    public float y;
    public bool right_side;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void fire() {
        
    }

    public int getAmmo() {
        return ammo;
    }

    public virtual void positionAtRight() {
        Debug.Log("RIGHT");
    } 

    public virtual void positionAtLeft() {
        Debug.Log("LEFT");
    }

    public bool isEquipped() {
        return equipped;
    }

    public void setEquipped(bool helper) {
        equipped = helper;
    } 

    public GameObject getProjectile() {
        return projectile;
    }

    public void attach(bool rightorleft, GameObject actuator) {
        if(rightorleft) {
            gun.transform.position = actuator.transform.position;
            gun.transform.rotation = actuator.transform.rotation;
            gun.transform.localPosition = new Vector3 (x, y, 0);
            gun.GetComponent<SpriteRenderer>().sprite = attached_right;
            actuator.GetComponent<Arm_Actuator_Script>().attach(true);
            right_side = true;
        } else {
            gun.transform.position = actuator.transform.position;
            gun.transform.rotation = actuator.transform.rotation;
            gun.transform.localPosition = new Vector3 (-x, y, 0);
            gun.GetComponent<SpriteRenderer>().sprite = attached_left;
            actuator.GetComponent<Arm_Actuator_Script>().attach(true);
            right_side = false;
        } 
        
    }

    public void detach(GameObject actuator) {
        gun.GetComponent<SpriteRenderer>().sprite = ground;
        actuator.GetComponent<Arm_Actuator_Script>().attach(false);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{

    private int ammoRight;
    private int ammoLeft;
    private GameObject player;
    public GameObject mainTank;
    public GameObject actuator_left;
    public GameObject actuator_right;
    private GameObject weaponRight;
    private GameObject weaponLeft;
    private Weapon scriptRight;
    private Weapon scriptLeft;
    private bool hasWeaponRight;
    private bool hasWeaponLeft;
    private int triggerNum;
    private Collider2D coll;
    public float spritePos;
    public GameObject ammoPip;
    public Sprite fullAmmo;
    public Sprite emptyAmmo;
    private List<GameObject> ammoSprites;
    public int maxSpriteSpace;
    public int distanceBetweenSprites;
    public GameObject canvas;
    private List<GameObject> triggerList;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject;
        ammoRight = 0;
        ammoLeft = 0;
        hasWeaponRight = false;
        hasWeaponLeft = false;
        ammoSprites = new List<GameObject>();
        triggerNum = 0;
        triggerList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && ammoLeft > 0 && hasWeaponLeft) {
            scriptLeft.fire();
            ammoLeft--;
        //    ammoSprites[ammoLeft].GetComponent<Image>().sprite = emptyAmmo;
            //Debug.Log(ammoLeft);
        }
        if(Input.GetMouseButtonDown(1) && ammoRight > 0 && hasWeaponRight) {
            scriptRight.fire();
            ammoRight--;
        //    ammoSprites[ammoRight].GetComponent<Image>().sprite = emptyAmmo;
            //Debug.Log(ammoRight);
        }

        if(Input.GetButtonDown("Reload")) {

            if(hasWeaponRight) {
                ammoRight = scriptRight.getAmmo();
                //Debug.Log(ammoRight + " RIGHT");
               /* for(int i = 0; i < scriptRight.getAmmo(); i++) {
                    ammoSprites[i].GetComponent<Image>().sprite = fullAmmo;
                } */
            }
            if(hasWeaponLeft) {
                ammoLeft = scriptLeft.getAmmo();
                //Debug.Log(ammoLeft + " LEFT");
               /* for(int i = 0; i < scriptLeft.getAmmo(); i++) {
                    ammoSprites[i].GetComponent<Image>().sprite = fullAmmo;
                } */
            }
            
        }

        if(Input.GetButtonDown("Pickup Right")) {
            if(hasWeaponRight == false && triggerNum > 0) {
                // RIGHT PICKUP
                weaponRight = coll.gameObject;
                weaponRight.transform.SetParent(actuator_right.transform);
                OnTriggerExit2D(weaponRight.GetComponent<Collider2D>());
                weaponRight.tag = "Player";
                scriptRight = weaponRight.GetComponent<Weapon>();
                scriptRight.attach(true, actuator_right);
                ammoRight = scriptRight.getAmmo();

               /* ammoSprites.Capacity = scriptRight.getAmmo();
                //Debug.Log(ammoSprites.Count);
                int space = maxSpriteSpace;
                //if(allowedSpriteSpace / ammo > maxSpriteSpace) {space = maxSpriteSpace;}else{space = allowedSpriteSpace / ammo;}
                float first = Screen.width / 2 - (distanceBetweenSprites * (scriptRight.getAmmo() - 1) / 2);
                for(int i = 0; i < scriptRight.getAmmo(); i++) {
                    //Debug.Log(i);
                    ammoSprites.Add(Instantiate(ammoPip, player.transform.position, player.transform.rotation));
                    ammoSprites[i].GetComponent<Image>().sprite = fullAmmo;
                    ammoSprites[i].transform.SetParent(canvas.transform);
                    ammoSprites[i].transform.position = new Vector3 (first + (i * distanceBetweenSprites), Screen.height / 2 + spritePos, 0);
                } */
                hasWeaponRight = true;
            } else if(hasWeaponRight == true) {
                // RIGHT DROP
                weaponRight.transform.SetParent(null);
                weaponRight.tag = "Weapon";
                OnTriggerEnter2D(weaponRight.GetComponent<Collider2D>());
                scriptRight.setEquipped(false);
                scriptRight.detach(actuator_right);
                ammoRight = 0;
                hasWeaponRight = false;
              /*  for(int i = 0; i < scriptRight.getAmmo(); i++) {
                    Destroy(ammoSprites[scriptRight.getAmmo() - i - 1]);
                }
                ammoSprites.Clear();  */
                weaponRight = null;
                scriptRight = null;
            }
        }

        if(Input.GetButtonDown("Pickup Left")) {
            if(hasWeaponLeft == false && triggerNum > 0) {
                // LEFT PICKUP
                weaponLeft = coll.gameObject;
                weaponLeft.transform.SetParent(actuator_left.transform);
                OnTriggerExit2D(weaponLeft.GetComponent<Collider2D>());
                weaponLeft.tag = "Player";
                scriptLeft = weaponLeft.GetComponent<Weapon>();
                scriptLeft.attach(false, actuator_left);
                ammoLeft = scriptLeft.getAmmo();

              /*  ammoSprites.Capacity = scriptLeft.getAmmo();
                //Debug.Log(ammoSprites.Count);
                int space = maxSpriteSpace;
                //if(allowedSpriteSpace / ammo > maxSpriteSpace) {space = maxSpriteSpace;}else{space = allowedSpriteSpace / ammo;}
                float first = Screen.width / 2 - (distanceBetweenSprites * (scriptLeft.getAmmo() - 1) / 2);
                for(int i = 0; i < scriptLeft.getAmmo(); i++) {
                    //Debug.Log(i);
                    ammoSprites.Add(Instantiate(ammoPip, player.transform.position, player.transform.rotation));
                    ammoSprites[i].GetComponent<Image>().sprite = fullAmmo;
                    ammoSprites[i].transform.SetParent(canvas.transform);
                    ammoSprites[i].transform.position = new Vector3 (first + (i * distanceBetweenSprites), Screen.height / 2 + spritePos, 0);
                }  */
                hasWeaponLeft = true;
            } else if(hasWeaponLeft == true) {
                // LEFT DROP
                weaponLeft.transform.SetParent(null);
                weaponLeft.tag = "Weapon";
                OnTriggerEnter2D(weaponLeft.GetComponent<Collider2D>());
                scriptLeft.setEquipped(false);
                scriptLeft.detach(actuator_left);
                ammoLeft = 0;
                hasWeaponLeft = false;
              /*  for(int i = 0; i < scriptLeft.getAmmo(); i++) {
                    Destroy(ammoSprites[scriptLeft.getAmmo() - i - 1]);
                }
                ammoSprites.Clear();  */
                weaponLeft = null;
                scriptLeft = null;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Weapon")) {
            triggerNum++;
            triggerList.Add(other.gameObject);
            coll = other;
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("Weapon")) {
            int min = 0;
            for(int i = 1; i < triggerList.Count; i++) {
                float a = Vector2.Distance(new Vector2(player.transform.position.x, player.transform.position.y), new Vector2(triggerList[i].transform.position.x, triggerList[i].transform.position.y));
                float b = Vector2.Distance(new Vector2(player.transform.position.x, player.transform.position.y), new Vector2(triggerList[i - 1].transform.position.x, triggerList[i - 1].transform.position.y));
                if(a < b) {
                    min = i;
                }
            }
            coll = triggerList[min].GetComponent<Collider2D>();
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Weapon")) {
            triggerNum--;
            triggerList.Remove(other.gameObject);
        }
    }

    // && !other.gameObject.GetComponent<RevolverScript>().isEquipped() && !hasWeapon
}

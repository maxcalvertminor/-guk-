using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Projectiles : MonoBehaviour
{

    public float range;
    public float speed;
    public float damage;

    RaycastHit2D hit;

    public GameObject projectile;
    public Rigidbody2D body;
    public Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(Vector3.up * 0.6f);
        hit = Physics2D.Raycast(transform.position, transform.up);
        if(hit && hit.transform.tag == "Enemy") {
            hit.transform.GetComponent<EnemyBehavior>().raycastsInCollider++;
//            Debug.Log(hit.transform.GetComponent<EnemyBehavior>().raycastsInCollider + ", RiC");
        }
        Destroy(projectile, range);
        direction = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = transform.up * speed;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        switch(collision.gameObject.tag) {
            case "Walls":
                Destroy(projectile);
                break;
            case "Enemy":
                collision.gameObject.GetComponent<EnemyBehavior>().TakeDamage(damage, direction);
                Destroy(projectile);
                break;
        }
    }

    public void setup(float variation) {
        body.transform.position += transform.forward * Random.Range(-variation, variation);
    }

    void OnDestroy() {
        if(hit && hit.transform.tag == "EnemyProximityTrigger") {
            hit.transform.GetComponent<EnemyBehavior>().raycastsInCollider--;
//            Debug.Log(hit.transform.GetComponent<EnemyBehavior>().raycastsInCollider + ", RiC");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectiles : MonoBehaviour
{

    public float range;
    public float speed;
    public float damage;

    public GameObject projectile;
    public Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(Vector3.up * 0.6f);
        Destroy(projectile, range);
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = transform.up * speed;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Walls") {
            Destroy(projectile);
        } else if(collision.gameObject.tag == "Enemy") {
            collision.gameObject.GetComponent<EnemyBehavior>().TakeDamage(damage);
            Destroy(projectile);
        }
    }

    public void setup(float variation) {
        body.transform.position += transform.forward * Random.Range(-variation, variation);
    }
}

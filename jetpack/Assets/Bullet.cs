using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    Vector2 direction;
    public Transform gun;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        rb.AddForce(speed * transform.right * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        collision.GetComponent<BossHealth>().TakeDamage(10);
    }
}

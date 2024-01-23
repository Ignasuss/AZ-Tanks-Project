using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletfly : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * Speed;
    }

    void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        
    }

    

    Vector3 lastVelocity;
    

    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        // Reflect the velocity of the bullet on any collision
        Vector2 reflection = Vector2.Reflect(rb.velocity, collision.contacts[0].normal);
        rb.velocity = reflection;
    }
}    

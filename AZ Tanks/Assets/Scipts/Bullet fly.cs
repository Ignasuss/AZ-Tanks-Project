using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletfly : MonoBehaviour
{
    public float Speed;
    public float lifetime = 5.0f; // Time in seconds before the bullet disappears
    private Rigidbody2D rb;

    private bool canShoot = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * Speed;

        // Set drag to zero to prevent speed loss over time
        rb.drag = 0f;

        // Schedule the destruction of the bullet after 'lifetime' seconds
        Destroy(gameObject, lifetime);
    }

    // Function to check if the tank can shoot
    public bool CanShoot()
    {
        return canShoot;
    }

    // Function to be called when the tank shoots
    public void Shoot()
    {
        if (canShoot)
        {
            // Perform shooting logic here
            // For example, instantiate a bullet prefab or enable a bullet object in the scene

            // Set canShoot to false to prevent shooting until the bullet is destroyed
            canShoot = false;
        }
    }
}    

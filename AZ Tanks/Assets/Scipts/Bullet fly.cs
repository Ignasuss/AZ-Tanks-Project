using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class Bulletfly : MonoBehaviour
{
    public float Speed;
    public float lifetime = 5.0f; 
    private Rigidbody2D rb;

    private bool canShoot = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * Speed;

       
        rb.drag = 0f;

        Destroy(gameObject, lifetime);
    }

    
    public bool CanShoot()
    {
        return canShoot;
    }

    
    public void Shoot()
    {
        if (canShoot)
        {
            
            canShoot = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name=="Player 1")
        {
            Destroy(collision.gameObject);
            if (SceneManager.GetActiveScene().name == "6") SceneManager.LoadScene("1");

            SceneManager.LoadScene((Convert.ToInt32(SceneManager.GetActiveScene().name) + 1).ToString()); ;

        }
        if (collision.gameObject.name == "Player 2")
        {
            Destroy(collision.gameObject);
            if (SceneManager.GetActiveScene().name == "6") SceneManager.LoadScene("1");

            SceneManager.LoadScene((Convert.ToInt32(SceneManager.GetActiveScene().name) + 1).ToString()); ;

        }
    }
}    
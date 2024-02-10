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
    public GameObject shrapnel;
    private GameObject temp;
    private Vector3 pos;
    private float dmg;
    private void Update()
    {
        pos = transform.position;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * Speed;
        rb.drag = 0f;
        Destroy(gameObject, lifetime);
        if (name.Contains("Shrapnel"))
        {
            dmg = 8f;
        }
        if (name.Contains("Bomb"))
        {
            dmg = 45f;
        }
        if (name.Contains("Bullet"))
        {
            dmg = 18f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player 1")
        {
            collision.gameObject.GetComponent<Player1>().reduceHealth(dmg);
            Destroy(gameObject);
        }
        if(collision.gameObject.name == "Player 2")
        {
            collision.gameObject.GetComponent<Player2>().reduceHealth(dmg);
            Destroy(gameObject);
        }
        
    }
    private void OnDestroy()
    {
        if (gameObject.name.Contains("Bomb"))
        {
            for(int i = 0; i < 15; i++)
            {
                temp = Instantiate(shrapnel,position:pos,rotation:Quaternion.AngleAxis(((float)new System.Random().Next(0,360)),Vector3.forward));
                temp.name = "Shrapnel";
                temp = null;
            }
        }
    }
}    
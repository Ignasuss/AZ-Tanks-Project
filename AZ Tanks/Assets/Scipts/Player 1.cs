using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Player1 : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;
    private float health = 100;
    private GameObject health1;
    public GameObject healthOb1;
    private float origX;
    private bool dead = false;

    private void Start()
    {
        health1 = Instantiate(healthOb1, position: new Vector3(-2.488098f, -5.226721f), rotation: Quaternion.identity);
        origX = health1.transform.localScale.x;
    }
    void Update()
    {
        if (!dead)
        {
            float angleInRadians = Mathf.Deg2Rad * (transform.rotation.eulerAngles.z - 90f);
            if (Input.GetKey(KeyCode.W))
            {

                transform.position = new Vector2(transform.position.x - Mathf.Cos(angleInRadians) * Time.deltaTime * moveSpeed, transform.position.y - Mathf.Sin(angleInRadians) * Time.deltaTime * moveSpeed);
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.position = new Vector2(transform.position.x + Mathf.Cos(angleInRadians) * Time.deltaTime * moveSpeed, transform.position.y + Mathf.Sin(angleInRadians) * Time.deltaTime * moveSpeed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, 0, -rotateSpeed * Time.deltaTime);
            }
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(gameObject.GetComponent<SpriteRenderer>().color.r, gameObject.GetComponent<SpriteRenderer>().color.g, gameObject.GetComponent<SpriteRenderer>().color.b, gameObject.GetComponent<SpriteRenderer>().color.a - Time.deltaTime / 3);
        }


    }

    public void reduceHealth(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Invoke("Die", 3f);
            dead = true;
        }
        health1.GetComponent<Transform>().localScale = new Vector2(origX*(health / 100f < 0?0: health / 100f), health1.GetComponent<Transform>().localScale.y);
        health1.GetComponent<Transform>().position = new Vector2(-5f+ health1.GetComponent<Transform>().localScale.x/2, health1.GetComponent<Transform>().position.y);
    }

    private void Die()
    {

        if (SceneManager.GetActiveScene().name.Contains("6")) SceneManager.LoadScene("1");
        SceneManager.LoadScene((Convert.ToInt32(SceneManager.GetActiveScene().name) + 1).ToString());
    }
}
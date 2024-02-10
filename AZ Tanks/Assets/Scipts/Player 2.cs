

using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Player2 : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;
    private float health = 100;
    private GameObject health2;
    public GameObject healthOb2;
    private float origX;
    private void Start()
    {
        health2 = Instantiate(healthOb2, position: new Vector3(2.5f, -5.226721f), rotation: Quaternion.identity);
        origX = health2.transform.localScale.x;    
    }
    public void Update()
    {

        float angleInRadians = Mathf.Deg2Rad * (transform.rotation.eulerAngles.z - 90f);
        if (Input.GetKey(KeyCode.I))
        {

            transform.position = new Vector2(transform.position.x - Mathf.Cos(angleInRadians) * Time.deltaTime * moveSpeed, transform.position.y - Mathf.Sin(angleInRadians) * Time.deltaTime * moveSpeed);
        }

        if (Input.GetKey(KeyCode.K))
        {
            transform.position = new Vector2(transform.position.x + Mathf.Cos(angleInRadians) * Time.deltaTime * moveSpeed, transform.position.y + Mathf.Sin(angleInRadians) * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.J))
        {
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.L))
        {
            transform.Rotate(0, 0, -rotateSpeed * Time.deltaTime);
        }
    }

    public void reduceHealth(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            if (SceneManager.GetActiveScene().name.Contains("6")) SceneManager.LoadScene("1");

            SceneManager.LoadScene((Convert.ToInt32(SceneManager.GetActiveScene().name) + 1).ToString());
        }
        else
        {
            health2.GetComponent<Transform>().localScale = new Vector2(origX * (health / 100f), health2.GetComponent<Transform>().localScale.y);
            health2.GetComponent<Transform>().position = new Vector2(5f - health2.GetComponent<Transform>().localScale.x / 2, health2.GetComponent<Transform>().position.y);
        }
    }
}



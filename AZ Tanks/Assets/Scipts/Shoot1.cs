using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Shoot : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    private float cooldown = 0f;

    private float a = 5f;
    void Update()
    {
        cooldown += Time.deltaTime;
        if (Keyboard. current. cKey .wasPressedThisFrame && cooldown>=a)
        {
            cooldown = 0f;
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name.Contains("3"))
        {
            a = 1f;
            cooldown = a;
            Destroy(collision.gameObject);
        }
    }
}

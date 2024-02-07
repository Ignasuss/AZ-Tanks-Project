using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Shoot : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public GameObject bulletPrefabBomb;
    public string key;
    private float cooldown = 0f;
    private bool b = true;
    private float a = 5f;
    private bool shot = false;
    private float c = 15f;
    void Update()
    {
        if(b)cooldown += Time.deltaTime;
        if (key == "c" ? Keyboard.current.cKey.wasPressedThisFrame : Keyboard.current.nKey.wasPressedThisFrame && cooldown >= a && b)
        {
            cooldown = 0f;
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
        }
        if (!b && !shot && key == "c" ? Keyboard.current.cKey.wasPressedThisFrame : Keyboard.current.nKey.wasPressedThisFrame)
        {
            shot = true;
            Instantiate(bulletPrefabBomb, shootingPoint.position, transform.rotation);
            cooldown = 0f;
        }
        if(!b && shot)
        {
            cooldown += Time.deltaTime;
            if(cooldown > c)
            {
                b = true;
                shot = false;
                cooldown = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name.Contains("3") && b)
        {
            a = 1f;
            cooldown = a;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name.Contains("2"))
        {
            b = false;
            cooldown = c;
            Destroy(collision.gameObject);
        }
    }
}

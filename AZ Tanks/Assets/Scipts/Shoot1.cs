using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Shoot : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public GameObject shrapnel;
    public GameObject bulletPrefabBomb;
    public string key;
    private GameObject temp;
    private float cooldown = 0f;
    private bool b = true;
    private float a = 5f;
    private bool shot = false;
    private float c = 15f;
    void Update()
    {
        if(b)cooldown += Time.deltaTime;
        if ((key == "c" ? Keyboard.current.cKey.wasPressedThisFrame : Keyboard.current.nKey.wasPressedThisFrame) && cooldown >= a && b)
        {
            cooldown = 0f;
            Instantiate(a==0.5f?shrapnel:bulletPrefab, shootingPoint.position, transform.rotation);
        }
        if (!b && !shot && (key == "c" ? Keyboard.current.cKey.wasPressedThisFrame : Keyboard.current.nKey.wasPressedThisFrame))
        {
            shot = true;
            temp = Instantiate(bulletPrefabBomb, shootingPoint.position, transform.rotation);
            temp.name = $"Bomb{(key=="c"?"1":"2")}";
            cooldown = 0f;
        }
        if(!b && shot)
        {
            if ((key == "c" ? Keyboard.current.cKey.wasPressedThisFrame : Keyboard.current.nKey.wasPressedThisFrame) && cooldown > 1f)
            {
                Destroy(temp);
                temp = null;
            }
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
            a = 0.5f;
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

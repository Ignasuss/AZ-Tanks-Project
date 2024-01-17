using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 15f;

    void Start()
    {
        // Set the bullet to destroy itself after the specified lifetime
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Bounce off walls
        if (collision.gameObject.CompareTag("Wall"))
        {
            Reflect(collision.contacts[0].normal);
        }
    }

    void Reflect(Vector2 normal)
    {
        // Reflect the bullet's direction based on the wall's normal
        Vector2 reflection = Vector2.Reflect(transform.right, normal);
        transform.right = reflection;
    }
}


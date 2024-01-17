using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Prevent the character from spinning upon collision
        rb.freezeRotation = true;
    }

    void Update()
    {
        // Input
        movement.x = Input.GetKey(KeyCode.L) ? 1 : Input.GetKey(KeyCode.J) ? -1 : 0;
        movement.y = Input.GetKey(KeyCode.I) ? 1 : Input.GetKey(KeyCode.K) ? -1 : 0;

        // Rotate the character to face the direction of movement
        if (movement != Vector2.zero)
        {
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle - 90); // Subtract 90 to adjust for sprite's upward orientation
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Stop the character when it collides with a wall
        if (collision.gameObject.CompareTag("Wall"))
        {
            movement = Vector2.zero;
        }
    }
}



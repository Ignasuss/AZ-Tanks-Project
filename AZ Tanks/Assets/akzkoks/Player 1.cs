using UnityEngine;

public class Player1 : MonoBehaviour
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
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

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

    void Shoot()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }




    //public float moveSpeed = 5;

    //void Update()
    //{

    //    if (Input.GetKey(KeyCode.D))
    //    {
    //        transform.position += Vector3.right * moveSpeed * Time.deltaTime;

    //    }
    //    else if (Input.GetKey(KeyCode.A))
    //    {
    //        transform.position += Vector3.right * -moveSpeed * Time.deltaTime;

    //    }

    //    else if (Input.GetKey(KeyCode.W))
    //    {
    //        transform.position += Vector3.up * moveSpeed * Time.deltaTime;

    //    }
    //    else if (Input.GetKey(KeyCode.S))
    //    {
    //        transform.position += Vector3.up * -moveSpeed * Time.deltaTime;

    //    }
    //    if (movement != Vector2.zero)
    //    {
    //      float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
    //      transform.rotation = Quaternion.Euler(0f, 0f, angle - 90); // Subtract 90 to adjust for sprite's upward orientation
    //    }
    //}

}



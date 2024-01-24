using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    public float rotateSpeed;
    private Vector2 movement;
    public string verticalAxis;
    public string horizontalAxis;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Prevent the character from spinning upon collision
    }

    void Update()
    {
        // Input
        //movement.x = Input.GetKey(KeyCode.L) ? 1 : Input.GetKey(KeyCode.J) ? -1 : 0;
        //movement.y = Input.GetKey(KeyCode.I) ? 1 : Input.GetKey(KeyCode.K) ? -1 : 0;

        float angleInRadians = Mathf.Deg2Rad * (transform.rotation.eulerAngles.z-90f);
        if (Input.GetKey(KeyCode.W))
        {
            
            transform.position = new Vector2(transform.position.x-Mathf.Cos(angleInRadians)*Time.deltaTime*moveSpeed, transform.position.y - Mathf.Sin(angleInRadians) * Time.deltaTime*moveSpeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector2(transform.position.x + Mathf.Cos(angleInRadians) * Time.deltaTime*moveSpeed, transform.position.y + Mathf.Sin(angleInRadians) * Time.deltaTime*moveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, -rotateSpeed * Time.deltaTime);
        }
        // Rotate the character to face the direction of movement
        //if (movement != Vector2.zero)
        //{
        //    float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
        //    transform.rotation = Quaternion.Euler(0f, 0f, angle - 90); // Subtract 90 to adjust for sprite's upward orientation
        //}
    }

    //void FixedUpdate()
    //{
      //  rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    //}

}



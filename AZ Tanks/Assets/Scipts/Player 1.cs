using UnityEngine;

public class Player1 : MonoBehaviour
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
    }

    void Update()
    {

        float angleInRadians = Mathf.Deg2Rad * (transform.rotation.eulerAngles.z-90f);
        if (Input.GetKey(KeyCode.W))
        {
            
            transform.position = new Vector2(transform.position.x-Mathf.Cos(angleInRadians)*Time.deltaTime*moveSpeed, transform.position.y - Mathf.Sin(angleInRadians) * Time.deltaTime*moveSpeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector2(transform.position.x + Mathf.Cos(angleInRadians) * Time.deltaTime*moveSpeed, transform.position.y + Mathf.Sin(angleInRadians) * Time.deltaTime*moveSpeed);
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


}
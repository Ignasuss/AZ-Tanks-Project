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
        
    }

    void Update()
    {
        

        float angleInRadians = Mathf.Deg2Rad * (transform.rotation.eulerAngles.z-90f);
        if (Input.GetKey(KeyCode.I))
        {
            
            transform.position = new Vector2(transform.position.x-Mathf.Cos(angleInRadians)*Time.deltaTime*moveSpeed, transform.position.y - Mathf.Sin(angleInRadians) * Time.deltaTime*moveSpeed);
        }

        if (Input.GetKey(KeyCode.K))
        {
            transform.position = new Vector2(transform.position.x + Mathf.Cos(angleInRadians) * Time.deltaTime*moveSpeed, transform.position.y + Mathf.Sin(angleInRadians) * Time.deltaTime*moveSpeed);
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

   
}



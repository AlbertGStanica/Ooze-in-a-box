using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    bool isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;
    int count = 1;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        CheckIfGrounded();

    }

    void Move() { 
    float x = Input.GetAxisRaw("Horizontal"); 
    float moveBy = x * speed; 
    rb.velocity = new Vector2(moveBy, rb.velocity.y); 
}

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            
            
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == false && count < 2)
        {

            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            count++;

        }
    }

    void CheckIfGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);
        if (collider != null)
        {
            isGrounded = true;
            count = 1;
        }
        else
        {
            isGrounded = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public int hits;
    public AudioSource jumpSound;
    public AudioSource hitSFX;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        jumpSound = GetComponent<AudioSource>();
        
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
            jumpSound.Play();
            
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == false && count < 2)
        {

            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            count++;
            jumpSound.Play();
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

    public void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("platform"))
        {

            player.transform.parent = other.gameObject.transform;

        }
        if(other.gameObject.CompareTag("enemy"))
        {

            

                hits++;
            hitSFX.Play();

            if (hits >= 3)
            {

                SceneManager.LoadScene("Start Menu");
            }
            

        }
    }

    public void OnCollisionExit2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("platform"))
        {

            player.transform.parent = null;

        }
    }
}

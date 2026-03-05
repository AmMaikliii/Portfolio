using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform transform;
    public SpriteRenderer render;
    public Animator animator;
    
    public bool isFalling = true;
    public float jumpForce = 5f;
    public float moveSpeed = 5f;
    public float sensitivity = 5f;
    //public float Magnitude = 0f;


    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
        render = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        // left/right - referenced Tony's code
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                animator.SetBool("MovingRight", false);
                animator.SetBool("MovingLeft", false);
            }
            else 
            {
                animator.SetBool("MovingRight", true);
                animator.SetBool("MovingLeft", false);
            }
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                animator.SetBool("MovingRight", false);
                animator.SetBool("MovingLeft", false);
            }
            else 
            {
                animator.SetBool("MovingRight", false);
                animator.SetBool("MovingLeft", true);
            }
        }
        else
        {
            animator.SetBool("MovingRight", false);
            animator.SetBool("MovingLeft", false);
        }

        //jump 
        /*if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && isFalling == false)
        {
            print("Jump!");
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }*/

        //flip
        /*
        Magnitude = rb.velocity.magnitude;
        if (rb.velocity.magnitude < 0.0f)
        {
            render.flipX = false;
        }
        else if (rb.velocity.magnitude > 0.0f)
        {
            render.flipX = true;
        } */
    }
    
    //ground collisions
    void OnCollisionEnter2D(Collision2D other)
    {
        print("(Mvmt) On Collision Enter: " + other.gameObject.name);
        if (other.gameObject.CompareTag("Ground"))
        {
            isFalling = false;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        print("(Mvmt) On Collision Exit: " + other.gameObject.name);
        if (other.gameObject.CompareTag("Ground"))
        {
            isFalling = true;
        }
    }

}

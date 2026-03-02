using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform transform;
    //public Animator animator;
    
    public bool isFalling = true;
    public float jumpForce = 5f;
    public float moveSpeed = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
    }
    
    // Update is called once per frame
    void Update()
    {
        //left/right 
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        //jump 
        if (Input.GetKeyDown(KeyCode.Space) && isFalling == false)
        {
            print("Jump!");
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    
    //ground collisions
    void OnCollisionEnter2D(Collision2D other)
    {
        print("On Collision Enter");
        if (other.gameObject.CompareTag("Ground"))
        {
            isFalling = false;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        print("On Collision Exit");
        if (other.gameObject.CompareTag("Ground"))
        {
            isFalling = true;
        }
    }
}

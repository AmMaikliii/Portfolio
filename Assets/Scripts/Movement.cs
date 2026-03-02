using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool isFalling = true;
    public float jumpForce = 10.0f;
    public float moveSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        //left/right movement

        Vector2 moveDirectionRight = Vector2.right * moveSpeed * Time.deltaTime;
        Vector2 moveDirectionLeft = Vector2.left * moveSpeed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb.AddForce(moveDirectionRight, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.AddForce(moveDirectionLeft, ForceMode2D.Impulse);
        }
        //jump movement
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

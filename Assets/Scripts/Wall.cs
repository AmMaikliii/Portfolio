using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wall : MonoBehaviour
{
    public string nextLevel = "";
    public SpriteRenderer render;
    public Transform transform;
    public Animator animator;

    //public float amount = 1f;

    

    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        transform = GetComponent<Transform>();
        animator = GetComponentInChildren<Animator>();

        render.enabled = false;
        animator.enabled = true;
        animator.Play("unfade", 0, 0);
        Invoke("Stop", 1);
    }

    void Stop()
    {
        animator.enabled = false;
    }

    void Update()
    {
        /*Vector3 move = Vector3.one * amount;
        for (int i = 0; i < 5; i++)
        {
            transform.position += move;
        }
        for (int i = 0; i < 5; i++)
        {
            transform.position -= move;
        }*/
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            print("(Wall) Next Level");
            render.enabled = true;
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                animator.enabled = true;
                Invoke("NextLevel", 1);
                animator.Play("fade", 0, 0);
            }  
            
        }
    }
    
    void NextLevel()
    {
        SceneManager.LoadScene(nextLevel);  
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            render.enabled = false;
        }
    }
}

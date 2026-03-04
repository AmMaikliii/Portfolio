using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wall : MonoBehaviour
{
    public string nextLevel = "";
    public SpriteRenderer render;
    public Transform transform;

    //public float amount = 1f;

    

    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        transform = GetComponent<Transform>();

        render.enabled = false;
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
            if(Input.GetKey(KeyCode.W))
            {
                Invoke("NextLevel", 1);
            }  
            
        }
    }
    
    void NextLevel()
    {
        SceneManager.LoadScene(nextLevel);  
    }
}

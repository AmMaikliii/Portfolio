using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text : MonoBehaviour
{
    public SpriteRenderer render;


    public Color visible = new Color(255, 255, 255, 255);
    public Color transparent = new Color(0, 0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();

        render.color = transparent;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        print("Hi " + gameObject.name);
        if(other.gameObject.CompareTag("Player"))
        {
            render.color = visible;
        }
    }
    
    public void OnTriggerExit2D(Collider2D other)
    {
        print("Bye " + gameObject.name);
        if(other.gameObject.CompareTag("Player"))
        {
            render.color = transparent;
        }
    }

}

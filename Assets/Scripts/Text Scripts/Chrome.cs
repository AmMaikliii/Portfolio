using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chrome : MonoBehaviour
{
    public SpriteRenderer render;
    public TextMesh textmesh;

    public string text = "";
    // Start is called before the first frame update
    void Start()
    {
        render.enabled = false;
        render = GetComponent<SpriteRenderer>();
        textmesh = GetComponentInChildren<TextMesh>();
        textmesh.text = "";
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        print("Hi " + gameObject.name);
        if(other.gameObject.CompareTag("Player"))
        {
            render.enabled = true;
            textmesh.text = text;
        }
    }
    
    public void OnTriggerExit2D(Collider2D other)
    {
        print("Bye " + gameObject.name);
        if(other.gameObject.CompareTag("Player"))
        {
            render.enabled = false;
            textmesh.text = "";
        }
    }

}

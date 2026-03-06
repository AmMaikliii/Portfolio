using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    public SpriteRenderer render;
    public TextMesh textmesh;
    public AudioSource audio;
    public AudioClip carl;
    public AudioClip hey;

    public string text = "";
    // Start is called before the first frame update
    void Start()
    {
        render.enabled = false;
        render = GetComponent<SpriteRenderer>();
        textmesh = GetComponentInChildren<TextMesh>();
        textmesh.text = "";
        audio = GetComponent<AudioSource>();
        audio.clip = carl;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        print("Hi " + gameObject.name);
        if(other.gameObject.CompareTag("Player"))
        {
            render.enabled = true;
            textmesh.text = text;
            audio.volume = 1.0f;
            audio.clip = carl;
            audio.Play();
        }
    }
    
    public void OnTriggerExit2D(Collider2D other)
    {
        print("Bye " + gameObject.name);
        if(other.gameObject.CompareTag("Player"))
        {
            render.enabled = false;
            textmesh.text = "";
            audio.clip = hey;
            audio.volume = 0.5f;
            audio.Play();
        }
    }

}

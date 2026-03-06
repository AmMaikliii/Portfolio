using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) && other.gameObject.CompareTag("Player"))
        {
            audio.Play();
        }
    }
}

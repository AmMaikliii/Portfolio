using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wall : MonoBehaviour
{
    public string nextLevel = "";

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            print("Next Level: Wall");
            Invoke("NextLevel", 1);
        }
    }
    
    void NextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }
}

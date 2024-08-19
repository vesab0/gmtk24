using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class scr : MonoBehaviour
{
    public int sceneBuildIndex;

    //enter cilen do scene
    //move player to scene tash

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Trigger Entered");

        if (collision.tag == "Player") ;
        {
            print("Switching to Scene" + sceneBuildIndex);
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }

    
    }

    
}

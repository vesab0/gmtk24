using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controller : MonoBehaviour
{
    public int direction = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Scene currentScene = SceneManager.GetActiveScene();

        // Reload the currently active scene
            SceneManager.LoadScene(currentScene.buildIndex);
        }
    }
    public void createdleft(){
        direction = -1;
        Debug.Log(direction);
    }
    public void createdright(){
        direction = 1;
        Debug.Log(direction);
    }
}